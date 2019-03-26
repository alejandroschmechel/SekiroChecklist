using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SekiroChecklist.Views;
using System.Collections.Generic;
using SekiroChecklist.Models;
using Plugin.Settings.Abstractions;
using Plugin.Settings;
using SekiroChecklist.Repositories;
using System.IO;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SekiroChecklist
{
    public partial class App : Application
    {
        static ItemsRepository ItemsRepo;

        private static ISettings AppSettings =>
            CrossSettings.Current;

        public static ItemsRepository Database
        {
            get
            {
                if (ItemsRepo == null)
                {
                    ItemsRepo = new ItemsRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SekiroChecklist.db3"));
                }
                return ItemsRepo;
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
