using NetStudio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemplateMonsterAPI;
using TemplateMonsterAPI.Entity;

namespace TemplateAPI
{
    public partial class ApiForm : Form
    {
        public ApiForm()
        {
            InitializeComponent();

            ITemplateMonsterGateway gw = new TemplateMonsterGateway();
            IList<Category> cats = gw.GetCategories().Execute();
            foreach (var item in cats) {
                comboBox1.Items.Add(item.Id + "-" + item.Name);
            }
            //comboBox1.Items.Add(new ListItem("text", "value"));
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ITemplateMonsterGateway gw = new TemplateMonsterGateway();

            IList<Currency> execute = gw.GetCurrencies().Execute();
            IList<Featured> featureds = gw.GetFeatured().Execute();
            IList<Category> cats = gw.GetCategories().Execute();
            //IList<Screenshot> screenshots = gw.GetScreenshots().StartId(featureds[0].TemplateId - 1000).EndId(featureds[0].TemplateId).Execute();
            IList<Screenshot> screenshots = gw.GetScreenshots().Category(Convert.ToInt32(categoryId.Text)).StartId(57985 - 1000).EndId(57985).Execute();

            List<Portofolio> porto = new List<Portofolio>();
            foreach (var item in screenshots)
            {
                string thumb = item.ScreenshotUrls.FirstOrDefault(stringToCheck => stringToCheck.Contains("med.jpg"));
                Portofolio portoItem = new Portofolio();
                portoItem.Thumb = thumb;
                portoItem.BigImg = item.ScreenshotUrls.FirstOrDefault(stringToCheck => stringToCheck.Contains("big.jpg"));
                portoItem.ItemId = item.Id.ToString();
                portoItem.Sales = item.NumberOfDownloads;
                portoItem.Category = Convert.ToInt32(categoryId.Text);
                portoItem.Price = Convert.ToString(item.Price);
                if (thumb != null)
                    porto.Add(portoItem);
            }
            List<Portofolio> PortoOrder = new List<Portofolio>();
            PortoOrder = porto.OrderByDescending(x => x.Sales).ThenByDescending(x => x.Id).ToList();

#if DEBUG
            string myConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
#else
                string myConnectionString = ConfigurationManager.ConnectionStrings["FindLicenseRelease"].ConnectionString;
#endif

            SqlConnection conn = new SqlConnection(myConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {

                foreach (var item in PortoOrder)
                {

                    cmd.CommandText += "INSERT INTO Portofolio (ItemId, Thumb, BigImg, Price, Sales, Category, CategoryTitle)" +
                                      "VALUES ('" + item.ItemId + "','" + item.Thumb.ToString() + "','" + item.BigImg.ToString() + "'," + item.Price + "," + item.Sales + "," + item.Category + ",'" +  CategoryTitleBox.Text + "')";

                    Console.WriteLine(item.ItemId);
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
                if (conn != null) conn.Dispose();
                if (cmd != null) cmd.Dispose();
                PortoOrder.Clear();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
