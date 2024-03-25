using Bogus;
using Hl7.Fhir.Model;
using Hl7.Fhir.Support;

namespace MpiApiTests.Tests.Fhir.PatientTests.UpdatePatient.UpdatePatientNegative;

public static class UpdatePatientNegativeTestData
{
    private static readonly Faker Faker = new Faker("ru");
    
    
    public static IEnumerable<Patient> TestCases()
    {
        var minBirthday = new DateTime(1901, 1, 1);
        var maxBirthday = DateTime.Now;
        
        
        // Существующий пациент с измененным именем и датой рождения 
        yield return new Patient
        {
            Identifier =
            [
                new Identifier
                {
                    System = "urn:oid:1.2.643.5.1.13.2.7.100.5",
                    Value = "Identificator290320170508321350",
                    Assigner = new ResourceReference {Display = "1.2.643.2.69.1.2.111"}
                }
            ],
            Name =
            [
                new HumanName
                {
                    Family = Faker.Name.LastName(),
                    Given = new List<string> {Faker.Name.FirstName(), Faker.Name.LastName()}
                }
            ],
            BirthDate = Faker.Date.Between(minBirthday, maxBirthday).ToFhirDate(),
            Address =
            [
                new Address {Use = Address.AddressUse.Home, Text = "123456, г. Прегонь, ул. Северная, 4/2"},
                new Address {Use = Address.AddressUse.Work, Text = "123456, г. Прегонь, ул. Северная, 4/2"},
                new Address {Use = Address.AddressUse.Old, Text = "123456, г. Прегонь, ул. Северная, 4/2"},
                new Address {Use = Address.AddressUse.Temp, Text = "123456, г. Прегонь, ул. Северная, 4/2"}
            ],
            ManagingOrganization = new ResourceReference("Organization/464b3220-ad97-493f-b755-2210c2a03b2d")
        };
    }
}