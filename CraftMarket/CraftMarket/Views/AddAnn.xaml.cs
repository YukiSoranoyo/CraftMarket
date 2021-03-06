using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CraftMarket.Models;
using System.IO;
using Xamarin.Essentials;

namespace CraftMarket.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class AddAnn : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadAnn(value);
            }
        }

        private async void LoadAnn(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);
                Announcement ann = await App.AnnDB.GetAnnAsync(id);
                BindingContext = ann;
            }
            catch
            {

            }
        }
        public AddAnn()
        {
            InitializeComponent();
            BindingContext = new Announcement();
        }
        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            Announcement ann = (Announcement)BindingContext;
            if (!string.IsNullOrWhiteSpace(ann.Name) && !string.IsNullOrWhiteSpace(ann.Description) && !string.IsNullOrWhiteSpace(ann.Address) &&
                !string.IsNullOrWhiteSpace(ann.Price) && !string.IsNullOrWhiteSpace(ann.ImageName))
            {
                await App.AnnDB.SaveAnnAsync(ann);
            }
        }
        async void btnGetAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                image.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        async void btnTakeAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });
                var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);
                image.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            Announcement ann = (Announcement)BindingContext;
            await App.AnnDB.DeleteAnnAsync(ann);
        }
    }
}