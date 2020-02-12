using System;
namespace culqi.net
{
	public class Config
	{
		public Config()
		{
		}

		public string url_api_base { get; set;} = "https://api.culqi.com/v2";
		public string url_token_api { get; set; } = "https://secure.culqi.com/v2";
	}
}
