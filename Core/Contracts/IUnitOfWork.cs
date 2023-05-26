namespace Core.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable, IDisposable
    {
        public IRestaurantRepository Restaurants { get; }
        public IRestaurantTableRepository RestaurantTables { get; }
        public IOpeningTimeRepository OpeningTimes { get; }
        public IRestaurantCategoryRepository RestaurantCategories { get; }
        public IZipCodeRepository ZipCodes { get; }
        public ICustomerRepository Customers { get; }
        public IEmployeeRepository Employees { get; }
        public IPersonRepository Persons { get; }
        public IReservationRepository Reservations { get; }


        Task<int> SaveChangesAsync();
    }
}
