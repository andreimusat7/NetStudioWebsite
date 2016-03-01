using NetStudio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.DAL.NetStudioContext
{
    public class NetStudioInitializer : DropCreateDatabaseIfModelChanges<NetStudioContext>
    {
        protected override void Seed(NetStudioContext context)
        {
            var posts = new List<Post>
            {
            new Post{ Title = "SEO", Excerpt = "Totul despre SEO, Search engine optimization", Body="Body post" , Url = "totu despre SEO" , CreationDate = DateTime.Now },
            new Post{ Title = "HTML", Excerpt = "HTML 5", Body="Body post" , Url = "totu despre SEO" , CreationDate = DateTime.Now},
            new Post{ Title = "DOMENII", Excerpt = "Ce inseamna domain registration", Body="Body post" , Url = "totu despre SEO" , CreationDate = DateTime.Now},
            };
            posts.ForEach(s => context.Post.Add(s));

            var categories = new List<CategoryDef>
            {
            new CategoryDef{Title="SEO"},
            new CategoryDef{Title="Exchange"},
            new CategoryDef{Title="For Rent"}
            };
            categories.ForEach(s => context.CategoryDef.Add(s));
            context.SaveChanges();

            var catpost = new List<CategoryPost>
            {
            new CategoryPost{CategoryId = 1, PostId = 1},
            new CategoryPost{CategoryId = 2, PostId = 2},
            new CategoryPost{CategoryId = 3, PostId = 3},

            };
            catpost.ForEach(s => context.CategoryPost.Add(s));
            context.SaveChanges();

            //var entitytypes = new List<HW_Type>
            //{
            //new HW_Type{Title="Multifamily"},
            //new HW_Type{Title="Office"},
            //new HW_Type{Title="Industrial"},
            //new HW_Type{Title="Retail"},
            //new HW_Type{Title="Agricultural"},
            //new HW_Type{Title="Hotel"},
            //new HW_Type{Title="Senior Housing"},
            //new HW_Type{Title="Health Care"},
            //new HW_Type{Title="Sport & Entertainment"},
            //new HW_Type{Title="Special Purpose"},
            //new HW_Type{Title="Land"},
            //new HW_Type{Title="Residential Income"},
            //};
            //entitytypes.ForEach(s => context.HW_Type.Add(s));
            ////context.SaveChanges();

            //var entitytypesList = new List<HW_TypeList>
            //{
            //new HW_TypeList{ AssetsId = 1, TypeId = 1},
            //new HW_TypeList{ AssetsId = 2, TypeId = 2},
            //new HW_TypeList{ AssetsId = 3, TypeId = 3},
            //new HW_TypeList{ AssetsId = 4, TypeId = 4},
            //new HW_TypeList{ AssetsId = 5, TypeId = 5}
            //};
            //entitytypesList.ForEach(s => context.HW_TypeList.Add(s));
            ////context.SaveChanges();

            //var counties = new List<HW_County>
            //{
            //new HW_County{Title="Atlanta"},
            //new HW_County{Title="New York"},
            //new HW_County{Title="Virginia"},
            //new HW_County{Title="Colorado"},
            //new HW_County{Title="Florida"}
            //};
            //counties.ForEach(s => context.HW_County.Add(s));
            ////context.SaveChanges();

            //var countiesList = new List<HW_CountyList>
            //{
            //new HW_CountyList{ AssetsId = 1, CountyId = 1},
            //new HW_CountyList{ AssetsId = 2, CountyId = 2},
            //new HW_CountyList{ AssetsId = 3, CountyId = 3},
            //new HW_CountyList{ AssetsId = 4, CountyId = 4},
            //new HW_CountyList{ AssetsId = 5, CountyId = 5}
            //};
            //counties.ForEach(s => context.HW_County.Add(s));
            context.SaveChanges();
        }
    }
}
