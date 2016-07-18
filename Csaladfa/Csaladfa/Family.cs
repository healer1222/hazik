using System.Collections.Generic;

namespace Csaladfa
{
    public class Family
    {
        public static Family CreateNewFor(Person person)
        {
            var family = new Family
            {
                Father = person.Father,
                Mother = person.Mother
            };
            family.Childs.Add(person);
            return family;
        }
        public List<Person> Childs { get; } = new List<Person>();
        public Person Father { get; set; }
        public Person Mother { get; set; }

        public bool IsChildOfFamily(Person person)
        {
            return ReferenceEquals(Mother, person.Mother) && ReferenceEquals(Father, person.Father);
        }
    }
}