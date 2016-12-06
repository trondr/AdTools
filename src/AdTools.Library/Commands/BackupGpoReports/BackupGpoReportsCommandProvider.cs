using AdTools.Library.Commands.InPlaceGitBackup;
using AdTools.Library.Commands.ReportAllGpos;
using Common.Logging;
using Newtonsoft.Json;

namespace AdTools.Library.Commands.BackupGpoReports
{
    public class BackupGpoReportsCommandProvider : IBackupGpoReportsCommandProvider
    {
        private readonly IReportAllGposCommandProvider _reportAllGposCommandProvider;
        private readonly IInPlaceGitBackupProvider _inPlaceGitBackupProvider;
        private readonly ILog _logger;

        public BackupGpoReportsCommandProvider(IReportAllGposCommandProvider reportAllGposCommandProvider, IInPlaceGitBackupProvider inPlaceGitBackupProvider, ILog logger)
        {
            _reportAllGposCommandProvider = reportAllGposCommandProvider;
            _inPlaceGitBackupProvider = inPlaceGitBackupProvider;
            _logger = logger;
        }

        public int BackupGpoReports(string reportFolder)
        {
            var exitCode = _reportAllGposCommandProvider.ReportAllGpos(reportFolder, RemoveReadTimestamp.True);
            if(exitCode != 0)
                return exitCode;

            var status = _inPlaceGitBackupProvider.InPlaceGitBackup(reportFolder);

            _logger.Info("Status: " + JsonConvert.SerializeObject(status));

            return exitCode;
        }
    }
}