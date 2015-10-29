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
            [RequiredCommandParameter(Description = "Target folder where the reports should be saved.", AlternativeName = "tf", ExampleValue = @"c:\temp")]
            string targetFolder
            )
        {            
            return _reportAllGposCommandProvider.ReportAllGpos(targetFolder);
        }
    }
}
