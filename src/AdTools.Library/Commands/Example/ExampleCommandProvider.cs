using System.Windows;
using Common.Logging;
using AdTools.Library.Infrastructure;
using AdTools.Library.ViewModels;
using AdTools.Library.Views;

namespace AdTools.Library.Commands.Example
{
    public class ExampleCommandProvider : CommandProvider, IExampleCommandProvider
    {
        private readonly MainWindow _mainWindow;        
        private readonly ILog _logger;

        public ExampleCommandProvider(MainWindow mainWindow, ILog logger)
        {
            _mainWindow = mainWindow;
            _logger = logger;
        }


        public int Create(string targetRootFolder)
        {
            var returnValue = 0;
            _logger.Info("Showing main window as an example user interface.");
            var application = new Application();
            application.Run(_mainWindow);
            var viewModel = _mainWindow.View.ViewModel as MainViewModel;
            if (viewModel != null)
            {
                _logger.Info("Getting info from the user interface and do something with it: " + viewModel.ProductDescription);
            }
            else
            {
                _logger.Fatal("Fatal error. MainView model returned from dialog was null");
                returnValue = 2;
            }            
            return returnValue;
        }
    }
}