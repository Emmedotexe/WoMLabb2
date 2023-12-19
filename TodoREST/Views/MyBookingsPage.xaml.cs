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
    public partial class MyBookingsPage : ContentPage
    {
        Booking booking; 
        public MyBookingsPage()
        {
            InitializeComponent();


        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            notFoundError.IsVisible = false;
            
            booking = await App.ConcertManager.FindBookingAsync(int.Parse(searchId.Text));
            
            if(booking.CustomerName == null)
            { 
                notFoundError.Text = "Booking not found";
                notFoundError.IsVisible = true;
                bName.Text = "";
                bMail.Text = "";
                concertLabel.Text = "";
                showDate.Text = "";
                showLocation.Text = "";
                showPrice.Text = "";
                return; 
            }
            bName.Text = booking.CustomerName;
            bMail.Text = booking.CustomerMail;
            concertLabel.Text = booking.BookedShow.ConcertToShow.Titel;
            showDate.Text = booking.BookedShow.Date.ToString("dddd, dd MMMM yyyy");
            showLocation.Text = booking.BookedShow.Location;
            showPrice.Text = booking.BookedShow.ConcertToShow.Price.ToString();
        }
    }
}