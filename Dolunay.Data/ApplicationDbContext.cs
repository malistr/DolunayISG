using Dolunay.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolunay.Data
{
	public class ApplicationDbContext: DbContext
	{
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }

        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

    }
}
