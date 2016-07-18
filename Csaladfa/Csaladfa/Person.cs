using System;
using System.Collections.Generic;

namespace Csaladfa
{
    public class Person
    {
        private readonly List<Person> _childs = new List<Person>();
        private Person _father;
        private Person _mother;
        public string Name { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public DateTime Born { get; set; }
        public DateTime? Died { get; set; }

        public Person Mother
        {
            get { return _mother; }
            set
            {
                _mother = value;
                value?._childs.Add(this);
            }
        }

        public Person Father
        {
            get { return _father; }
            set
            {
                _father = value;
                value?._childs.Add(this);
            }
        }

        public IReadOnlyList<Person> Childs => _childs;

        public bool IsOrphan()
        {
            return Mother == null && Father == null;
        }

        public bool HasFullFamily()
        {
            return Mother != null && Father != null;
        }

        public IEnumerable<Person> Parents()
        {
            if (Father != null)
            {
                yield return Father;
            }
            if (Mother != null)
            {
                yield return Mother;
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}