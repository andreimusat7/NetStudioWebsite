using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.DAL.Repository.Post
{
    public class PostRepository : IPostRepository
    {
        private NetStudio.DAL.NetStudioContext.NetStudioContext db = null;


        public PostRepository()
        {
            db = new NetStudio.DAL.NetStudioContext.NetStudioContext();
        }
        public PostRepository(NetStudio.DAL.NetStudioContext.NetStudioContext ctx)
        {
            this.db = ctx;
        }

        public List<NetStudio.Model.Post> GetAll()
        {
            return db.Post.ToList();
        }
    }
}
