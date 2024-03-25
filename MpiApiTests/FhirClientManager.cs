using Hl7.Fhir.Rest;

namespace MpiApiTests;

public class FhirClientManager(string baseFhirAddress, string authorizationToken)
{
    public FhirClient CreateClient()
    {
        var fhirClient = new FhirClient(baseFhirAddress);
        fhirClient.Settings.PreferredFormat = ResourceFormat.Json;
        fhirClient.RequestHeaders?.Add("Authorization", authorizationToken);
            
        return fhirClient;
    }
}