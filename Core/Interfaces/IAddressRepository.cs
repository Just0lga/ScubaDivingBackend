using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAddressRepository
    {
        Task CreateAddress(Address address);
        Task DeleteAddress(Address address);
        Task<IReadOnlyList<Address>> GetAllAddresses(string userId);
        Task<Address> GetAddress(string userId, int addressId);            
        Task UpdateAddress(Address address);
    }
}
