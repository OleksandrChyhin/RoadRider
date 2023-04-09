using RoadRiderClient.Core.Builders.ContentDialogs;
using RoadRiderClient.Shared;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Controls;

namespace RoadRiderClient.Core.Directors.ContentDialogs
{
    public class ContentDialogDirector : IContentDialogDirector
    {
        public IContentDialogBuilder Builder { private get; set; }

        public ContentDialog CreateNotificationDialog(string titleKey, string messageKey)
        {
            var resourceLoader = ResourceLoader.GetForCurrentView();
            var cancelTranslation = resourceLoader.GetString(Constants.Cancel);
            var titleTranslation = resourceLoader.GetString(titleKey);
            var messageTranslation = resourceLoader.GetString(messageKey);

            return Builder.CreateDialog()
                          .AddTitle(titleTranslation)
                          .AddContent(messageTranslation)
                          .AddPrimaryButton(cancelTranslation)
                          .Build();
        }
    }
}
