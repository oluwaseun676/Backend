using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Contracts;

namespace Persistence.Data
{

    public class ZipCodeRepository : GenericRepository<ZipCode>, IZipCodeRepository
    {
        public ZipCodeRepository(OnlineReservationContext context) : base(context)
        {
        }

        public Task<List<ZipCode>> GetByDistrict(string district)
        {
            return _dbSet.Where(z => z.District.ToUpper() == district.ToUpper()).ToListAsync();
        }

        public Task<List<ZipCode>> GetByLocation(string location)
        {
            return _dbSet.Where(z => z.Location == location).ToListAsync();
        }

        public async Task<List<ZipCode>> GetByZipCode(string zipcode)
        {
            return await _dbSet.Where(z => z.ZipCodeNr == zipcode).ToListAsync();
        }

        public async Task<ZipCode?> GetByZipCodeAndLocation(string zipcode, string location)
        {
            return await _dbSet.Where(z => z.ZipCodeNr == zipcode && z.Location == location)
                .FirstOrDefaultAsync();
        }
    }
}
