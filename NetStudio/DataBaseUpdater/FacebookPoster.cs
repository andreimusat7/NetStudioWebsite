using Facebook;
using NetStudio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemplateMonsterAPI;
using TemplateMonsterAPI.Entity;

namespace DataBaseUpdater
{
    public partial class FacebookPoster : Form
    {
        public FacebookPoster()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            var fb = new FacebookClient();
            //dynamic results = fb.Get("oauth/access_token", new
            //{
            //    client_id = "687230761409464",
            //    client_secret = "fcbdcc45b6c7ec512c2a8aa10bfc1c7d",
            //    grant_type = "client_credentials"
            //});

            //fb.AccessToken = results.access_token;

             ITemplateMonsterGateway gw = new TemplateMonsterGateway();

            IList<Currency> execute = gw.GetCurrencies().Execute();
            IList<Featured> featureds = gw.GetFeatured().Execute();
            IList<Screenshot> screenshots = gw.GetScreenshots().Category(83).StartId(50000).EndId(58000).Execute().OrderByDescending(x => x.Id).ToList();
            //IList<Screenshot> screenshots = gw.GetScreenshots().StartId(featureds[0].TemplateId - 1000).EndId(featureds[0].TemplateId).Execute().ToList();

            List<Portofolio> porto = new List<Portofolio>();
            if (screenshots.Count > 0)
            {
                foreach (var item in screenshots)
                {

                    string thumb = item.ScreenshotUrls.FirstOrDefault(stringToCheck => stringToCheck.Contains("med.jpg"));
                    Portofolio portoItem = new Portofolio();
                    portoItem.Thumb = thumb;
                    portoItem.BigImg = item.ScreenshotUrls.FirstOrDefault(stringToCheck => stringToCheck.Contains("big.jpg"));
                    portoItem.ItemId = item.Id.ToString();
                    string demo = "http://www.netstudiodesign.ro/WebDesign/Model/" + item.Id.ToString();
                    portoItem.Price = Convert.ToString(item.Price + 150);
                    if (thumb != null)
                    {
                        #region AAAA
                        dynamic messagePost = new ExpandoObject();
                        messagePost.access_token = "CAACEdEose0cBAF1xDJ6igvIgPb2vXYNv7AZAZCtWYK1Tk6D0snW6JNIzYkQ4ZBZCWMsG1r6sfQ1TZA1v0ewKDwHmyWXWSXzZCvaZAbGcabqC1MnZCmTe16wZCPXU4VY3yoXNXnoe9jy98uNwUuVCzuaIoDi4QV5EiBXihzYDZBHG3ggMyIxZCqj2oQca8T5J8aUmyvr6W2ic32eghm6ZA3eyWHhX";
                        messagePost.picture = item.ScreenshotUrls.FirstOrDefault(stringToCheck => stringToCheck.Contains("big.jpg"));
                        messagePost.link = demo;
                        messagePost.name = "www.NetStudioDesign.ro";
                        messagePost.caption = "Iti place acest site? Da-ne un like/share! "; //<---{*actor*} is the user (i.e.: Aaron)
                        messagePost.description = "Construim orice tip de site:Prezentare/Portal/Magazin online etc. Oferim servicii de optimizare SEO si gazduire. Comanda acest site la pretul de " + portoItem.Price + "€";

                        FacebookClient app = new FacebookClient(messagePost.access_token);
                        
                        try
                        {
                            var result = app.Post("/me/feed", messagePost); ;
                            //var result = app.Post("/100009483596063/feed", new { message = "Is there anyone out there? :) Can i get a whoop whoop" });
                            System.Threading.Thread.Sleep(30000);
                        }
                        catch (FacebookOAuthException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        catch (FacebookApiException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        #endregion
                    }
                }
            }
        }
    }
}
