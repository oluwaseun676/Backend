using Core.Contracts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly OnlineReservationContext _context;

        public ReservationRepository(OnlineReservationContext context)
        {
            _context = context;
        }

        public void DeleteReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
        }

        public async Task<Reservation?> GetReservationById(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByCustomer(int customerId)
        {
            return await _context.Reservations.Where(r => r.CustomerId == customerId).ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByRestaurant(int restaurantId)
        {
            return await _context.Reservations.Where(r => r.RestaurantId == restaurantId).ToListAsync();
        }

        public void InsertReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
