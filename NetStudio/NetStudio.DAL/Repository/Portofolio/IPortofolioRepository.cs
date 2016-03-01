using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.DAL.Repository.Portofolio
{
    public interface IPortofolioRepository
    {
        List<NetStudio.Model.Portofolio> GetAll();
    }
}
