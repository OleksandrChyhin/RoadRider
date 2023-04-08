using Microsoft.Extensions.DependencyInjection;
using RoadRiderClient.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RoadRiderClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();

            ViewModel = (Application.Current as App).Container.GetRequiredService<MainPageViewModel>();

            Navigation.SelectedItem = Navigation.MenuItems[0];
        }

        private void Navigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem navigationViewItem)
            {
                if (args.IsSettingsSelected)
                {
                    //ContentFrame.Navigate(typeof(SettingsPage));
                }
                else
                {
                    ContentFrame.Navigate(GetPageType(navigationViewItem.Tag.ToString()));
                }
            }
        }

        Type GetPageType(string pageTag)
        {
            switch (pageTag)
            {
                case "MapPage": return typeof(MapPage);
                default: throw new Exception();
            }
        }
    }
}
