using System;
using System.IO;
using System.Text;
using AdTools.Library.Commands.Example;
using AdTools.Library.Infrastructure;
using AdTools.Library.Services;
using Common.Logging;
using Microsoft.GroupPolicy;

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


        public int ReportAllGpos(string reportFolder)
        {
            var returnValue = 0;
            if (!_gpmcWindowsFeature.IsInstalled())
            {
                _logger.ErrorFormat("Windows feature '{0}' do not seem to be installed on this machine: ", "GPMC");
                return 1;
            }
            if(!Directory.Exists(reportFolder))
            {
                _logger.ErrorFormat("Report folder '{0}' does not exists", reportFolder);
                return 1;
            }
            _logger.Info("Report all GPOs...");            
            var gpDomain = new GPDomain();
            var gpoCollection = gpDomain.GetAllGpos();
            foreach (var gpo in gpoCollection)
            {
                var gpoGuid = gpo.Id;
                var gpoReport = gpo.GenerateReport(ReportType.Xml);
                var gpoReportFile = Path.Combine(reportFolder,gpoGuid.ToString() + ".xml");
                using (var sw = new StreamWriter(gpoReportFile,false,Encoding.UTF8))
                {
                    sw.Write(gpoReport);
                }
            }            
            return returnValue;
        }
    }
}