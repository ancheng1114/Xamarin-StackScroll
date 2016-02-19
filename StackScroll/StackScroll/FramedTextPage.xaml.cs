using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StackScroll
{
	public partial class FramedTextPage : ContentPage
	{
		public FramedTextPage ()
		{

			Padding = new Thickness (20);

			BackgroundColor = Color.Aqua;
			Content = new Frame {

				OutlineColor = Color.Accent,
				BackgroundColor = Color.Yellow,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Content = new Label {
					Text = "I've been framed",
					FontSize = Device.GetNamedSize(NamedSize.Large ,typeof(Label)),
					TextColor = Color.Blue
				}
			};

		}
	}
}