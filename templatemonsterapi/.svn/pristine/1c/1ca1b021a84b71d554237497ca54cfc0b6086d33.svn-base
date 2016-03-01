using System;
using System.Collections.Generic;
using TemplateMonsterAPI.Descriptors;
using TemplateMonsterAPI.Parser;

namespace TemplateMonsterAPI
{
	public static class UrlDescriptorBaseExtensions
	{
		public static IList<T> Execute<T>(this UrlDescriptorBase<T> descriptor) where T : new()
		{
			IRequestExecutor requestExecutor = new RequestExecutor();
			string response = requestExecutor.GetResponse(descriptor);

			string[] lines = response.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			IList<T> resultList = new List<T>(lines.Length);
			ResultParser<T> parser = new ResultParser<T>();
			
			foreach (string line in lines)
			{
				resultList.Add(parser.Parse(line, descriptor));
			}

			return resultList;
		}
	}
}