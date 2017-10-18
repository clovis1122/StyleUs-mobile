using System;
namespace StyleUs.Services
{
    public interface IApiResponse
    {
        int GetStatusCode();
        T GetResponseAsModel<T>();
    }
}
