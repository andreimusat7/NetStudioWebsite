using NetStudio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.DAL.Repository.Category
{
    public interface ICategoryRepository
    {
        List<CategoryDef> GetAll();
    }
}
