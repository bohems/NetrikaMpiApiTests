using Microsoft.Extensions.Configuration;
using MpiApiTests.Helpers.Fhir;

namespace MpiApiTests;

[SetUpFixture]
public class BaseSetup
{
    public IConfiguration Configuration { get; private set; }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        var baseFhirAddress = Configuration["BaseFhirAddress"];
        
        if (string.IsNullOrEmpty(baseFhirAddress))
        {
            throw new InvalidOperationException("Базовый адрес FHIR не настроен.");
        }

        var authorizationToken = Configuration["AuthorizationToken"];
        
        if (string.IsNullOrEmpty(authorizationToken))
        {
            throw new InvalidOperationException("Токен авторизации не настроен.");
        }

        var fhirClientManager = new FhirClientManager(baseFhirAddress, authorizationToken);
        PatientHelper.Initialize(fhirClientManager);
    }
}