using BlazorTimes.Shared.Models.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTimes.Server.Data
{
    public class TimesDbContext:DbContext
    {
        public TimesDbContext(DbContextOptions<TimesDbContext> options):base(options)
        {
           
        }
        public DbSet<RunTime> Times { get; set; }
    }
}
