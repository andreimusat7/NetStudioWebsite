using TemplateMonsterAPI.Entity;

namespace TemplateMonsterAPI.Descriptors
{
	public class TemplateTypesDescriptor : UrlDescriptorBase<TemplateType>
	{
		#region Overrides of UrlDescriptorBase

		protected override string PageName
		{
			get { return "templates_types.php"; }
		}

		protected override string RestOfQuerystringParameters
		{
			get { return ""; }
		}

		#endregion
	}
}