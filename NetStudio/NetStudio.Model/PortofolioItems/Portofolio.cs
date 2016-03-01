using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.Model
{
    public class Portofolio
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public string Thumb { get; set; }
        public string BigImg { get; set; }
        public string Price { get; set; }
        public int Sales { get; set; }
        public int Category { get; set; }
        public string CategoryTitle { get; set; }
    }
}
