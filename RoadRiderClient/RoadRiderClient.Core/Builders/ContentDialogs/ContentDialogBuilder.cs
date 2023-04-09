using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace RoadRiderClient.Core.Builders.ContentDialogs
{
    public class ContentDialogBuilder : IContentDialogBuilder
    {
        ContentDialog _contentDialog;

        public IContentDialogBuilder CreateDialog()
        {
            _contentDialog = new ContentDialog();
            return this;
        }

        public IContentDialogBuilder AddTitle(string title)
        {
            _contentDialog.Title = title;
            return this;
        }

        public IContentDialogBuilder AddContent(string content)
        {
            _contentDialog.Content = content;
            return this;
        }

        public IContentDialogBuilder AddPrimaryButton(string text)
        {
            _contentDialog.PrimaryButtonText = text;
            return this;
        }

        public IContentDialogBuilder AddPrimaryButton(string text, ICommand command, object param = null)
        {
            _contentDialog.PrimaryButtonText = text;
            _contentDialog.PrimaryButtonCommand = command;
            _contentDialog.PrimaryButtonCommandParameter = param;
            return this;
        }

        public IContentDialogBuilder AddCloseButton(string text)
        {
            _contentDialog.CloseButtonText = text;
            return this;
        }

        public IContentDialogBuilder AddCloseButton(string text, ICommand command, object param = null)
        {
            _contentDialog.CloseButtonText = text;
            _contentDialog.CloseButtonCommand = command;
            _contentDialog.CloseButtonCommandParameter = param;
            return this;
        }

        public ContentDialog Build() => _contentDialog;
    }
}
