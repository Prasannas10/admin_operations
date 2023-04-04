using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace adminoperation.Models
{
 

  
        public class ApplicationDbContext : DbContext
        {
        /*    public ApplicationDbContext() : base("DefaultConnection")
            {
            }*/

            public DbSet<Product> Products { get; set; }
        }
    

}