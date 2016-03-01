using NetStudio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.DAL.NetStudioContext
{
    public class NetStudioContext : DbContext
    {
        static NetStudioContext()
        {
            Database.SetInitializer(new NetStudioInitializer());
        }
        public NetStudioContext()
            : base("DbConnectionLive")
        {
            //Database.SetInitializer(new NetStudioInitializer());
            //Database.Initialize(true); 
        }


        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<CategoryDef> CategoryDef { get; set; }
        public virtual DbSet<CategoryPost> CategoryPost { get; set; }

        public virtual DbSet<Portofolio> Portofolio { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }
}
