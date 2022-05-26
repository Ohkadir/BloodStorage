using BloodStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodStorage.Data
{
    public class DBContext : DbContext
    {
       
        public DBContext(DbContextOptions<DBContext> options) : base(options)
            {

            }

            public DbSet<Doctor> Doctors { get; set; }
           public DbSet<Patient> Patients { get; set; }


    }

    
}
