using Hl7.Fhir.Model;

namespace MpiApiTests.Helpers.Fhir;

public static class PatientHelper
{
    private static FhirClientManager _fhirClientManager;

    public static void Initialize(FhirClientManager fhirClientManager)
    {
        _fhirClientManager = fhirClientManager;
    }

    public static async Task<Patient?> CreatePatientAsync(Patient patient)
    {
        var fhirClient = _fhirClientManager.CreateClient();
        return await fhirClient.CreateAsync(patient);
    }

    public static async Task<Patient?> UpdatePatientAsync(Patient patient)
    {
        var fhirClient = _fhirClientManager.CreateClient();
        return await fhirClient.CreateAsync(patient);
    }
}

