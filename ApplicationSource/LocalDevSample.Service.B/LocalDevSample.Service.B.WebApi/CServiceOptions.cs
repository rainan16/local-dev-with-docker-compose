namespace LocalDevSample.Service.B.WebApi;

public class CServiceOptions : ICServiceOptions
{
    [ConfigurationKeyName("UriEndpoint")]
    public string UriEndpoint { get; set; } = "http://backend-c";
}
