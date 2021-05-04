using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lab7B
{
    public class Lab7BItemPageCS : ContentPage
    {
        ListView listView;

        public Lab7BItemPageCS()
        {   
            Title = "Lab7B Item";
            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "TheFact");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "ShortFact");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Entry.TextProperty, "ImageFile");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async(sender, e) =>
            {
                var todoItem = (Lab7BItem)BindingContext;
                Lab7BItemDatabase database = await Lab7BItemDatabase.Instance;
                await database.SaveItemAsync(todoItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async(sender, e) =>
                {
                    var lab7BItem = (Lab7BItem)BindingContext;
                    Lab7BItemDatabase database = await Lab7BItemDatabase.Instance;
                    await database.DeleteItemAsync(lab7BItem);
                    await Navigation.PopAsync();
                };

             var cancelButton = new Button { Text = "Cancel" };
             cancelButton.Clicked += async (sender, e) =>
                {
                    await Navigation.PopAsync();
                };

            Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    Children =
                        {
                            new Label { Text = "TheFact" },
                            nameEntry,
                            new Label { Text = "ShortFac" },
                            notesEntry,
                            new Label { Text = "ImageFile" },
                            doneSwitch,
                            saveButton,
                            deleteButton,
                            cancelButton
                        }
                };
        }
    }
}
