using System;
using Xamarin.Forms;
using TodoREST.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace TodoREST
{
	public partial class TodoListPage : ContentPage

	{
		public ObservableCollection<Concert> ConcertList { get; set; }
        public ObservableCollection<Genre> GenreList { get; set; }

        public TodoListPage ()
		{
			InitializeComponent ();
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			listView.ItemsSource = await App.ConcertManager.GetTasksAsync();
			ConcertList = new ObservableCollection<Concert>();

			foreach (Concert item in listView.ItemsSource)
			{
				ConcertList.Add(item);
			}
		}

		async void OnAddItemClicked (object sender, EventArgs e)
		{
            await Navigation.PushAsync(new TodoItemPage(true)
            {
                BindingContext = new TodoItem
                {
                    ID = Guid.NewGuid().ToString()
                }
            });
		}

		async void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = e.SelectedItem as TodoItem
            });
		}

        
    }
}
