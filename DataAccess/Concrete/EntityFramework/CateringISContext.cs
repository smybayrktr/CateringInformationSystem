using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class CateringISContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;
                 Database=CateringISDb; Trusted_Connection=true");
      
        }
        public DbSet<Deposit> Deposits { get; set; } 
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<UserDeposit> UserDeposits { get; set; }
        public DbSet<UserFeedback> UserFeedbacks { get; set; }
        public DbSet<UserReservation> UserReservations { get; set; }
        public DbSet<UserSupportRequest> UserSupportRequests { get; set; }
        
        
    }
}