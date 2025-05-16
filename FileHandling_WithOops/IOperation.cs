using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Handlng_Advance
{
    internal interface IOperations
    {
        void ReadFile(string path);

        void WriteFile(string path);

        void DeleteFile(string path);

        void EmptyFile(string path);

    }
}
