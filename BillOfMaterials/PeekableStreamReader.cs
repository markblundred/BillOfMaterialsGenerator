using System.Collections.Generic;
using System.IO;

namespace BillOfMaterials
{
    // This class was added due to need to be able to peek at a line and not just a single character
    // This code taken from stack overflow at https://stackoverflow.com/questions/842465/reading-a-line-from-a-streamreader-without-consuming
    public class PeekableStreamReaderAdapter
    {
        private StreamReader Underlying;
        private Queue<string> BufferedLines;

        public PeekableStreamReaderAdapter(StreamReader underlying)
        {
            Underlying = underlying;
            BufferedLines = new Queue<string>();
        }

        public string PeekLine()
        {
            string line = Underlying.ReadLine();
            if (line == null)
                return null;
            BufferedLines.Enqueue(line);
            return line;
        }

        public string ReadLine()
        {
            if (BufferedLines.Count > 0)
                return BufferedLines.Dequeue();
            return Underlying.ReadLine();
        }
    }
}
