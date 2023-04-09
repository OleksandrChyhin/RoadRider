using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace RoadRiderClient.Core.Builders.ContentDialogs
{
    public interface IContentDialogBuilder
    {
        IContentDialogBuilder CreateDialog();
        IContentDialogBuilder AddTitle(string title);
        IContentDialogBuilder AddContent(string content);
        IContentDialogBuilder AddPrimaryButton(string text);
        IContentDialogBuilder AddPrimaryButton(string text, ICommand command, object param = null);
        IContentDialogBuilder AddCloseButton(string text);
        IContentDialogBuilder AddCloseButton(string text, ICommand command, object param = null);
        ContentDialog Build();
    }
}
