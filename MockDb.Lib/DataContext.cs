﻿using Microsoft.EntityFrameworkCore;

namespace MockDb.Lib
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            // Nothing to do here
        }
    }
}