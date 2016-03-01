using System;

namespace TemplateMonsterAPI.Descriptors
{
	public abstract class UrlDescriptorBase<T> : IUrlDescriptor
	{
		protected const string Login = "drupop";
		protected const string Password = "9f463c99c43a5884138093b9070f5b3d";

		protected const string BaseUrl = "http://www.templatemonster.com/webapi/";

		protected abstract string PageName { get; }

		protected string FullPageUrl
		{
			get
			{
				return BaseUrl + PageName + "?"
				       + StartQueryString
				       + RestOfQuerystringParameters
				       + EndQueryString;
			}
		}

		protected string StartQueryString
		{
			get
			{
				return string.Format("delim={0}&", Constants.Delimiter);
			}
		}

		protected string EndQueryString
		{
			get
			{
				return string.Format("login={0}&webapipassword={1}", Login, Password);
			}
		}

		protected abstract string RestOfQuerystringParameters { get; }

		public Uri Url
		{
			get
			{
				return new Uri(FullPageUrl);
			}
		}
	}
}