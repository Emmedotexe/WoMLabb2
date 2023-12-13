using TodoREST.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoREST
{
	public class App : Application
	{
		public static TodoItemManager TodoManager { get; private set; }
		public static ConcertManager ConcertManager { get; private set; }

		public App ()
		{
			ConcertManager = new ConcertManager (new RestService());
			TodoManager = new TodoItemManager (new RestService ());
			MainPage = new NavigationPage (new TodoListPage ());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

