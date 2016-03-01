using TemplateMonsterAPI.Entity;

namespace TemplateMonsterAPI.Descriptors
{
	public class SourcesDescriptor : UrlDescriptorBase<Source>
	{
		private int? _fromId = 1;
		private int? _toId;

		public SourcesDescriptor StartId(int id)
		{
			_fromId = id;
			return this;
		}

		public SourcesDescriptor EndId(int id)
		{
			_toId = id;
			return this;
		}

		#region Overrides of UrlDescriptorBase

		protected override string PageName
		{
			get { return "template_sources.php"; }
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