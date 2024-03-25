using Bogus;
using Hl7.Fhir.Model;

namespace MpiApiTests.Tests.Fhir.PatientTests.UpdatePatient.UpdatePatientPositive;

public static class UpdatePatientPositiveTestData
{
    private static readonly Faker Faker = new Faker("ru");
    
    public static IEnumerable<Patient> ChangedNameTestCases()
    {
        var firstName = Faker.Name.FirstName();
        
        // Существующий пациент с измененным именем 
        yield return new Patient()
        {
            Identifier =
            [
                new Identifier
                {
                    System = "urn:oid:1.2.643.5.1.13.2.7.100.5",
                    Value = "Identificator290320170508321350",
                    Assigner = new ResourceReference { Display = "1.2.643.2.69.1.2.111" }
                }
            ],
            Name =
            [
                new HumanName
                {
                    Family = firstName,
                    Given = [ "Орехова" ]
                }
            ],
            BirthDate = "1991-10-19",
            ManagingOrganization = new ResourceReference("Organization/464b3220-ad97-493f-b755-2210c2a03b2d")
        };
    }
}