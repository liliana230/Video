using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Video
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageVideo : ContentPage
    {
        public PageVideo()
        {
            InitializeComponent();
        }

        private async void Vervideo_Clicked(object sender, EventArgs e)
        {
            var listav = new Lista();
            await Navigation.PushAsync(listav);
        }

        private async void agvideo_Clicked(object sender, EventArgs e)
        {
            var video = new VideoV();

            await Navigation.PushAsync(video);
        }
    }
}