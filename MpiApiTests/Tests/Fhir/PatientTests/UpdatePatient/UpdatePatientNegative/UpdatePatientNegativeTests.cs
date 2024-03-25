using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using MpiApiTests.Helpers.Fhir;
using Task = System.Threading.Tasks.Task;

namespace MpiApiTests.Tests.Fhir.PatientTests.UpdatePatient.UpdatePatientNegative;

public class UpdatePatientNegativeTests
{
    [Test]
    [Description("Получить ошибку при обновлении имени и дня рождения")]
    [TestCaseSource(typeof(UpdatePatientNegativeTestData), nameof(UpdatePatientNegativeTestData.TestCases))]
    public async Task UpdatePatientDetails_ShouldThrow(Patient patient)
    {
        const string errorMessage =
            $"Операция должна вызвать исключение {nameof(FhirOperationException)} при попытке сменить {nameof(Patient.BirthDate)} и {nameof(Patient.Name)}";
    
        Assert.ThrowsAsync<FhirOperationException>(
            async () => await PatientHelper.UpdatePatientAsync(patient),
            errorMessage
        );
    }
}