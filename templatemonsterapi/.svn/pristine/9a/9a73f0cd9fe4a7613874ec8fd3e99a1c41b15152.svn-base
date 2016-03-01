using TemplateMonsterAPI.Entity;

namespace TemplateMonsterAPI.Descriptors
{
	public class FeaturedDescriptor : UrlDescriptorBase<Featured>
	{
		private FeaturedTypes _featuredTypes;

		#region Overrides of UrlDescriptorBase

		protected override string PageName
		{
			get { return "featured.php"; }
		}

		protected override string RestOfQuerystringParameters
		{
			get { return "type=" + _featuredTypes.ToString().ToLowerInvariant() + "&"; }
		}

		#endregion
	}
}