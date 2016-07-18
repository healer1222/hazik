using System.IO;
using System.Linq;

namespace Csaladfa.Questions
{
    class Question5 : IQuestion
    {
        public void Answer(CsaladfaContext input, TextWriter output)
        {
            var answer = false;
            foreach (var person in input.Persons)
            {
                var grandGrandParents = person.Parents()
                    .SelectMany(e => e.Parents())
                    .SelectMany(e => e.Parents());
                if (grandGrandParents.Any(e => e.Died > person.Born))
                {
                    answer = true;
                    break;
                }
            }
            output.WriteLine("Valasz 5: {0}", answer);
        }
    }
}