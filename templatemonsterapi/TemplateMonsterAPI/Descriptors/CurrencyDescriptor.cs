using TemplateMonsterAPI.Entity;

namespace TemplateMonsterAPI.Descriptors
{
	public class CurrencyDescriptor : UrlDescriptorBase<Currency>
	{
		#region Overrides of UrlDescriptorBase

		protected override string PageName
		{
			get { return "currency.php"; }
		}

		protected override string RestOfQuerystringParameters
		{
			get { return ""; }
		}

		#endregion
	}
}