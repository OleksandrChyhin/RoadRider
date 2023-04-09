using RoadRiderClient.Core.Builders.ContentDialogs;
using Windows.UI.Xaml.Controls;

namespace RoadRiderClient.Core.Directors.ContentDialogs
{
    public interface IContentDialogDirector
    {
        IContentDialogBuilder Builder { set; }

        ContentDialog CreateNotificationDialog(string titleKey, string messageKey);
    }
}
