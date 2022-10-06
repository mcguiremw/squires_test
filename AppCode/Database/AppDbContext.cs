﻿using Microsoft.EntityFrameworkCore;

namespace AppCode.Database
{
    
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(
            DbContextOptions<AppDbContext> options
        ) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
