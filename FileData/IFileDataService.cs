using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    public interface IFileDataService
    {
        bool IsVersonTask(string command);
        bool IsSizeTask(string command);
        string GetAppropriateAction(string command, string fileName);
    }
}
