using System;
using System.Collections.Generic;
using System.Text;

namespace TestCI.Database
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
