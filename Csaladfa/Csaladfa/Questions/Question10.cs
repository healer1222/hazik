using System.IO;

namespace Csaladfa.Questions
{
    class Question10 : IQuestion
    {
        public void Answer(CsaladfaContext input, TextWriter output)
        {
            var kisBela = input.FindPerson("Nagy B�la");
            var family = input.GetFamily(kisBela);
            var answer = family?.Childs.Count > 1;
            output.WriteLine("Valasz 10: {0}", answer);

        }
    }
}