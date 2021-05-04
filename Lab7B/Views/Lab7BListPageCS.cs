using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lab7B 
{

    public class Lab7BListPageCS : ContentPage
    {
        ListView listView;

        public Lab7BListPageCS()
        {
            Title = "Lab7B";

            var toolbarItem = new ToolbarItem
            {
                Text = "+",
                IconImageSource = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Lab7BItemPageCS
                {
                    BindingContext = new Lab7BItem()
                });
            };
            ToolbarItems.Add(toolbarItem);

            listView = new ListView
            {
                Margin = new Thickness(20),
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    label.SetBinding(Label.TextProperty, "Name");

                    var tick = new Image
                    {
                        Source = ImageSource.FromFile("check.png"),
                        HorizontalOptions = LayoutOptions.End
                    };
                    tick.SetBinding(VisualElement.IsVisibleProperty, "Done");

                    var stackLayout = new StackLayout
                    {
                        Margin = new Thickness(20, 0, 0, 0),
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { label, tick }
                    };

                    return new ViewCell { View = stackLayout };
                })
            };
            listView.ItemSelected += async (sender, e) =>
            {

                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new Lab7BItemPageCS
                    {
                        BindingContext = e.SelectedItem as Lab7BItem
                    });
                }
            };

            Content = listView;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Lab7BItemDatabase database = await Lab7BItemDatabase.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }
    }
}
