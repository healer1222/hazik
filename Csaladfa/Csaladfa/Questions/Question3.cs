using System.IO;
using System.Linq;

namespace Csaladfa.Questions
{
    class Question3 : IQuestion
    {
        public void Answer(CsaladfaContext input, TextWriter output)
        {
            var answers = input.FindPerson("Kis Géza")?.Parents()
                .Where(e => e.Mother != null)
                .Select(e => e.MotherName)
                .ToArray()
                ?? new string[0];
            foreach (var answer in answers)
            {
                output.WriteLine("Valasz 3: {0}", answer);
            }
        }
    }
}