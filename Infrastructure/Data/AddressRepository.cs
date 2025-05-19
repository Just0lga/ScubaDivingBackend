using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;
        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAddress(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddress(Address address)
        {
             _context.Remove(address);
            await _context.SaveChangesAsync();
        }

        public async Task<Address> GetAddress(string userId, int addressId)
        {
            return await _context.Addresses.FirstOrDefaultAsync(b => b.UserId == userId && b.Id == addressId);
        }

        public async Task<IReadOnlyList<Address>> GetAllAddresses(string userId)
        {
            return await _context.Addresses.Where(b => b.UserId == userId).ToListAsync(); ;
        }

        public async Task UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }
    }
}
