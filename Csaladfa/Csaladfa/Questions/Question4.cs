using System;
using System.IO;
using System.Linq;

namespace Csaladfa.Questions
{
    class Question4 : IQuestion
    {
        public void Answer(CsaladfaContext input, TextWriter output)
        {
            var answer = input.Persons.Where(e => e.HasFullFamily())
                .OrderByDescending(e => AgeDifferenceByDays(e.Mother, e.Father))
                .Select(e => e.Name)
                .FirstOrDefault();
            output.WriteLine("Valasz 4: {0}", answer);
        }

        private static double AgeDifferenceByDays(Person person1, Person person2)
        {
            TimeSpan differenceInTimeSpan = person1.Born - person2.Born;
            return Math.Abs(differenceInTimeSpan.TotalDays);
        }
    }
}