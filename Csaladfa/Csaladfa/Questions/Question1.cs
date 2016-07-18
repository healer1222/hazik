using System.IO;
using System.Linq;

namespace Csaladfa.Questions
{
    class Question1 : IQuestion
    {
        public void Answer(CsaladfaContext input, TextWriter output)
        {

            var orderedEnumerable = input.Persons
                .Where(e => e.Mother != null)
                .OrderBy(e => e.Born - e.Mother.Born)
                .ToList();
            var answer = orderedEnumerable
                .Select(e => e.Name)
                .FirstOrDefault();
            output.WriteLine("Valasz 1: {0}", answer);
        }
    }
}