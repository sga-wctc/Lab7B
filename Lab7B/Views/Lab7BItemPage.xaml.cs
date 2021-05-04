using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab7B
{
    public partial class Lab7BItemPage : ContentPage
    {
        public Lab7BItemPage()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (Lab7BItem)BindingContext;
            Lab7BItemDatabase database = await Lab7BItemDatabase.Instance;
            await database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (Lab7BItem)BindingContext;
            Lab7BItemDatabase database = await Lab7BItemDatabase.Instance;
            await database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}