using Bogus;
using Hl7.Fhir.Model;
using Hl7.Fhir.Support;

namespace MpiApiTests.Tests.Fhir.PatientTests.AddPatient.AddPatientNegative;

public static class AddPatientNegativeTestData
{
    private static readonly Faker Faker = new Faker("ru");
    
    public static IEnumerable<Patient> InvalidNameTestCases()
    {
        var minBirthday = new DateTime(1901, 1, 1);
        var maxBirthday = DateTime.Now;
    
        
        // Пациент с пустой строкой в фамилии
        yield return new Patient
        {
            Identifier =
            [
                new Identifier
                {
                    System = "urn:oid:1.2.643.5.1.13.2.7.100.5",
                    Value = $"Identificator{Faker.Random.ReplaceNumbers(new string('#', 18))}",
                    Assigner = new ResourceReference {Display = "1.2.643.2.69.1.2.111"}
                }
            ],
            Name =
            [
                new HumanName
                {
                    Family = "",
                    Given = new List<string> {Faker.Name.FirstName()}
                }
            ],
            BirthDate = Faker.Date.Between(minBirthday, maxBirthday).ToFhirDate(),
            
            ManagingOrganization = new ResourceReference("Organization/464b3220-ad97-493f-b755-2210c2a03b2d")
        };
        
        
        // Пациент с null в фамилии
        yield return new Patient
        {
            Identifier =
            [
                new Identifier
                {
                    System = "urn:oid:1.2.643.5.1.13.2.7.100.5",
                    Value = $"Identificator{Faker.Random.ReplaceNumbers(new string('#', 18))}",
                    Assigner = new ResourceReference {Display = "1.2.643.2.69.1.2.111"}
                }
            ],
            Name =
            [
                new HumanName
                {
                    Family = null,
                    Given = new List<string> {Faker.Name.FirstName()}
                }
            ],
            BirthDate = Faker.Date.Between(minBirthday, maxBirthday).ToFhirDate(),
            
            ManagingOrganization = new ResourceReference("Organization/464b3220-ad97-493f-b755-2210c2a03b2d")
        };
        
        
        // Пациент с null в фамилии
        yield return new Patient
        {
            Identifier =
            [
                new Identifier
                {
                    System = "urn:oid:1.2.643.5.1.13.2.7.100.5",
                    Value = $"Identificator{Faker.Random.ReplaceNumbers(new string('#', 18))}",
                    Assigner = new ResourceReference {Display = "1.2.643.2.69.1.2.111"}
                }
            ],
            Name =
            [
                new HumanName
                {
                    Family = null,
                    Given = new List<string> {Faker.Name.FirstName()}
                }
            ],
            BirthDate = Faker.Date.Between(minBirthday, maxBirthday).ToFhirDate(),
            
            ManagingOrganization = new ResourceReference("Organization/464b3220-ad97-493f-b755-2210c2a03b2d")
        };
        
        
        // Пациент с пустой строкой в имени
        yield return new Patient
        {
            Identifier =
            [
                new Identifier
                {
                    System = "urn:oid:1.2.643.5.1.13.2.7.100.5",
                    Value = $"Identificator{Faker.Random.ReplaceNumbers(new string('#', 18))}",
                    Assigner = new ResourceReference {Display = "1.2.643.2.69.1.2.111"}
                }
            ],
            Name =
            [
                new HumanName
                {
                    Family = Faker.Name.FirstName(),
                    Given = new List<string> {""}
                }
            ],
            BirthDate = Faker.Date.Between(minBirthday, maxBirthday).ToFhirDate(),
            
            ManagingOrganization = new ResourceReference("Organization/464b3220-ad97-493f-b755-2210c2a03b2d")
        };
        
        
        // Пациент с пустой null в Given
        yield return new Patient
        {
            Identifier =
            [
                new Identifier
                {
                    System = "urn:oid:1.2.643.5.1.13.2.7.100.5",
                    Value = $"Identificator{Faker.Random.ReplaceNumbers(new string('#', 18))}",
                    Assigner = new ResourceReference {Display = "1.2.643.2.69.1.2.111"}
                }
            ],
            Name =
            [
                new HumanName
                {
                    Family = Faker.Name.FirstName(),
                    Given = null
                }
            ],
            BirthDate = Faker.Date.Between(minBirthday, maxBirthday).ToFhirDate(),
            
            ManagingOrganization = new ResourceReference("Organization/464b3220-ad97-493f-b755-2210c2a03b2d")
        };
    }

    public static IEnumerable<Patient> InvalidBirthdayTestCases()
    {
        var maxBirthday = DateTime.Now.AddDays(2).ToFhirDate();
        
        
        // Пациент с пустой null в дате рождения 
        yield return new Patient
        {
            Identifier =
            [
                new Identifier
                {
                    System = "urn:oid:1.2.643.5.1.13.2.7.100.5",
                    Value = $"Identificator{Faker.Random.ReplaceNumbers(new string('#', 18))}",
                    Assigner = new ResourceReference {Display = "1.2.643.2.69.1.2.111"}
                }
            ],
            Name =
            [
                new HumanName
                {
                    Family = Faker.Name.LastName(),
                    Given = new List<string> {Faker.Name.FirstName()}
                }
            ],
            BirthDate = null,
            
            ManagingOrganization = new ResourceReference("Organization/464b3220-ad97-493f-b755-2210c2a03b2d")
        };
        
        
        // Пациент с датой рождения меньше минимально допустимой
        yield return new Patient
        {
            Identifier =
            [
                new Identifier
                {
                    System = "urn:oid:1.2.643.5.1.13.2.7.100.5",
                    Value = $"Identificator{Faker.Random.ReplaceNumbers(new string('#', 18))}",
                    Assigner = new ResourceReference {Display = "1.2.643.2.69.1.2.111"}
                }
            ],
            Name =
            [
                new HumanName
                {
                    Family = Faker.Name.LastName(),
                    Given = new List<string> {Faker.Name.FirstName()}
                }
            ],
            BirthDate = new DateTime(1900, 1, 1).ToFhirDate(),
            
            ManagingOrganization = new ResourceReference("Organization/464b3220-ad97-493f-b755-2210c2a03b2d")
        };
        
        
        // Пациент с датой рождения больше максимально допустимой
        yield return new Patient
        {
            Identifier =
            [
                new Identifier
                {
                    System = "urn:oid:1.2.643.5.1.13.2.7.100.5",
                    Value = $"Identificator{Faker.Random.ReplaceNumbers(new string('#', 18))}",
                    Assigner = new ResourceReference {Display = "1.2.643.2.69.1.2.111"}
                }
            ],
            Name =
            [
                new HumanName
                {
                    Family = Faker.Name.LastName(),
                    Given = new List<string> {Faker.Name.FirstName()}
                }
            ],
            BirthDate = maxBirthday,
            
            ManagingOrganization = new ResourceReference("Organization/464b3220-ad97-493f-b755-2210c2a03b2d")
        };
    }
}