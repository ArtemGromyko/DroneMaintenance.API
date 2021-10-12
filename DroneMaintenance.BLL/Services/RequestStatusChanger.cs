using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class RequestStatusChanger : BackgroundService
    {
        private readonly IServiceProvider _sp;

        public RequestStatusChanger(IServiceProvider sp)
        {
            _sp = sp;
        }

        public async Task UpdateRequestStatusAsync(CancellationToken stoppingToken)
        {
            if(stoppingToken.IsCancellationRequested)
            {
                return;
            }

            using var scope = _sp.CreateScope();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(configuration["SparePartsOrders.API:url"])) 
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var orders = JsonConvert.DeserializeObject<List<OrderDto>>(res);
                    var requestRepository = scope.ServiceProvider.GetRequiredService<IServiceRequestRepository>();
                    await requestRepository.UpdateRequestStatusesAsync(orders.Select(o => o.RequestId).ToList());
                    Console.WriteLine(res);
                }
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await UpdateRequestStatusAsync(stoppingToken);
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
