using System.Collections;
using System.ComponentModel;
using System.Reflection;
using AdTools.Commands;
using AdTools.Library.Common.Install;

namespace AdTools
{
    [RunInstaller(true)]
    public partial class CustomInstaller : System.Configuration.Install.Installer
    {
        public CustomInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            //Example: Adding a command to windows explorer contect menu
            //this.Context.LogMessage("Adding AdTools to File Explorer context menu...");
            //new WindowsExplorerContextMenuInstaller().Install("AdTools", "Create Something...", Assembly.GetExecutingAssembly().Location, "CreateSomething /exampleParameter=\"%1\"");
            //this.Context.LogMessage("Finnished adding AdTools to File Explorer context menu.");
            
            base.Install(stateSaver);
        }

        public override void Uninstall(IDictionary savedState)
        {
            //Example: Removing previously installed command from windows explorer contect menu
            //this.Context.LogMessage("Removing AdTools from File Explorer context menu...");
            //new WindowsExplorerContextMenuInstaller().UnInstall("AdTools");
            //this.Context.LogMessage("Finished removing AdTools from File Explorer context menu.");
            
            base.Uninstall(savedState);
        }        
    }
}
