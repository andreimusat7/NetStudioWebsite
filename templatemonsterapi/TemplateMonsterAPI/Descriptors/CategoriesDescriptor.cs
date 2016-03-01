using TemplateMonsterAPI.Entity;

namespace TemplateMonsterAPI.Descriptors
{
	public class CategoriesDescriptor : UrlDescriptorBase<Category>
	{
		private Culture _culture;

		public CategoriesDescriptor WithCulture(Culture culture)
		{
			_culture = culture;
			return this;
		}

		#region Overrides of UrlDescriptorBase

		protected override string PageName
		{
			get { return "categories.php"; }
		}

		protected override string RestOfQuerystringParameters
		{
			get { return "locale=" + _culture.ToString().ToLowerInvariant() + "&"; }
		}

		#endregion
	}
}