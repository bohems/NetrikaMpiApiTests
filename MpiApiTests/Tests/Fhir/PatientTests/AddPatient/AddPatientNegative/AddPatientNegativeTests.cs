using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using MpiApiTests.Helpers.Fhir;
using Task = System.Threading.Tasks.Task;

namespace MpiApiTests.Tests.Fhir.PatientTests.AddPatient.AddPatientNegative;

public class AddPatientNegativeTests
{
    [Test]
    [Description("Получить ошибку валидации в имени пациента при создании нового пациента")]
    [TestCaseSource(typeof(AddPatientNegativeTestData), nameof(AddPatientNegativeTestData.InvalidNameTestCases))]
    public async Task AddPatientWithInvalidName_ShouldThrow(Patient patient)
    {
        const string exceptionMessage = $"Операция должна вызвать исключение {nameof(FhirOperationException)} из-за недопустимого {nameof(Patient.Name)}.";

        Assert.ThrowsAsync<FhirOperationException>(
            async () => await PatientHelper.CreatePatientAsync(patient),
            exceptionMessage);
    }
    
    [Test]
    [Description("Получить ошибку валидации в дате рождения пациента при создании нового пациента")]
    [TestCaseSource(typeof(AddPatientNegativeTestData), nameof(AddPatientNegativeTestData.InvalidBirthdayTestCases))]
    public async Task AddPatientWithInvalidBirthday_ShouldThrow(Patient patient)
    {
        const string exceptionMessage = $"Операция должна вызвать исключение {nameof(FhirOperationException)} из-за недопустимого {nameof(Patient.BirthDate)}.";

        Assert.ThrowsAsync<FhirOperationException>(
            async () => await PatientHelper.CreatePatientAsync(patient),
            exceptionMessage);
    }
}