using CsvHelper.Configuration;

namespace Csaladfa
{
    public sealed class PersonClassMap : CsvClassMap<Person>
    {
        public PersonClassMap()
        {
            Map(m => m.Name).Index(0);
            Map(m => m.Born).Index(1);
            Map(m => m.Died).Index(2);
            Map(m => m.FatherName).Index(3);
            Map(m => m.MotherName).Index(4);
        }
    }
}