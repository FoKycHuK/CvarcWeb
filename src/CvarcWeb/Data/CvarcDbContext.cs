using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CvarcWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CvarcWeb.Data
{
    public class CvarcDbContext : DbContext
    {
        public CvarcDbContext(DbContextOptions<CvarcDbContext> options)
            : base(options)
        {
        }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<CommandGameResult> CommandGameResults { get; set; }
    }
}
