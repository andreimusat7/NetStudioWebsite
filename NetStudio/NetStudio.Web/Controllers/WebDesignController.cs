using NetStudio.DAL.Repository.Portofolio;
using NetStudio.DAL.Repository.Post;
using NetStudio.Model;
using NetStudio.Model.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TemplateMonsterAPI;
using TemplateMonsterAPI.Entity;
using PagedList;
using NetStudio.Model.PortofolioItems;

namespace NetStudio.Web.Controllers
{
    public class WebDesignController : Controller
    {
        static readonly IPostRepository _repository = new PostRepository();
        static readonly IPortofolioRepository _portofoliorepository = new PortofolioRepository();

        public ActionResult Index()
        {
            List<Portofolio> porto = new List<Portofolio>();
            porto = _portofoliorepository.GetAll().Where(x => x.Category == 83).Select(x => new Portofolio { CategoryTitle = x.CategoryTitle, BigImg = x.BigImg, Category = x.Category, ItemId = x.ItemId, Sales = x.Sales, Thumb = x.Thumb, Price = (Convert.ToInt32(x.Price) + 200).ToString() }).Take(200).ToList();

            ViewBag.porto = porto;
            return View(porto);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Message = "Blog";
            List<Post> posts = new List<Post>();
            posts = _repository.GetAll();
            ViewBag.Posts = posts;
            return View(posts);
        }

        public ActionResult Portofolio(int page = 1, int pageSize = 100)
        {
            ViewBag.Message = "Portofoliu";
            List<Portofolio> porto = new List<Portofolio>();
            porto = _portofoliorepository.GetAll().Where(x => x.Category == 83).ToList();
            porto = porto.Select(x => new Portofolio { CategoryTitle = x.CategoryTitle, BigImg = x.BigImg, Category = x.Category, ItemId = x.ItemId, Sales = x.Sales, Thumb = x.Thumb, Price = (Convert.ToInt32(x.Price) + 200).ToString() }).OrderByDescending(x => x.Sales).ThenByDescending(x => x.Id).ToList();
            ViewBag.porto = porto.ToPagedList(page, pageSize);
            return View(porto.ToPagedList(page, pageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("contact@NetStudioDesign.com"));  // replace with valid value 
                message.To.Add(new MailAddress("musatrares@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("musatrares@gmail.com");  // replace with valid value
                message.Subject = "Contact from contact@NetStudioDesign.com";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "musatrares@gmail.com",  // replace with valid value
                        Password = "123!@#asdASD"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult WebsiteQuoteEstimate()
        {
            EmailFormModel m = new EmailFormModel();
            ViewBag.Message = "Your contact page.";


            List<string> SelectService = new List<string>();

            // Add some elements to the dictionary. There are no 
            // duplicate keys, but some of the values are duplicates.
            SelectService.Add("Site de REZENTARE START - 299 €");
            SelectService.Add("Site de PREZENARE OPTIMUM - from 899 €");
            SelectService.Add("Site de PREZENTARE PREMIUM - from 1499 €");
            SelectService.Add("Magazin ONLINE START - from 299 €");
            SelectService.Add("Magazin ONLINE OPTIMUM - from 899 €");
            SelectService.Add("Magazin ONLINE PREMIUM - from 1499 €");
 
            ViewBag.selectService = new MultiSelectList(SelectService);

            var model = new[] 
            {
               new ServiceType { Id = 1, Name = "Website development" },
               new ServiceType { Id = 2, Name = "Website redesign" },
               new ServiceType { Id = 3, Name = "Website optimisation"},
               new ServiceType { Id = 4, Name = "Website promoting" },
               new ServiceType { Id = 5, Name = "Website maintenance" },
               new ServiceType { Id = 6, Name = "Other service"},
            };
            m.ServiceTypes = model;
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> WebsiteQuoteEstimate(EmailFormModel model)
        {
            string servicelist = "";
            if (ModelState.IsValid)
            {
                var body = "<table style='width:100%'>" +
                              "<tr><td>Name</td><td>{0}</td></tr>" +
                              "<tr><td>Email</td><td>{1}</td></tr>" +
                              "<tr><td>Domain of activity</td><td>{2}</td></tr>" +
                              "<tr><td>Domain name</td><td>{3}</td></tr>" +
                              "<tr><td>Liked websites</td><td>{4}</td></tr>" +
                              "<tr><td>Phone</td><td>{5}</td></tr>" +
                              "<tr><td>Website types</td><td>{6}</td></tr>" +
                              "<tr><td>Message</td><td>{7}</td></tr>" +
                              "<tr><td>Services</td><td>{8}</td></tr>" +
                            "</table>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("contact@NetStudioDesign.com"));  // replace with valid value 
                //message.To.Add = new MailAddress("musatrares@gmail.com");  // replace with valid value
                message.From = new MailAddress(model.FromEmail);  // replace with valid value
                message.Subject = "Price Appraisal";
                //foreach (var item in model.ServiceTypes) {
                //    if(item.Selected)
                //        servicelist = servicelist + item.Name.ToString();
                //}
                message.Body = string.Format(body,
                    model.FromName,
                    model.FromEmail,
                    model.DomainActivity,
                    model.DomainName,
                    model.LikedWebsites,
                    model.Phone,
                    model.Service,
                    model.Message,
                    model.ServiceTypes);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "musatrares@gmail.com",  // replace with valid value
                        Password = "123!@#asdASD"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Model()
        {
            var id = Request.RequestContext.RouteData.Values["id"];
            ViewBag.WebsiteId = id;
            //HtmlControl frame1 = (HtmlControl)this.FindControl("monster");
            //string ID = Request.QueryString["id"].ToString();
            //frame1.Attributes["src"] = "http://www.templatemonster.com/demo/" + ID + ".html";
            //frame1.Attributes.Add("height", "100%");
            //frame1.Attributes.Add("width", "100%");
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [Route("blog/{category}")]
        public ActionResult GetArticlesByCategory(string category)
        {
            ViewBag.Message = "Blog";
            List<Post> posts = new List<Post>();
            posts = _repository.GetAll();
            ViewBag.Posts = posts;

            return View(posts);
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
}