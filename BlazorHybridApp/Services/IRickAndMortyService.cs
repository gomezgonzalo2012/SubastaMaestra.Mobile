using BlazorHybridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridApp.Services
{
    public interface IRickAndMortyService
    {
        public Task<RickAndMorty> GetRickAndMortyAsync();
    }
}
