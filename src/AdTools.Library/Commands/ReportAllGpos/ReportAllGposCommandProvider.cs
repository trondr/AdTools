using System;
using AdTools.Library.Commands.Example;
using AdTools.Library.Infrastructure;
using AdTools.Library.Services;
using Common.Logging;

namespace AdTools.Library.Commands.ReportAllGpos
{
    public class ReportAllGposCommandProvider : CommandProvider, IReportAllGposCommandProvider
    {        
        private readonly IGpmcWindowsFeature _gpmcWindowsFeature;
        private readonly ILog _logger;

        public ReportAllGposCommandProvider(IGpmcWindowsFeature gpmcWindowsFeature, ILog logger)
        {            
            _gpmcWindowsFeature = gpmcWindowsFeature;
            _logger = logger;
        }


        public int ReportAllGpos(string targetRootFolder)
        {
            var returnValue = 0;
            if (!_gpmcWindowsFeature.IsInstalled())
            {
                _logger.ErrorFormat("Windows feature '{0}' do not seem to be installed on this machine: ", "GPMC");
                return 1;
            }
            _logger.Info("Report all GPOs...");
            ToDo.Implement(ToDoPriority.Critical, "eta410", "Implement report all GPOs command.");
            throw new NotImplementedException();
            return returnValue;
        }
    }
}