#tool "dotnet:?package=GitVersion.Tool&version=5.10.3"
#addin nuget:?package=Cake.Docker&version=1.1.2
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
string version = String.Empty;

string projectTag = "Articles";
string rootNamespace = "Geekiam";
string packageName = string.Empty;
string containerRegistry = EnvironmentVariable("CONTAINER_REGISTRY");
string registryToken = EnvironmentVariable("REGISTRY_TOKEN");


//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Validate")
  .Description("Check Environment Variables")
  .Does(() => {
   
   var requiredVariables = new string[] {
    "CONTAINER_REGISTRY",
    "REGISTRY_TOKEN"
   };
   
   foreach(var variable in requiredVariables)
   {
     if(!HasEnvironmentVariable(variable) )
     {
       throw new Exception($"{variable} has not been provided");
     }
   }
   
});

Task("Clean")
     .IsDependentOn("Validate")
    .Does(() => {
    DotNetClean("./Articles.sln");
});

Task("Restore")
    .IsDependentOn("Clean")
    .Description("Restoring the solution dependencies")
    .Does(() => {
    
    var projects = GetFiles("./**/**/*.csproj");
    var settings =  new DotNetRestoreSettings
    {
      Verbosity = DotNetVerbosity.Minimal,
      Sources = new [] { "https://api.nuget.org/v3/index.json" }
    };
    foreach(var project in projects )
    {
      Information($"Restoring { project.ToString()}");
      DotNetRestore(project.ToString(), settings);
    }

});

Task("Version")
  .IsDependentOn("Restore")
   .Does(() =>
{
   var result = GitVersion(new GitVersionSettings {
        UpdateAssemblyInfo = true
    });
    
    version =  result.FullSemVer.ToString();
    Information($"Nuget Version: { version.ToString() }");
    Information($"Semantic Version: { result.FullSemVer.ToString() }");
});

Task("Build")
    .IsDependentOn("Version")
    .Does(() => {
     var buildSettings = new DotNetBuildSettings {
                        Configuration = configuration,
                       };
     var projects = GetFiles("./**/**/*.csproj");
     foreach(var project in projects )
     {
         Information($"Building {project.ToString()}");
         DotNetBuild(project.ToString(),buildSettings);
     }
});



Task("Test")
    .IsDependentOn("Build")
    .Does(() => {

       var testSettings = new DotNetTestSettings  {
                                  Configuration = configuration,
                                  NoBuild = true,
                              };
     var projects = GetFiles("./tests/Unit/*.csproj");
     foreach(var project in projects )
     {
       Information($"Running Tests : { project.ToString()}");
       DotNetTest(project.ToString(), testSettings );
     }


});

Task("Publish")
    .IsDependentOn("Test")
    .Does(() => {

     
     var projects = GetFiles("./src/Api/Api.csproj");
     foreach(var project in projects )
     {
       var publishSettings = new DotNetPublishSettings  {
                                       Configuration = configuration,
                                       NoBuild = true,
                                       OutputDirectory = ".publish",
                                   };
       Information($"Publishing API : { project.ToString()}");
       DotNetPublish(project.ToString(), publishSettings );
     }


});

Task("Docker-Login")
 .IsDependentOn("Publish")
.Does(() => {
  
   if (BuildSystem.GitHubActions.IsRunningOnGitHubActions || BuildSystem.IsRunningOnBitbucketPipelines)
     {
        var loginSettings = new DockerRegistryLoginSettings{ Password = registryToken , Username= "USERNAME" };
        DockerLogin(loginSettings, $"{containerRegistry}");
    }
});

Task("Docker-Build")
 .IsDependentOn("Docker-Login")
.Does(() => {
     packageName = $"{containerRegistry}/{ rootNamespace.ToLower() }/{ projectTag.ToLower() }";
    string [] tags = new string[]  {  $"{ packageName}:{version}"};
      Information("Building : Docker Image");
    var settings = new DockerImageBuildSettings { Tag=tags};
    DockerBuild(settings, "./");
});

Task("Docker-Push")
 .IsDependentOn("Docker-Build")
.Does(() => {
   if (BuildSystem.GitHubActions.IsRunningOnGitHubActions || BuildSystem.IsRunningOnBitbucketPipelines)
   {
      Information("Pushing : Docker Image");
      var settings = new DockerImagePushSettings{ AllTags = true};
      DockerPush(settings, $"{ packageName }");
    }
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

Task("Default")
       .IsDependentOn("Validate")
       .IsDependentOn("Clean")
       .IsDependentOn("Restore")
       .IsDependentOn("Version")
       .IsDependentOn("Build")
       .IsDependentOn("Test")
       .IsDependentOn("Publish")
       .IsDependentOn("Docker-Login")
       .IsDependentOn("Docker-Build")
       .IsDependentOn("Docker-Push");

RunTarget(target);
