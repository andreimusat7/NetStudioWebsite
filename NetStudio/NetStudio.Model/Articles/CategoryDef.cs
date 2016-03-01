using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.Model
{
    public class CategoryDef
    {

        public CategoryDef()
        {
            CategoryPosts = new HashSet<CategoryPost>();
        }
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }


        public virtual ICollection<CategoryPost> CategoryPosts { get; set; }
    }
}
