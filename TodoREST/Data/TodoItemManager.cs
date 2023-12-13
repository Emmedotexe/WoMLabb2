using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoREST.Models;

namespace TodoREST
{
	public class TodoItemManager
	{
		IRestService restService;

		public TodoItemManager (IRestService service)
		{
			restService = service;
		}

		public Task<List<Concert>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}

		public Task SaveTaskAsync (Concert item, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync (item, isNewItem);
		}

		public Task DeleteTaskAsync (Concert item)
		{
			return restService.DeleteTodoItemAsync (item.ID);
		}
	}
}
