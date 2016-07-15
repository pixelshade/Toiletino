using System;
using Xamarin.Forms;
using System.Resources;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;

namespace toiletino
{
	public class Storage
	{
		private static RestService restService;
		private const string KEY_TOILETS = "toilets";

		public List<Toilet> Toilets
		{
			get
			{
				string s = Application.Current.Properties[KEY_TOILETS] as string;
				return JsonConvert.DeserializeObject<List<Toilet>>(s);
			}
			set
			{

				var s = JsonConvert.SerializeObject(value);
				Application.Current.Properties[KEY_TOILETS] = s;
			}
		}

		public Storage()
		{
			
		}

		public async Task<List<Toilet>> updateToiletsFromRest(Position pos)
		{
			var list = await RestService.Instance.GetClosestToiletList(pos);
			Toilets = list;
			return list;
		}


		 



	}
}

