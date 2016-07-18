using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Csaladfa.Questions
{
    class Question7 : IQuestion
    {
        public void Answer(CsaladfaContext input, TextWriter output)
        {
            var answers = new List<string>();
            foreach (var person in input.Persons)
            {
                if (person.IsOrphan()) continue;
                var grandparents = person.Parents().SelectMany(e => e.Parents()).ToList();
                if (grandparents.Count > 0
                    && grandparents.All(e => e.Died < person.Born))
                {
                    answers.Add(person.Name);
                }
            }
            foreach (var answer in answers)
            {
                output.WriteLine("Valasz 7: {0}", answer);
            }
        }
    }
}