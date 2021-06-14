using BimaPlus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BimaPlus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PackageInfo : ContentPage
    {
        public PackageInfo(Quota item)
        {
            InitializeComponent();

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Image { Source = "landscape.jpg" },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Padding = 15,

                            Children =
                            {
                                new Label { Text = item.PackageName, Padding = 10, TextColor = Color.LightBlue, HorizontalOptions = LayoutOptions.StartAndExpand },
                                new Image { Source = "unlike.png", HorizontalOptions = LayoutOptions.EndAndExpand, HeightRequest = 50, WidthRequest = 50 }
                            }
                        },

                        new Label { Text = item.Price, TextColor = Color.LightBlue, FontSize = 20, Padding = 25, },

                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Padding = new Thickness(25, 0),
                            Children =
                            {
                                new Image { Source = "S2.png", HeightRequest = 30, WidthRequest = 70, HorizontalOptions = LayoutOptions.Start },
                                new Label { Text = "(25708)", Padding = new Thickness(8, 0, 0, 0), FontSize = 13, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center },
                                new Button { Text = "Beli", BackgroundColor = Color.FromHex("#f56763"), Padding = 3, FontSize = 17, HeightRequest = 50, WidthRequest = 60, HorizontalOptions = LayoutOptions.EndAndExpand }
                            }
                        },

                        new Label { Text = "Tentang", TextColor = Color.LightBlue, Padding = 25 },
                        new Label { Text = item.Description, VerticalTextAlignment = TextAlignment.Start, Padding = 30 },
                    }
                }
            };
        }
    }
}
