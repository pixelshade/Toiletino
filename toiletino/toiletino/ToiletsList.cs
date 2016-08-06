using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace toiletino
{
	public class ToiletsList : ContentPage
	{
		public ToiletsList()
		{
			// Some presidential data. http://www.americanpresidents.org/gallery/
			List<Toilet> Toilets = new List<Toilet> {
			new Toilet {Name = "George Washington", Info="aasdfasdf", MainImage = "http://www.americanpresidents.org/images/01_150.gif"},
			new Toilet {Name = "John Adams", Info="aasdfasdf", MainImage = "http://www.americanpresidents.org/images/02_150.gif"},
			new Toilet {Name = "Thomas  Jefferson", Info="aasdfasdf", MainImage = "http://www.americanpresidents.org/images/03_150.gif"},
			new Toilet {Name = "James Madison", Info="aasdfasdf", MainImage = "http://www.americanpresidents.org/images/04_150.gif"},
			new Toilet {Name = "James Monroe", Info="aasdfasdf", MainImage = "http://www.americanpresidents.org/images/05_150.gif"},
			new Toilet {Name = "John Quincy Adams", Info="aasdfasdf", MainImage = "http://www.americanpresidents.org/images/06_150.gif"},
			new Toilet {Name = "Andrew Jackson", Info="aasdfasdf", MainImage = "http://www.americanpresidents.org/images/07_150.gif"},
			new Toilet {Name = "Martin Van Buren", Info="aasdfasdf", MainImage = "http://www.americanpresidents.org/images/08_150.gif"},
			new Toilet {Name = "William Henry Harrison", Info="aasdfasdf", MainImage = "http://www.americanpresidents.org/images/09_150.gif"},
			new Toilet {Name = "John Tyler", Info="aasdfasdf0", MainImage = "http://www.americanpresidents.org/images/10_150.gif"},
			new Toilet {Name = "James K. Polk", Info="aasdfasdf1", MainImage = "http://www.americanpresidents.org/images/11_150.gif"},
			new Toilet {Name = "Zachary Taylor", Info="aasdfasdf2", MainImage = "http://www.americanpresidents.org/images/12_150.gif"},
			new Toilet {Name = "Millard Fillmore", Info="aasdfasdf3", MainImage = "http://www.americanpresidents.org/images/13_150.gif"},
			new Toilet {Name = "Franklin Pierce", Info="aasdfasdf4", MainImage = "http://www.americanpresidents.org/images/14_150.gif"},
			new Toilet {Name = "James Buchanan", Info="aasdfasdf5", MainImage = "http://www.americanpresidents.org/images/15_150.gif"},
		};

			Label header = new Label
			{
				Text = "Presidents",
				Font = Font.SystemFontOfSize(35),
				HorizontalOptions = LayoutOptions.Center
			};

			// Create a data template from the type ImageCell
			var cell = new DataTemplate(typeof(ImageCell));

			cell.SetBinding(TextCell.TextProperty, "Name");
			cell.SetBinding(TextCell.DetailProperty, "Info");
			cell.SetBinding(ImageCell.ImageSourceProperty, "MainImage");

			ListView listView = new ListView
			{
				ItemsSource = Toilets,
				ItemTemplate = cell // Set the ImageCell to the item template for the listview
			};

			// Push the list view down below the status bar on iOS.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Set the content for the page.
			this.Content = new StackLayout
			{
				Children = {
				header,
				listView
			}
			};
		}
	}
}


