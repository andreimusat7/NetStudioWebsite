using NetStudio.Model.PortofolioItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.Model.Email
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Phone"), Phone]
        public string Phone { get; set; }
        [Display(Name = "Domain name")]
        public string DomainName { get; set; }

        [Display(Name = "Website domain activity/Company profile")]
        public string DomainActivity { get; set; }
        [Display(Name = "Some websites that you like and that fits your profile")]
        public string LikedWebsites { get; set; }

        public virtual ServiceDD Service { get; set; }

        public bool WebSiteCreation { get; set; }
        public bool WebSiteRedesign { get; set; }
        public bool WebSiteOptimisation { get; set; }
        public bool WebSitePromoting { get; set; }
        public bool WebSiteAdministration { get; set; }

        public string Message { get; set; }
        public ICollection<ServiceType> ServiceTypes { get; set; }
    }

    public class ServiceDD
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}