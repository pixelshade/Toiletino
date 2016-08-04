using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace toiletino
{
	public partial class ToiletListPage : ContentPage
	{
		public ToiletListPage()
		{
			InitializeComponent();
			ObservableCollection<Toilet> toiletList = new ObservableCollection<Toilet>();
			toiletList.Add(new Toilet { Name = "jozko", Info = "adsf" });
			toiletList.Add(new Toilet { Name = "dfgsdfgr", Info = "dfgs" });
			//ToiletsListView.ItemsSource
			//var ToiletsListView = new ListView();


			Title = "toilets";

			Label header = new Label
			{
				Text = "Toilets near you",
				//Font = Font.SystemFontOfSize(35),
				HorizontalOptions = LayoutOptions.Center
			};

			var cell = new DataTemplate(typeof(ImageCell));

			cell.SetBinding(TextCell.TextProperty, "Name");
			cell.SetBinding(TextCell.DetailProperty, "Info");
			//cell.SetBinding(ImageCell.ImageSourceProperty, "Image");

			ListView listView = new ListView
			{
				ItemsSource = toiletList,
				ItemTemplate = cell
			};

			// Push the list view down below the status bar on iOS.
			//this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Set the content for the page.
			this.Content = new StackLayout
			{
				Children = {
				//header,
				listView
			}
			};
		}
	}
}

