using System;
using System.IO;

namespace AdTools.Library.Services
{
    public class GpmcWindowsFeature : IGpmcWindowsFeature
    {
        public bool IsInstalled()
        {
            var gpMcAssemblyCacheFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Microsoft.NET", "assembly", "GAC_MSIL", "Microsoft.GroupPolicy.Management");
            if (Directory.Exists(gpMcAssemblyCacheFolder))
            {
                return true;
            }
            return false;
        }
    }
}