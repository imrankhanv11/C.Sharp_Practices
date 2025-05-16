using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling_WithOops
{
    internal interface IDictionaryFiles
    {
        void DictionarytoFile(string path);

        void FiletoDictionary(string path);

        void ShowDictionary();

        void ClearDictionary();

        void AddValueDictionary(string path);

        void RemoveValueDictionary(string path);
    }
}
