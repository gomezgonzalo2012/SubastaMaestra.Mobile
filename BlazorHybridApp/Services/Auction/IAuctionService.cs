using BlazorHybridApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridApp.Services.Auction
{
    public interface IAuctionService
    {
        Task<List<AuctionDTO>> GetAll();
        Task<AuctionDTO> GetByIdAsync(int id);
        Task<List<AuctionDTO>> GetAllResults();
    }
}
