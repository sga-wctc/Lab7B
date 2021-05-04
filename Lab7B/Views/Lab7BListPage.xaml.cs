using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab7B
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lab7BListPage : ContentPage
    {
        public Lab7BListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Lab7BItemDatabase database = await Lab7BItemDatabase.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lab7BItemPage
            {
                BindingContext = new Lab7BItem()
            });
        }
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Lab7BItemPage
                {
                    BindingContext = e.SelectedItem as Lab7BItem
                });
            }
        }
    }
}