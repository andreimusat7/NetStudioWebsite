namespace TemplateMonsterAPI.Descriptors
{
	public abstract class RangedUrlDescriptor<T> : UrlDescriptorBase<T>
	{
		private int? _fromId = 1;
		private int? _toId;

		public RangedUrlDescriptor<T> StartId(int id)
		{
			_fromId = id;
			return this;
		}

		public RangedUrlDescriptor<T> EndId(int id)
		{
			_toId = id;
			return this;
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
	}
}