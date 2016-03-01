using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudio.Model.Email
{
    public class ContactFormModel
    {
        [Required, Display(Name = "Name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Phone"), Phone]
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
