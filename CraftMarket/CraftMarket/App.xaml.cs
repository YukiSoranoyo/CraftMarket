using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CraftMarket.Database;
using System.IO;

namespace CraftMarket
{
    public partial class App : Application
    {
        static AnnDB annDB;
        static LogDB logDB;
        public static AnnDB AnnDB
        {
            get
            {
                if (annDB == null)
                {
                    annDB = new AnnDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "AnnDatabase.db3"));
                }
                return annDB;
            }
        }
        public static LogDB LogDB
        {
            get
            {
                if (logDB == null)
                {
                    logDB = new LogDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "LogDatabase.db3"));
                }
                return logDB;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
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
