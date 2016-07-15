using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace toiletino
{
	class MapPage : ContentPage
	{
		private Map map;

		public MapPage()
		{
			map = new Map(
			   MapSpan.FromCenterAndRadius(
					   new Position(37, -122), Distance.FromMiles(0.3)))
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			var stack = new StackLayout { Spacing = 0 };

			var position = new Position(37, -122); // Latitude, Longitude
			var pin = new Pin
			{
				Type = PinType.Place,
				Position = position,
				Label = "custom pin",
				Address = "custom detail info"
			};
			map.Pins.Add(pin);

			stack.Children.Add(map);
			Content = stack;
		}

		public void MoveTo(Position position)
		{
			map.MoveToRegion(
				 MapSpan.FromCenterAndRadius(
				new Position(37, -122), Distance.FromMiles(1)
				));
		}
	}
}