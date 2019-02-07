using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if(args != null && args.Length == 2)
            {
                IFileDataService service = new FileDataService(new FileDetails());
                Console.Write(service.GetAppropriateAction(args[0], args[1]));
                Console.Read();
            }
        }
    }
}
