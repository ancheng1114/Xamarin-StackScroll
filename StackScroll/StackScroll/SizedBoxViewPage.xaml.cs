using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StackScroll
{
	public partial class SizedBoxViewPage : ContentPage
	{
		public SizedBoxViewPage ()
		{

			BackgroundColor = Color.Pink;
			Content = new BoxView {

				Color = Color.Accent,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				WidthRequest = 200,
				HeightRequest = 100
			};
		}
	}
}

