namespace Common;

public static class RegularExpressions
{
    /// <summary>
    ///     A permissive input ensuring on some special characters are omitted
    /// </summary>
    public const string AcceptableNameCharactersOnly = @"^[^""±!@£$%^&*_+§¡€#¢§¶•ªº«\\/<>?:;|=.,\n]+$";

    /// <summary>
    /// </summary>
    public const string OrganisationNameValidator = @"^[A-Z]+[\w\d\s]*$";
    

    public const string DomainName = @"\A([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,}\Z";
    
    public const string RelativeUrlPath = @"^([\/][a-zA-Z]+)+\.*(((\?)([a-zA-Z]*=\w*)){1}((&)([a-zA-Z]*=\w*))*)?$";
    
    

}