using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage : ContentPage
    {
        private Show show;
        public BookingPage(Show show)
        {
            InitializeComponent();
            this.show = show;
            BindingContext = new Booking()
            {
                BookedShow = show
                
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            concertLabel.Text = show.ConcertToShow.Titel;
            showDate.Text = show.Date.ToString("dddd, dd MMMM yyyy");
            showLocation.Text = show.Location;
            showPrice.Text = show.ConcertToShow.Price.ToString();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var booking = (Booking)BindingContext;
            await App.ConcertManager.SaveTaskAsync(booking);
            await Navigation.PopAsync();

        }
    }
}