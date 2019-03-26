using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SekiroChecklist.Views;
using System.Collections.Generic;
using SekiroChecklist.Models;
using Newtonsoft.Json;
using Plugin.Settings.Abstractions;
using Plugin.Settings;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SekiroChecklist
{
    public partial class App : Application
    {
        private static ISettings AppSettings =>
            CrossSettings.Current;

        public static List<Item> SavedContext
        {
            get
            {
                List<Item> bus = null;
                var serializedBus = AppSettings.GetValueOrDefault(nameof(SavedContext), string.Empty); ;
                if (serializedBus != null)
                {
                    bus = JsonConvert.DeserializeObject<List<Item>>(serializedBus);
                }

                return bus;
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(SavedContext), JsonConvert.SerializeObject(value));
            }
        }

        public App ()
        {
            InitializeComponent();


            MainPage = new MainPage();
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}
