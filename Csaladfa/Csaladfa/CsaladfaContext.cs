using System.Collections.Generic;
using System.Linq;

namespace Csaladfa
{
    public class CsaladfaContext
    {
        public List<Person> Persons { get; set; }
        public List<Family> Families { get; set; }


        public Person FindPerson(string name)
        {
            return Persons.Find(e => e.Name == name);
        }

        public Family GetFamily(Person kisBela)
        {
            return Families.FirstOrDefault(e => e.IsChildOfFamily(kisBela));
        }
    }
}