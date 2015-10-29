using System.Windows;
using AdTools.Library.Views;

namespace AdTools.Library.Common.UI
{
    public abstract class ViewModelBase : DependencyObject
    {
        public MainWindow MainWindow { get; set; }
    }
}
