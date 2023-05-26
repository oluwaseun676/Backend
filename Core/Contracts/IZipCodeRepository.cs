using Core.Models;

namespace Core.Contracts
{
    public interface IZipCodeRepository : IGenericRepository<ZipCode>
    {
        Task<List<ZipCode>> GetByLocation(string location);
        Task<List<ZipCode>> GetByZipCode(string zipcode);
        Task<List<ZipCode>> GetByDistrict(string district);
        Task<ZipCode?> GetByZipCodeAndLocation(string zipcode, string location);

    }
}
