using System;
using Xamarin.Forms;
using TodoREST.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using TodoREST.ViewModel;


namespace TodoREST
{
	public partial class TodoListPage : ContentPage

	{

		public List<Genre> GenreList { get; set; }
        public List<Concert> ConcertList { get; set; }

        public TodoListPage ()
		{
			InitializeComponent ();
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			listView.ItemsSource = await App.ConcertManager.GetTasksAsync();
            GenreList = new List<Genre>();
            ConcertList = new List<Concert>();

            foreach (Concert item in listView.ItemsSource)
            {
                ConcertList.Add(item);
                foreach (Genre g in item.Genres)
                {
                    GenreList.Add(g);
                }
            }
            GenreList.Distinct().ToList();

          

        }



		async void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
            await Navigation.PushAsync(new TodoItemPage(e.SelectedItem as Concert)
            {
                //BindingContext = e.SelectedItem as Concert
            });
		}

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string genre = genrePicker.SelectedItem.ToString();
            List<Concert> filteredConcerts = new List<Concert> ();

            if (genre == "ALL") 
            {
                listView.ItemsSource = ConcertList;
                return;
            }

            foreach (var item in ConcertList)
            {
                foreach(var g in item.Genres)
                {
                    if (g.Title == genre)
                    {
                        filteredConcerts.Add(item);
                    }
                }
            }
            listView.ItemsSource = filteredConcerts;
        }
    }
}
