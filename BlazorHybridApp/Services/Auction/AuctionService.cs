using BlazorHybridApp.Models.DTO;
using BlazorHybridApp.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridApp.Services.Auction
{
    public class AuctionService : IAuctionService
    {
        private readonly HttpClient _httpClient;

        
        public AuctionService(HttpClient http)
        {
            _httpClient = http;
        }
        public async Task<List<AuctionDTO>> GetAll()
        {
            try
            {
                //var apiUrl = DeviceInfo.Platform==DeviceInfo.Android ? ""
                var result = await _httpClient.GetFromJsonAsync<OperationResult<List<AuctionDTO>>>($"{ApiUrl.ServerURL}api/Auction/listOpen");
                if (result.Success)
                {
                    return result.Value;
                }
                throw new Exception(result.Message);

            }
            catch(Exception Ex)
            {
                
                Console.WriteLine("Mensaje desde consola: "+ Ex.ToString());
                return null;
            }
           
        }
        public async Task<List<AuctionDTO>> GetAllResults()
        {
            string state = "Closed";
            try
            {
                //var apiUrl = DeviceInfo.Platform==DeviceInfo.Android ? ""
                var result = await _httpClient.GetFromJsonAsync<OperationResult<List<AuctionDTO>>>($"{ApiUrl.ServerURL}api/Auction/listByState/{state}");
                if (result.Success)
                {
                    return result.Value;
                }
                throw new Exception(result.Message);

            }
            catch (Exception Ex)
            {

                Console.WriteLine("Mensaje desde consola: " + Ex.ToString());
                return null;
            }

        }

        public async Task<AuctionDTO> GetByIdAsync(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<OperationResult<AuctionDTO>>($"{ApiUrl.ServerURL}api/Auction/{id}");

            if (result.Success)
            {
                return result.Value;
            }
            throw new Exception(result.Message);
        }
    }
}
 