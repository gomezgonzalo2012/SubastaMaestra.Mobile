using BlazorHybridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorHybridApp.Services
{
    public class RickAndMortyService : IRickAndMortyService
    {
        const string URL = "https://rickandmortyapi.com/api/character";
        public async Task<RickAndMorty> GetRickAndMortyAsync()
        {
            HttpClient client = new HttpClient();
            var response = await  client.GetAsync(URL);
            var content = await response.Content.ReadAsStringAsync();
            var rickAndMortyObject = JsonSerializer.Deserialize<RickAndMorty>(content);
            return rickAndMortyObject;
        }
    }
}
