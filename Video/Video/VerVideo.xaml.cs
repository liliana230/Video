using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Video
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerVideo : ContentPage
    {
        public VerVideo( String pathvideo)
        {
            InitializeComponent();
            UriVideoSource urivideo = new UriVideoSource()
            {
                Uri = pathvideo
            };
            videop.Source = urivideo;
        }

           
        private async void Cerrar_Clicked(object sender, EventArgs e)
        {
            videop.Pause();
            await Navigation.PopAsync();
        }

        private void videop_PlayCompletion(object sender, EventArgs e)
        {

        }
    }
}