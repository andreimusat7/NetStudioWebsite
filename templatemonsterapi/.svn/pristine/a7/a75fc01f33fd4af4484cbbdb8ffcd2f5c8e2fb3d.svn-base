using System;
using System.IO;
using System.Net;

namespace TemplateMonsterAPI
{
	public interface IRequestExecutor
	{
		string GetResponse(IUrlDescriptor uriToCall);
	}


	public class RequestExecutor : IRequestExecutor
	{
		public string GetResponse(IUrlDescriptor uriToCall)
		{
			WebRequest request = WebRequest.Create(uriToCall.Url);
			request.Method = "GET";
			request.Timeout = 1000 * 10;
			request.UseDefaultCredentials = true;

			string result;

			using (var response = request.GetResponse())
			{
				using (StreamReader reader = new StreamReader(response.GetResponseStream()))
				{
					result = reader.ReadToEnd();
				}
			}

			return result;
		}
	}
}