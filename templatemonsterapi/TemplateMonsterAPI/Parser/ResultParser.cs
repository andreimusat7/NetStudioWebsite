using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TemplateMonsterAPI.Descriptors;

namespace TemplateMonsterAPI.Parser
{
	public class ResultParser<T> : IResultParser<T> where T : new()
	{
		public virtual T Parse(string line, UrlDescriptorBase<T> descriptor)
		{
			string[] tokens = line.Split(new[] { Constants.Delimiter }, StringSplitOptions.RemoveEmptyEntries);
			T result = new T();
			PropertyInfo[] properties = typeof(T).GetProperties();

			for (int i = 0; i < properties.Length; i++)
			{
				if (properties[i].PropertyType == typeof(IList<string>))
				{
					IList<string> list = ParseList(tokens[i], descriptor);
					properties[i].SetValue(result, list, null);
					continue;
				}
				object valueToSet = ConvertValueToType(tokens[i], properties[i].PropertyType);
				properties[i].SetValue(result, valueToSet, null);
			}

			return result;
		}

		protected IList<string> ParseList(string token, UrlDescriptorBase<T> descriptor)
		{
			if (!token.StartsWith(Constants.ListBegin) || !token.EndsWith(Constants.ListEnd))
				throw new NotSupportedException("The list did not start with : " + Constants.ListBegin + " or did not ended with : " + Constants.ListEnd + "\r\n"
																				+ "String attempted to parse: " + token);

			string toParse = token.TrimEnd(Constants.ListEnd.ToCharArray())
														.TrimStart(Constants.ListBegin.ToCharArray());

			return (from tk in toParse.Split(Constants.ListDelimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
							select tk).ToList();
		}

		protected object ConvertValueToType(string token, Type type)
		{
			if (type == typeof(int) || type == typeof(int?))
				return Convert.ToInt32(token);
			if (type == typeof(bool) || type == typeof(bool?))
				return token == "0" ? false : true;
			if (type == typeof(decimal) || type == typeof(decimal?))
				return Convert.ToDecimal(token);
			if (type == typeof(DateTime) || type == typeof(DateTime?))
				return Convert.ToDateTime(token);
			return token;
		}
	}
}