using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IReservationRepository
    {
        Task<Reservation?> GetReservationById(int id);
        Task<IEnumerable<Reservation>> GetReservationsByCustomer(int customerId);
        Task<IEnumerable<Reservation>> GetReservationsByRestaurant(int restaurantId);
        void InsertReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
        Task Save();
    }
}
