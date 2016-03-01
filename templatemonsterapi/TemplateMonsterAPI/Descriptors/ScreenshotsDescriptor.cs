using System.Collections.Generic;
using System.Linq;
using TemplateMonsterAPI.Entity;

namespace TemplateMonsterAPI.Descriptors
{
	public class ScreenshotsDescriptor : UrlDescriptorBase<Screenshot>
	{
		private int? _fromId = 1;
		private int? _toId;

		private bool? _lastAdded;
		private bool? _sold;

		private ScreenshotsFilterOnly _filter;
		private IList<string> _keywordsToSearch = new List<string>();

		private int? _category;

		private ScreenshotsOrderBy _orderBy;
		private bool _orderAsc = true;

		private bool? _requireFullPath = true;
		private EnumCurrency _currency;


		public ScreenshotsDescriptor OnlySold()
		{
			_sold = true;
			return this;
		}

		public ScreenshotsDescriptor OnlyLastAdded()
		{
			_lastAdded = true;
			return this;
		}

		public ScreenshotsDescriptor Category(int categoryId)
		{
			_category = categoryId;
			return this;
		}

		public ScreenshotsDescriptor Currency(EnumCurrency currency)
		{
			_currency = currency;
			return this;
		}

		public ScreenshotsDescriptor StartId(int id)
		{
			_fromId = id;
			return this;
		}

		public ScreenshotsDescriptor EndId(int id)
		{
			_toId = id;
			return this;
		}

		public ScreenshotsDescriptor OrderBy(ScreenshotsOrderBy orderBy, bool desc)
		{
			_orderBy = orderBy;
			_orderAsc = desc;
			return this;
		}

		public ScreenshotsDescriptor Only(ScreenshotsFilterOnly only)
		{
			_filter = only;
			return this;
		}

		#region Overrides of UrlDescriptorBase

		protected override string PageName
		{
			get { return "templates_screenshots4.php"; }
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
				if (_lastAdded.HasValue)
					qString += "last_added=" + (_lastAdded.Value ? 1 : 0) + "&";
				if (_sold.HasValue)
					qString += "sold=" + (_sold.Value ? 1 : 0) + "&";
				qString += "filter=" + ((int)_filter) + "&";

				if (_keywordsToSearch.Count > 0)
				{
					qString += "keywords=" + _keywordsToSearch.Aggregate((x, y) => x + " " + y) + "&";
				}

				if (_category.HasValue)
				{
					qString += "category=" + _category + "&";
				}
                //_orderAsc = true;
				qString += "sort_by=" + _orderBy.ToString().ToLowerInvariant() + "&";
				qString += "order=" + (_orderAsc ? "asc" : "desc") + "&";
				qString += "list_delim=" + Constants.ListDelimiter + "&";
				qString += "list_begin=" + Constants.ListBegin + "&";
				qString += "list_end=" + Constants.ListEnd + "&";
				qString += "full_path=" + _requireFullPath.ToString().ToLowerInvariant() + "&";
				qString += "currency=" + _currency + "&";

				return qString;
			}
		}

		#endregion
	}
}