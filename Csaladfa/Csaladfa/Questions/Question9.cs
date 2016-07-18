using System.IO;
using System.Linq;

namespace Csaladfa.Questions
{
    class Question9 : IQuestion
    {
        public void Answer(CsaladfaContext input, TextWriter output)
        {
            var answer =  input.Persons.Any(p1 => input.Persons.Any(p2 => p1.Born == p2.Died));
            output.WriteLine("Valasz 9: {0}", answer);
        }
    }
}