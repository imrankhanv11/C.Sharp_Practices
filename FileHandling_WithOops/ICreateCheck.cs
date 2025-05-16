using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Handlng_Advance
{
    internal interface ICretionCheck
    {
        void CreateFile(string path);

        string GetFileName();
    }
}
