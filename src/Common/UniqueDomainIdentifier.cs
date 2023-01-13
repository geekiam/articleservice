namespace Geekiam;

public static class UniqueDomainIdentifier
{
   /// <summary>
   /// Create a human readable identifier 
   /// </summary>
   /// <param name="domain">Any domain name url </param>
   /// <returns></returns>
    public static string Create(string domain)
    {
        var domainParts = domain.Split('.').ToArray();
        var id = domainParts[0] != "www" ? domainParts[0] : domainParts[2];
        return $"g_{id}_{new Random().Next(1, 9999)}";
    }
}