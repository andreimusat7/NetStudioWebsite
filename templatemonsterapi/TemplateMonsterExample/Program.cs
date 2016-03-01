using System.Collections.Generic;
using TemplateMonsterAPI;
using TemplateMonsterAPI.Entity;

namespace TemplateMonsterExample
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			ITemplateMonsterGateway gw = new TemplateMonsterGateway();
			
			IList<Currency> execute = gw.GetCurrencies().Execute();
			IList<Featured> featureds = gw.GetFeatured().Execute();
			IList<Screenshot> screenshots = gw.GetScreenshots(). StartId(featureds[0].TemplateId).EndId(featureds[0].TemplateId).Execute();
		}
	}
}
