using AdTools.Library.Commands.BackupGpoReports;
using AdTools.Library.Infrastructure;
using NCmdLiner.Attributes;

namespace AdTools.Commands
{
    public class BackupGpoReportsCommandDefinition: CommandDefinition
    {
        private readonly IBackupGpoReportsCommandProvider _backupGpoReportsCommandProvider;

        public BackupGpoReportsCommandDefinition(IBackupGpoReportsCommandProvider backupGpoReportsCommandProvider)
        {
            _backupGpoReportsCommandProvider = backupGpoReportsCommandProvider;
        }

        [Command(Description = "Backup GPO reports.")]
        public int BackupGpoReports(
            [RequiredCommandParameter(Description = "Report folder where the reports will be saved.", AlternativeName = "rf", ExampleValue = @"c:\temp\gporeports")]
            string reportFolder            
        )
        {            
            return _backupGpoReportsCommandProvider.BackupGpoReports(reportFolder);
        }
    }
}