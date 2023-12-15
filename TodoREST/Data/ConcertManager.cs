using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Models;

namespace TodoREST.Data
{
    public class ConcertManager
    {
        IRestService restService;

        public ConcertManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Concert>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task<List<Show>> GetShowAsync()
        {
            return restService.RefreshShowAsync();
        }

        public Task SaveTaskAsync(Concert item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }

        public Task DeleteTaskAsync(Concert item)
        {
            return restService.DeleteTodoItemAsync(item.ID);
        }
    }
}
