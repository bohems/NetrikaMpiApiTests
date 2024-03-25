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
        var authorizationToken = Configuration["AuthorizationToken"];

        var fhirClientManager = new FhirClientManager(baseFhirAddress, authorizationToken);
        PatientHelper.Initialize(fhirClientManager);
    }
}