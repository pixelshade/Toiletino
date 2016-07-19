using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System;
using Xamarin.Forms;
using UIKit;
namespace toiletino
{
	public class Toilet
	{
		public Position Location;
		public String Name;
		public String Info;
		public List<Rating> Ratings;
		public List<ToiletInfoImage> Images;
		public User AddedBy; 

		public Toilet()
		{
		}
	}
}

