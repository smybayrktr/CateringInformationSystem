using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class CateringISContext:IdentityDbContext<User,UserRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
              Server=localhost,1433;
              Initial Catalog=CateringDB;
              User Id=sa;
              Password=Abc12345678+");
      
        }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<UserDeposit> UserDeposits { get; set; }
        public DbSet<UserFeedback> UserFeedbacks { get; set; }
        public DbSet<UserReservation> UserReservations { get; set; }
        public DbSet<UserSupportRequest> UserSupportRequests { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    }
}