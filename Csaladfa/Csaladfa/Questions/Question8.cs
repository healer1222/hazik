using System.IO;
using System.Linq;

namespace Csaladfa.Questions
{
    class Question8 : IQuestion
    {
        public void Answer(CsaladfaContext input, TextWriter output)
        {
            var answer = input.Persons.Any(e => e.Parents().Any(par => e.Died < par.Died));
            output.WriteLine("Valasz 8: {0}", answer);
        }
    }
}