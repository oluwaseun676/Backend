using Core.Models;
using Core.Contracts;

namespace Persistence.Data.RestaurantRepo
{
    public class RestaurantCategoryRepository : GenericRepository<Category>, IRestaurantCategoryRepository
    {

        public RestaurantCategoryRepository(OnlineReservationContext context) : base(context)
        {
            
        }
    }
}
