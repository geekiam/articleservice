using CloudinaryDotNet;
using FluentValidation;
using Geekiam;
using Geekiam.Behaviours;
using Geekiam.Data;
using Geekiam.Helpers;
using Geekiam.Middleware;
using Geekiam.Websites.Update;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OpenAI_API;
using Serilog;
using Services;
using Strategies;
using Threenine;
using Threenine.Data.DependencyInjection;
using Threenine.Services;
using WebScrapingService;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Geekiam Articles Service", Version = "v1"});
    c.CustomSchemaIds(x => x.FullName);
    c.DocumentFilter<JsonPatchDocumentFilter>();
    c.EnableAnnotations();
});
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddValidatorsFromAssemblies(new[] { typeof(Program).Assembly , typeof(ArticlesContext).Assembly});
builder.Services.AddMediatR(typeof(Program))
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>))
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

var connectionString = builder.Configuration.GetConnectionString(Constants.ConnectionsStringName);
builder.Services.AddDbContext<ArticlesContext>(x => x.UseNpgsql(connectionString)).AddUnitOfWork<ArticlesContext>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient(typeof(IEntityValidationService<>),typeof(EntityValidationService<>));

builder.Services.AddTransient(typeof(IDataService<>), typeof(DataService<>));
builder.Services.AddTransient<IStrategy<FeedLink, List<Article>>, UpdateArticleListingStrategy>();
builder.Services.AddTransient<IProcessService<Posts, Sources>, RecentPostsService>();
builder.Services.AddTransient<IMetaDataService, MetaDataService>();
builder.Services.AddTransient<IMediaService, CloudinaryMediaService>( _ =>
{
    var settings = new CloudinarySettings();
     builder.Configuration.GetSection(Constants.CloudinarySettings).Bind(settings);
    return new CloudinaryMediaService(new Account
    {
        Cloud = settings.Cloud,
        ApiKey = settings.Key,
        ApiSecret = settings.Secret
    });
});

builder.Services.AddTransient<ISummarise, SummaryService>(_ =>
{
    var openApi = new OpenApi();
    builder.Configuration.GetSection(Constants.OpenApi).Bind(openApi);
    var auth = new APIAuthentication(openApi.Key);
    return new SummaryService(auth);
});


var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Database migrations
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<ArticlesContext>();
    context?.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Geekiam Articles Service v1"));
}
app.UseHttpsRedirection();


app.UseAuthorization();
app.MapControllers();
app.Run();
