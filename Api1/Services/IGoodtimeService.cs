using System.Collections.Generic;
using System.Threading.Tasks;
using GoodtimeApi.Models;

namespace GoodtimeApi.Services
{
    /// <summary>
    /// Represents the set of methods for Foo manipulation.
    /// </summary>
    public interface IGoodtimeService
    {
        void SetConnectionString(string mysqlConStr);

        /// <summary>
        /// Tries to retrieve all Bar objects.
        /// </summary>
        /// <returns>A collection of Bar objects (collection might be empty, but never null).</returns>
        Task<IEnumerable<Bar>> GetAllBars();

        /// <summary>
        /// Tries to retrieve specified Bar object if exists.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns>A <see cref="Bar"/> object, or null.</returns>
        Task<Bar> GetBar(int id);

        /// <summary>
        /// Tries to retrieve specified reservations for a bar.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns>A <see cref="Reservations"/> object, or null.</returns>
        Task<Reservations> GetReservations(int id);

        /// <summary>
        /// Tries to retrieve all menu items for a bar.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns>A <see cref="Reservations"/> object, or null.</returns>
        Task<IEnumerable<MenuItem>> GetMenu(int id);

        /// <summary>
        /// Tries to insert a MenuItem.
        /// </summary>
        /// <param name="item"> MenuItem.</param>
        void CreateMenuItem(MenuItem item, int id);

        /// <summary>
        /// Tries to insert a reservation.
        /// </summary>
        /// <param name="item"> Reservation.</param>
        void CreateReservation(Reservation item, int id, int user_id);

        /// <summary>
        /// refuse a reservation.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        void AcceptEvent(int id);

        /// <summary>
        /// Accept a reservation.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        void RefuseEvent(int id);

        /// <summary>
        /// Delete a menuItem.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        void DeleteMenuItem(int id);
    }
}