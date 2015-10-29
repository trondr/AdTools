using System.Windows.Input;

namespace AdTools.Library.ViewModels
{
    public interface IMainViewModel
    {
        int MaxLabelWidth { get; set; }
        string ProductDescription { get; set; }
        string ProductDescriptionLabelText { get; set; }
        ICommand OkCommand { get; set; }
    }
}
