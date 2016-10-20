using BlueCaiCms.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCaiCms.Data.EF
{
    public class BCDbContext: DbContext
    {
        public BCDbContext()
        {
        }

        public DbSet<Class> Classes { get; set; }
        
        public DbSet<Student> Students { get; set; }
    }
}
