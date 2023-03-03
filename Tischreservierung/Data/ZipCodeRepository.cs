using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Contracts;

namespace Tischreservierung.Data
{

    public class ZipCodeRepository : IZipCodeRepository
    {

        private readonly OnlineReservationContext _context;

        public ZipCodeRepository(OnlineReservationContext context)
        {
            _context = context;
        }

        public Task<List<ZipCode>> GetByDistrict(string district)
        {
            return _context.Zipcodes.Where(z => z.District.ToUpper() == district.ToUpper()).ToListAsync();
        }

        public Task<List<ZipCode>> GetByLocation(string location)
        {
            return _context.Zipcodes.Where(z => z.Location == location).ToListAsync();
        }

        public async Task<List<ZipCode>> GetByZipCode(string zipcode)
        {
            return await _context.Zipcodes.Where(z => z.ZipCodeNr == zipcode).ToListAsync();
        }

        public async Task<ZipCode?> GetByZipCodeAndLocation(string zipcode, string location)
        {
            return await _context.Zipcodes.Where(z => z.ZipCodeNr == zipcode && z.Location == location)
                .FirstOrDefaultAsync();
        }

        public Task<List<ZipCode>> GetZipCodes()
        {
            return _context.Zipcodes.ToListAsync();
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

    }
}
