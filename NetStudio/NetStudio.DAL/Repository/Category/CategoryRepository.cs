using NetStudio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.DAL.Repository.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private NetStudio.DAL.NetStudioContext.NetStudioContext db = null;


        public CategoryRepository()
        {
            db = new NetStudio.DAL.NetStudioContext.NetStudioContext();
        }
        public CategoryRepository(NetStudio.DAL.NetStudioContext.NetStudioContext ctx)
        {
            this.db = ctx;
        }

        public List<CategoryDef> GetAll()
        {
            return db.CategoryDef.ToList();
        }
    }
}
