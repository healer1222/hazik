using System.IO;
using System.Linq;

namespace Csaladfa.Questions
{
    class Question6 : IQuestion
    {
        public void Answer(CsaladfaContext input, TextWriter output)
        {
            var findPerson = input.FindPerson("Kis Mihály");
            var answer = findPerson.Childs.Where(e => e.Mother != null).GroupBy(e => e.Mother).Count();
            output.WriteLine("Valasz 6: {0}", answer);
        }
    }
}