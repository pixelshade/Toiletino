using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;

namespace toiletino
{
	class MapPage : ContentPage
	{
		private Map map;
		private Button NavigateButton;
		private Button ListToiletsButton;
		//private Position lastPosition;
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
			NavigateButton.HorizontalOptions = LayoutOptions.FillAndExpand;
			NavigateButton.BackgroundColor = Color.Silver;
			NavigateButton.Clicked += MoveToNextToilet;

			ListToiletsButton = new Button();
			ListToiletsButton.HorizontalOptions = LayoutOptions.FillAndExpand;
			ListToiletsButton.Text = "Show toilet list";
			ListToiletsButton.Clicked += ShowToiletsListPage;

			StackLayout buttonsStack = new StackLayout { Orientation = StackOrientation.Horizontal };

			stack.Children.Add(map);
			stack.Children.Add(buttonsStack);
			buttonsStack.Children.Add(NavigateButton);
			buttonsStack.Children.Add(ListToiletsButton);
			Content = stack;
		}

		public async void ShowToiletsListPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ToiletsListPage(), true);
		}

		public async void MoveToNextToilet(object sender, EventArgs e)
		{
			var pos = await GetPosition();
			List<Toilet> toilets = await RestService.Instance.GetClosestToiletList(pos);
			//MoveMapTo(toilets.First().location);
			MoveMapTo(pos);
		}

		public void MoveMapTo(Position position)
		{
			
			map.MoveToRegion(
				 MapSpan.FromCenterAndRadius(
				position, Distance.FromMiles(1)
				));
		}


		public async System.Threading.Tasks.Task<Position> GetPosition()
		{

			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;

			var position = await locator.GetPositionAsync(10000);

			Console.WriteLine("Position Status: {0}", position.Timestamp);
			Console.WriteLine("Position Latitude: {0}", position.Latitude);
			Console.WriteLine("Position Longitude: {0}", position.Longitude);
			return new Position(position.Latitude,position.Longitude);
		}
	}
}