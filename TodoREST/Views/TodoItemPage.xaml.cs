using System;
using Xamarin.Forms;
using TodoREST.Models;
using TodoREST.ViewModel;
using System.Collections.Generic;
using TodoREST.Views;

namespace TodoREST
{
	public partial class TodoItemPage : ContentPage
	{
		public Concert Concert;
		private string desription;

        public TodoItemPage (Concert concert)
		{
			InitializeComponent ();
			this.Concert = concert;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			listView.ItemsSource = FilterShows(await App.ConcertManager.GetShowAsync());
			
        }

		private List<Show> FilterShows(List<Show> allShows)
		{
			List<Show> filtered = new List<Show>();
			foreach (Show show in allShows)
			{
				if (this.Concert.ID == show.ConcertToShow.ID)
				{
					filtered.Add(show);
					desription = show.ConcertToShow.Description;
				}
			}
			return filtered;
		}

            //async void OnSaveButtonClicked (object sender, EventArgs e)
            //{
            //	var todoItem = (Concert)BindingContext;
            //	await App.TodoManager.SaveTaskAsync (todoItem, isNewItem);
            //	await Navigation.PopAsync ();
            //}

            async void OnDeleteButtonClicked (object sender, EventArgs e)
		{
			var todoItem = (Concert)BindingContext;
			await App.TodoManager.DeleteTaskAsync (todoItem);
			await Navigation.PopAsync ();
		}

		async void OnCancelButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PopAsync ();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e) 
		{ 
        
			DetailsView.IsVisible = true;
			infoBox.Text = desription;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
			DetailsView.IsVisible = false;
        }

        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new BookingPage(e.SelectedItem as Show)
            {
                //BindingContext = e.SelectedItem as Concert
            });
        }
    }
}
