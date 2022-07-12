using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Video.Controller;
using System.IO;

namespace Video
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            // MainPage = new MainPage();
        }

        static BaseDatos database;
        public static BaseDatos BaseDatos
        {
            get
            {
                if (database == null)
                {
                    database = new BaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BaseDatos.db3"));
                }

                return database;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
