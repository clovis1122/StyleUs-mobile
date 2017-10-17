using System;
using System.Threading.Tasks;

namespace StyleUs.Services
{
    public interface IApiService
    {
        Task<Models.User> GetUser();
        Task<Models.Notification> GetNotification();
    }
}
