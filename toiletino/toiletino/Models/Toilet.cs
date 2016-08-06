using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System;
using Xamarin.Forms;
using UIKit;
namespace toiletino
{
	public class Toilet
	{
		public Position Location { get; set; }
		public String Name { get; set;}
		public String Info{ get; set; }
		public List<Rating> Ratings { get; set; }
		public List<ToiletInfoImage> Images { get; set; }
		public User AddedBy { get; set; }
		public String MainImage { get; set; }

		public Toilet()
		{
		}
	}
}

