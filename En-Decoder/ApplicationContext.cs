﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using En_Decoder;
using Microsoft.EntityFrameworkCore;

namespace TestDB
{
    public class ApplicationContext : DbContext
    { 
        public DbSet<Users> Users { get; set; } = null!;

        public DbSet<ChatRooms> ChatRooms { get; set; } = null!;

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP\SQLSERVER;Database=En-DecoderBD;Trusted_Connection=True;");
        }
    }
}
