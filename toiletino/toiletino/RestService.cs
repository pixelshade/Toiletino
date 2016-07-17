using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Newtonsoft.Json;
using System.Net.Http;
using ModernHttpClient;
using System.Net;

namespace toiletino
{
	public class RestService
	{
		private static RestService instance;

		private static HttpClient client;

		public static RestService Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new RestService();
				}
				return instance;
			}
		}

		private RestService()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}


		public async Task<List<Toilet>> GetClosestToiletList(Position position)
		{
			var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				try
				{
					var content = await response.Content.ReadAsStringAsync();
					var toilets = JsonConvert.DeserializeObject<List<Toilet>>(content);
					return toilets;
				}
				catch(Exception e)
				{
					return null;;
				}
			}
			return null;

		}
	}
}

