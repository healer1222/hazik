using System.IO;

namespace Csaladfa
{
    public interface IQuestion
    {
        void Answer(CsaladfaContext input, TextWriter output);
    }
}