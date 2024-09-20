using AeroPortManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace AeroPortManagment.Data
{
    public class AeroPortContext : DbContext
    {
        public AeroPortContext (DbContextOptions<AeroPortContext> options)
            : base (options)
        {

        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ResourceAllocation> ResourceAllocations { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<CommercialActivity> CommercialActivities { get; set; }
        public DbSet<RealTimeUpdate> RealTimeUpdates { get; set; }

    }
}
