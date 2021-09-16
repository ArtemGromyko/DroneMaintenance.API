using DroneMaintenance.BLL.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class RequestStatusChanger : IRequestStatusChanger
    {
        private readonly IServiceProvider _sp;

        public RequestStatusChanger(IServiceProvider sp)
        {
            _sp = sp;
        }

        public async Task UpdateRequestStatusAsync()
        {
            using var scope = _sp.CreateScope();
            using(var httpClient = new HttpClient())
            {

            }
        }
    }
}
