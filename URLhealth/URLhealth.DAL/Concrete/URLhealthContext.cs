using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.Entities.Concrete;

namespace URLhealth.DAL.Concrete
{
    public class URLhealthContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=xxx.xxx.xxx.xxx; Database=xxx;Persist Security Info = True;User ID=xxx;Password=xxxxConnect Timeout=30;MultipleActiveResultSets=true;Max Pool Size=999;Pooling=true;");


            optionsBuilder.UseSqlServer(@"Server=.; Database=URLhealthDB;Trusted_Connection=true; MultipleActiveResultSets=true");

        }
        public DbSet<LOGS> Logs { get; set; }
        public DbSet<USERS> Users { get; set; }
        public DbSet<URL> Url { get; set; }
    }
}
