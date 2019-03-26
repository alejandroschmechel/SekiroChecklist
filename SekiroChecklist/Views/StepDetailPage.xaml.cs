using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SekiroChecklist.Models;
using SekiroChecklist.ViewModels;

namespace SekiroChecklist.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public StepDetailPage(Step step)
        {
            InitializeComponent();

            BindingContext = step;
        }
    }
}