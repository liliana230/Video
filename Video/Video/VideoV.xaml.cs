using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Models;
using SQLite;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Video.Controller;

namespace Video
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoV : ContentPage
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Video.db3");
        string ruta;
        public VideoV()
        {
            InitializeComponent();
        }

        private  async void btnguardar_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteAsyncConnection(dbPath);

            var video = new Cvideo
            {
                pathVideo = ruta
            };

            var result = await App.BaseDatos.GuardarVideo(video);
            if (result == 1)
              {
                await DisplayAlert("Grabacion", "Video Guardado", "OK");
                await Navigation.PopAsync();
              }
        }

        private  async void btnGvideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Camara", "No Se Detecta La Camara.", "Ok");
                    return;
                }

                var video = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    Name = "video.mp4",
                    Directory = "MisVideos",
                });

                if (video == null)
                    return;

                await DisplayAlert("Video Grabado", "Ubicacion: " + video.Path, "OK");
                ruta = video.Path;
              video.Dispose();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Permiso Denegado", "Dar Permisos A La Cámara Del Dispositivo.\nError: " + ex.Message, "Ok");
            }
        }

    }
}