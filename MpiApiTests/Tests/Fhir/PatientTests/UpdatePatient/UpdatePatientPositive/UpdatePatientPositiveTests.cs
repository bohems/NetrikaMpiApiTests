using Hl7.Fhir.Model;
using MpiApiTests.Helpers.Fhir;
using Task = System.Threading.Tasks.Task;

namespace MpiApiTests.Tests.Fhir.PatientTests.UpdatePatient.UpdatePatientPositive;


// TODO: Изменить сценарий: В начале теста получать пациента с помощью /fhir/$getpatient и проверять значения полей Имени и ДР
public class UpdatePatientPositiveTests
{
    [Test]
    [Description("Обновить имя существующего пациента")]
    [TestCaseSource(typeof(UpdatePatientPositiveTestData), nameof(UpdatePatientPositiveTestData.ChangedNameTestCases))]
    public async Task UpdatePatientName_ShouldUpdateName(Patient patient)
    {
        var updatedPatient = await PatientHelper.UpdatePatientAsync(patient);
        
        const string errorMessage = $"Обновлённый {nameof(Patient.Name)} пациента не совпадает с теми, что был возвращён.";
        
        CollectionAssert.AreEquivalent(patient.Name, updatedPatient?.Name);
    }
}