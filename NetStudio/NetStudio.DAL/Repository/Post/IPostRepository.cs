using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetStudio.Model;

namespace NetStudio.DAL.Repository.Post
{
    public interface IPostRepository
    {
        List<NetStudio.Model.Post> GetAll();
    }
}
