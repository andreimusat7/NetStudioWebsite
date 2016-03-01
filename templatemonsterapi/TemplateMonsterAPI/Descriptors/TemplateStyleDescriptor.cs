using TemplateMonsterAPI.Entity;

namespace TemplateMonsterAPI.Descriptors
{
	public class TemplateStyleDescriptor : RangedUrlDescriptor<TemplateToStyle>
	{
		#region Overrides of UrlDescriptorBase

		protected override string PageName
		{
			get { return "template_styles.php"; }
		}

		#endregion
	}
}