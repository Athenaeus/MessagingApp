using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingAPP
{
    class FileHandling
    {
        public void WriteMessage(string data)
        {
            using (StreamWriter stream = new FileInfo("MessagesFile.txt").AppendText())
            {
                stream.WriteLine(data);
                stream.WriteLine("***-----------------------------***");
            }
        }
    }
}
