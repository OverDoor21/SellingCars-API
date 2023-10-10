using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ILotRepository
    {
        Task<IEnumerable<UserlotDTO>> GetUsersLotsAscync();
        Task<UserlotDTO>GetUserslotbyNameAscync(string NameLot);
        Task<IEnumerable<Lot>>GetLotsAsync();
        Task<Lot>GetLotByLotnameAsync(string Lotname);
        

    }
}