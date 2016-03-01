using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.Model
{
    public class CategoryPost
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryDef Category { get; set; }

        public virtual Post Post { get; set; }
    }
}
