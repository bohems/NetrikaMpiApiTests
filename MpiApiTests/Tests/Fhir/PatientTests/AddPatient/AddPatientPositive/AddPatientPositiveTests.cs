using Hl7.Fhir.Model;
using MpiApiTests.Helpers.Fhir;
using Task = System.Threading.Tasks.Task;

namespace MpiApiTests.Tests.Fhir.PatientTests.AddPatient.AddPatientPositive;

public class AddPatientPositiveTests
{
    [Test]
    [Description("Успешно создать нового пациента в системе urn:oid:1.2.643.5.1.13.2.7.100.5")]
    [TestCaseSource(typeof(AddPatientPositiveTestData), nameof(AddPatientPositiveTestData.TestCases))]
    public async Task AddPatient_ShouldCreateValidPatient(Patient patient)
    {
        var createdPatient = await PatientHelper.CreatePatientAsync(patient);
        
        const string errorMessage = $"Данные созданного пациента не совпадают с теми, что были возвращены.";
        
        CollectionAssert.AreEquivalent(patient.Name, createdPatient?.Name, errorMessage); 
        CollectionAssert.AreEquivalent(patient.Telecom, createdPatient?.Telecom, errorMessage);
        CollectionAssert.AreEquivalent(patient.Address, createdPatient?.Address, errorMessage);
    }
}