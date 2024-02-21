using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TVApi.Model;

namespace TVApi.DataLayer
{
    public class TVDbContext : DbContext
    {
        //internal object Users;

        public TVDbContext(DbContextOptions<TVDbContext> options) : base(options)
        {

        }

        public DbSet<TV> TVs { get; set; }
        // Add other DbSets as needed

    }
}
