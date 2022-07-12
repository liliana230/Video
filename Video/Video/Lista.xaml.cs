using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Video
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        public List<Cvideo> AllVideos { get; set; }
        string ubiVideo;
        public Lista()
        {
            InitializeComponent();
        }

        private void ListaV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(e.PreviousSelection, e.CurrentSelection);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            VideoList();
        }

        private async void VideoList()
        {
            AllVideos = await App.BaseDatos.GetVideosLista();
            ListaV.ItemsSource = AllVideos;
        }


        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            SwipeItem Vvideo = sender as SwipeItem;
            Cvideo videito = (Cvideo)Vvideo.BindingContext;
            await Navigation.PushAsync(new VerVideo(videito.pathVideo));
          //  ubiVideo = null;
        }

        private async void UpdateData(IEnumerable<object> previousSelectedContact, IEnumerable<object> Video)
        {
            var Svideo = Video.FirstOrDefault() as Cvideo;
            await DisplayAlert("Titulo", "Ruta Seleccionada:" + Svideo.pathVideo, "OK");
            ubiVideo = Svideo.pathVideo;
            Console.WriteLine(ubiVideo); 
           
        }
    }
}