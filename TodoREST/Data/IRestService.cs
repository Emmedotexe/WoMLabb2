using System.Collections.Generic;
using System.Threading.Tasks;
using TodoREST.Models;

namespace TodoREST
{
	public interface IRestService
	{
		Task<List<Concert>> RefreshDataAsync ();
        Task<List<Show>> RefreshShowAsync();

        Task SaveTodoItemAsync (Concert item, bool isNewItem);
        Task SaveBookingItemAsync(Booking booking);

        Task DeleteTodoItemAsync (int id);
	}
}
