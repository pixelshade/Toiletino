using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace toiletino
{
	public partial class ToiletDetailPage : ContentPage
	{
		public Toilet Toilet { get; set;}

		public ToiletDetailPage(Toilet Toilet)
		{
			this.Toilet = Toilet;
			Init();
		}

		public ToiletDetailPage()
		{
			Init();
		}

		private void Init()
		{
			InitializeComponent();
		}
	}
}

