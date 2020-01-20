using Microsoft.EntityFrameworkCore;
using MnistRecognizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MnistRecognizer.Modules.Database
{
    public class Db : DbContext
    {
        public const string connection_string = @"Server=(localdb)\mssqllocaldb;Database=MnistRecognizer;Trusted_Connection=True;ConnectRetryCount=0";

        public Db(DbContextOptions<Db> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connection_string);
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<HistoryModel> History { get; set; }
        public DbSet<NetworkModel> Networks { get; set; }
        public DbSet<Layer> Layers { get; set; }
    }
}
