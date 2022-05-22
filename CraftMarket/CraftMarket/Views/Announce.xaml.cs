using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CraftMarket.Models;

namespace CraftMarket.Views
{
    public partial class Announce : ContentPage
    {
        public Announce()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            CollectionView.ItemsSource = await App.AnnDB.GetAnnsAsync();
            base.OnAppearing();
        }
        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Announcement ann = (Announcement)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(AddAnn)}?" +
                    $"{nameof(AddAnn.ItemId)}*{ann.ID.ToString()}");
            }
        }
    }
}