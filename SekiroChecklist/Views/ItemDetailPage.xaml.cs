using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SekiroChecklist.Models;
using SekiroChecklist.ViewModels;
using SekiroChecklist.Services;

namespace SekiroChecklist.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Step it = (Step)e.Item;
            Navigation.PushAsync(new StepDetailPage(it));
        }

        void Handle_Toggled(object sender, EventArgs e)
        {
            Step it = (sender as Switch).Parent.BindingContext as Step;
            App.Database.SaveStep(it);
        }
    }
}