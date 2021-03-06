using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AdTools.Library.Common;
using AdTools.Library.Infrastructure;
using AdTools.Library.Services;
using Common.Logging;
using Microsoft.GroupPolicy;

namespace AdTools.Library.Commands.ReportAllGpos
{
    public class ReportAllGposCommandProvider : CommandProvider, IReportAllGposCommandProvider
    {
        private readonly IGpmcWindowsFeature _gpmcWindowsFeature;
        private readonly IXmlHelper _xmlHelper;
        private readonly ILog _logger;

        public ReportAllGposCommandProvider(IGpmcWindowsFeature gpmcWindowsFeature, IXmlHelper xmlHelper, ILog logger)
        {
            _gpmcWindowsFeature = gpmcWindowsFeature;
            _xmlHelper = xmlHelper;
            _logger = logger;
        }


        public int ReportAllGpos(string reportFolder, bool removeReadTimestamp, string domainController)
        {
            var returnValue = 0;
            if (!_gpmcWindowsFeature.IsInstalled())
            {
                _logger.ErrorFormat("Windows feature 'GPMC' do not seem to be installed on this machine: {0}. This command can only be executed on a Windows Server Operating System with GPMC feature installed.", Environment.MachineName);
                return 1;
            }
            if (!Directory.Exists(reportFolder))
            {
                _logger.ErrorFormat("Report folder '{0}' does not exists", reportFolder);
                return 1;
            }
            _logger.Info("Clean report folder for existing reports");
            var existingReportFiles = Directory.GetFiles(reportFolder, "*.xml",SearchOption.TopDirectoryOnly);
            foreach (var existingReportFile in existingReportFiles)
            {
                File.Delete(existingReportFile);
            }

            _logger.Info("Report all GPOs...");
            var gpDomain = GetGroupPolicyDomain(domainController);
            var gpoCollection = gpDomain.GetAllGpos();
            foreach (var gpo in gpoCollection)
            {
                var gpoGuid = gpo.Id;
                var gpoReport = gpo.GenerateReport(ReportType.Xml);
                var gpoReportFile = Path.Combine(reportFolder, gpoGuid + ".xml");
                using (var sw = new StreamWriter(gpoReportFile, false, Encoding.UTF8))
                {
                    if (removeReadTimestamp)
                    {
                        gpoReport = RemoveReadTimeStamp(gpoReport);
                    }
                    sw.Write(gpoReport);
                }
            }
            return returnValue;
        }

        private GPDomain GetGroupPolicyDomain(string domainController)
        {
            GPDomain gpDomain;
            if (string.IsNullOrWhiteSpace(domainController))
            {
                gpDomain = new GPDomain();
            }
            else
            {
                var domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
                _logger.Info($"Getting GP domain object from domain '{domainName}' and domain contoller '{domainController}'");
                gpDomain = new GPDomain(domainName, domainController);
            }
            return gpDomain;
        }

        private string RemoveReadTimeStamp(string gpoReport)
        {
            var nameSpaces = new Dictionary<string, string>
            {
                {"http://www.w3.org/2001/XMLSchema-instance", "xsi"},
                {"http://www.w3.org/2001/XMLSchema", "xsd"},
                {"http://www.microsoft.com/GroupPolicy/Settings", "empty"}
            };
            gpoReport = _xmlHelper.RemoveNode(gpoReport, "/empty:GPO/empty:ReadTime", nameSpaces);
            return gpoReport;
        }
    }
}