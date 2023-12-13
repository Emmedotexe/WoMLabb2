using System.Collections.Generic;
using System.Threading.Tasks;
using TodoREST.Models;

namespace TodoREST
{
	public interface IRestService
	{
		Task<List<Concert>> RefreshDataAsync ();

		Task SaveTodoItemAsync (Concert item, bool isNewItem);

		Task DeleteTodoItemAsync (int id);
	}
}
