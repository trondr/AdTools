using AdTools.Library.Commands.ReportAllGpos;
using NCmdLiner.Attributes;
using AdTools.Library.Infrastructure;

namespace AdTools.Commands
{
    public class ReportAllGposCommandDefinition: CommandDefinition
    {
        private readonly IReportAllGposCommandProvider _reportAllGposCommandProvider;        

        public ReportAllGposCommandDefinition(IReportAllGposCommandProvider reportAllGposCommandProvider)
        {
            _reportAllGposCommandProvider = reportAllGposCommandProvider;            
        }

        [Command(Description = "Report all GPOs to xml files. One xml file for each GPO.")]
        public int ReportAllGpos(
            [RequiredCommandParameter(Description = "Report folder where the reports will be saved.", AlternativeName = "rf", ExampleValue = @"c:\temp")]
            string reportFolder,
            [OptionalCommandParameter(Description = "Remove read time stamp from xml file before saving to report folder. This will prevent report files from becoming different each time report is written.", AlternativeName = "rr", DefaultValue = true, ExampleValue = false)]
            bool removeReadTimestamp
            )
        {            
            return _reportAllGposCommandProvider.ReportAllGpos(reportFolder, removeReadTimestamp);
        }
    }
}
