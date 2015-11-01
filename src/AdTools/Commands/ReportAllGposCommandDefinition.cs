using NCmdLiner.Attributes;
using AdTools.Library.Commands.Example;
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

        [Command(Description = "Report all GPOs to xml files, one GPO in each xml file.")]
        public int ReportAllGpos(
            [RequiredCommandParameter(Description = "Report folder where the reports will be saved.", AlternativeName = "tf", ExampleValue = @"c:\temp")]
            string reportFolder
            )
        {            
            return _reportAllGposCommandProvider.ReportAllGpos(reportFolder);
        }
    }
}
