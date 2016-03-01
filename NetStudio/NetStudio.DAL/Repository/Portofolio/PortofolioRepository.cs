using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.DAL.Repository.Portofolio
{
    public class PortofolioRepository : IPortofolioRepository
    {
        private NetStudio.DAL.NetStudioContext.NetStudioContext db = null;


        public PortofolioRepository()
        {
            db = new NetStudio.DAL.NetStudioContext.NetStudioContext();
        }
        public PortofolioRepository(NetStudio.DAL.NetStudioContext.NetStudioContext ctx)
        {
            this.db = ctx;
        }

        public List<NetStudio.Model.Portofolio> GetAll()
        {
            return db.Portofolio.ToList();
        }
    }
}
