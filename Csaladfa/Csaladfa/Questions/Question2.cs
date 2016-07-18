using System.IO;
using System.Linq;

namespace Csaladfa.Questions
{
    class Question2 : IQuestion
    {
        public void Answer(CsaladfaContext input, TextWriter output)
        {
            var families = input.Families;
            var answer = families.Select(e => e.Childs.Count).Max();
            output.WriteLine("Valasz 2: {0}", answer);
        }
    }
}