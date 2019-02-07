using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
    public class FileDataService : IFileDataService
    {
        public static String[] sizeArray = { "-s", "--s", "/s", "--size" };
        public static String[] versionArray = { "-v", "–v", "--v", "/v", "--version" };
        private FileDetails fileDetails;

        public FileDataService(FileDetails fileDetails)
        {
            this.fileDetails = fileDetails;
        }

        public string GetAppropriateAction(string command, string fileName)
        {
            if (IsSizeTask(command))
            {
                return fileDetails.Size(fileName).ToString();
            }
            else if (IsVersonTask(command))
            {
                return fileDetails.Version(fileName);
            }
            else
            {
                throw new Exception("Command not recognised");
            }
        }

        public bool IsSizeTask(string command)
        {
            return !string.IsNullOrEmpty(command) && sizeArray.ToList().Contains(command);
        }

        public bool IsVersonTask(string command)
        {
            return !string.IsNullOrEmpty(command) && versionArray.ToList().Contains(command);
        }
    }
}
