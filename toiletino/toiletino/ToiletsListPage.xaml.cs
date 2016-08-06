using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace toiletino
{
	public partial class ToiletsListPage : ContentPage
	{
		public ObservableCollection<Toilet> ToiletList { get; set;}
		public ToiletsListPage()
		{
			InitializeComponent();
			ToiletList = new ObservableCollection<Toilet>();
			ToiletList.Add(new Toilet { Name = "jozko", Info = "adsf", MainImage = "http://www.newyorker.com/wp-content/uploads/2014/08/Stokes-Hello-Kitty2-1200.jpg" });
			ToiletList.Add(new Toilet { Name = "dfgsdfgr", Info = "dfgs", MainImage = "https://static.c-span.org/assets/images/series/americanPresidents/43_150.png" });
			toiletsListView.ItemsSource = ToiletList;


		}

		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			Navigation.PushAsync(new ToiletDetailPage(e.SelectedItem as Toilet), true);
		}
	}
}

