using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RoadRiderClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        public MapPage()
        {
            InitializeComponent();

            Navigation.SelectedItem = Navigation.MenuItems[0];
        }

        void Navigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem navigationViewItem)
            {
                ContentFrame.Navigate(GetPageType(navigationViewItem.Tag.ToString()));
            }
        }

        Type GetPageType(string pageTag)
        {
            switch (pageTag)
            {
                case "SearchPage": return typeof(SearchPage);
                case "DirectionPage": return typeof(DirectionPage);
                default: throw new Exception();
            }
        }
    }
}
