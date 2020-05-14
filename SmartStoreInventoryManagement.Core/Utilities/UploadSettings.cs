using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Utilities
{
    public class UploadSettings
    {

        public string MaxBytes { get; set; }

        public string[] AcceptedFiles { get; set; }


        public bool IsFileSupported(string fileName)
        {

            return AcceptedFiles.Any(s => s == Path.GetExtension(fileName).ToLower());
        }
    }
}
