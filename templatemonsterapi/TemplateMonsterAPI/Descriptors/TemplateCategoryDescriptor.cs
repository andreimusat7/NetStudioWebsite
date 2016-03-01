using TemplateMonsterAPI.Entity;

namespace TemplateMonsterAPI.Descriptors
{
	public class TemplateCategoryDescriptor : UrlDescriptorBase<TemplateToCategory>
	{
		private int? _fromId = 1;
		private int? _toId;

		public TemplateCategoryDescriptor StartId(int id)
		{
			_fromId = id;
			return this;
		}

		public TemplateCategoryDescriptor EndId(int id)
		{
			_toId = id;
			return this;
		}

		#region Overrides of UrlDescriptorBase

		protected override string PageName
		{
			get { return "template_categories.php"; }
		}

		protected override string RestOfQuerystringParameters
		{
			get
			{
				string qString = "";

				if (_fromId.HasValue)
					qString += "from=" + _fromId + "&";
				if (_toId.HasValue)
					qString += "to=" + _toId + "&";
				return qString;
			}
		}

		#endregion
	}
}