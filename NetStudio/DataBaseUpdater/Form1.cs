
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

namespace DataBaseUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Start_Click(object sender, EventArgs e)
        {
            int cat = Convert.ToInt16(Categorie.Text);
            ITemplateMonsterGateway gw = new TemplateMonsterGateway();

            IList<Currency> execute = gw.GetCurrencies().Execute();
            IList<Featured> featureds = gw.GetFeatured().Execute();
            IList<Screenshot> screenshots = gw.GetScreenshots().StartId(0).EndId(featureds[0].TemplateId).Category(cat).Execute().OrderByDescending(x => x.Id).ToList();

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
                    string demo = "http://www.templatemonster.com/demo/" + item.Id.ToString() + ".html";
                    portoItem.Price = Convert.ToString(item.Price + 100);
                    if (thumb != null)
                    {
                        string myConnectionString = "";
                        #if DEBUG
                            myConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
#else
                        myConnectionString = ConfigurationManager.ConnectionStrings["ReleaseString"].ConnectionString;
                        #endif

                        SqlConnection conn = new SqlConnection(myConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        try
                        {
                            conn.Open();
                            cmd.CommandText = "INSERT INTO Portofolio (ItemId,Thumb,BigImg,Url,Price, Category) " +
                                "VALUES ('" + item.Id.ToString() + "', '" + item.ScreenshotUrls.FirstOrDefault(stringToCheck => stringToCheck.Contains("med.jpg")) + "','" + item.ScreenshotUrls.FirstOrDefault(stringToCheck => stringToCheck.Contains("big.jpg")) + "','" + demo + "','" + Convert.ToString(item.Price + 100) + "','" + cat + "')";
                            cmd.ExecuteNonQuery(); // Execute query

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            conn.Close(); // Close connection
                            if (conn != null) conn.Dispose(); //Dispose resources
                            if (cmd != null) cmd.Dispose();
                            this.Close();
                            this.Dispose();
                        }
                    }
                }
            }
        }
    }
}
