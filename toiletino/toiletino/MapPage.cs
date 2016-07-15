using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Linq;

namespace toiletino
{
	class MapPage : ContentPage
	{
		private Map map;
		private Button NavigateButton;
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

			NavigateButton = new Button();
			NavigateButton.Text = "Find toilet";
			NavigateButton.Clicked += MoveToNextToilet;

			stack.Children.Add(map);
			stack.Children.Add(NavigateButton);
			Content = stack;
		}

		public async void MoveToNextToilet(object sender, EventArgs e)
		{
			List<Toilet> toilets = await RestService.Instance.GetClosestToiletList(new Position());
			MoveMapTo(toilets.First().location);
		}

		public void MoveMapTo(Position position)
		{
			map.MoveToRegion(
				 MapSpan.FromCenterAndRadius(
				position, Distance.FromMiles(1)
				));
		}
	}
}