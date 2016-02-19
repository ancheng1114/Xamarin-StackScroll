using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace StackScroll
{
	public partial class ColorLoopPage : ContentPage
	{
		public ColorLoopPage ()
		{
			InitializeComponent ();

//			var colors = new[]
//			{
//				new { value = Color.White, name = "White" },
//				new { value = Color.Silver, name = "Silver" },
//				new { value = Color.Gray, name = "Gray" },
//				new { value = Color.Black, name = "Black" },
//				new { value = Color.Red, name = "Red" },
//				new { value = Color.Maroon, name = "Maroon" }, new { value = Color.Yellow, name = "Yellow" },
//				new { value = Color.Olive, name = "Olive" },
//				new { value = Color.Lime, name = "Lime" },
//				new { value = Color.Green, name = "Green" },
//				new { value = Color.Aqua, name = "Aqua" },
//				new { value = Color.Teal, name = "Teal" },
//				new { value = Color.Blue, name = "Blue" },
//				new { value = Color.Navy, name = "Navy" }, new { value = Color.Pink, name = "Pink" },
//				new { value = Color.Fuchsia, name = "Fuchsia" },
//				new { value = Color.Purple, name = "Purple" }
//			};

			StackLayout stackLayout = new StackLayout
			{

				BackgroundColor = Color.Blue,
				VerticalOptions = LayoutOptions.EndAndExpand,
				HorizontalOptions = LayoutOptions.Fill,
				Orientation = StackOrientation.Horizontal
			};

			foreach (FieldInfo info in typeof(Color).GetRuntimeFields())
			{
				if (info.GetCustomAttribute<ObsoleteAttribute> () != null) {

					continue;
				}

				if (info.IsPublic && info.IsStatic && info.FieldType == typeof(Color)) {

					stackLayout.Children.Add (CreateColorLabel((Color)info.GetValue(null) ,info.Name));
				}
			}

			foreach (PropertyInfo info in typeof(Color).GetRuntimeProperties())
			{
				MethodInfo methodInfo = info.GetMethod;

				if (methodInfo.IsPublic && methodInfo.IsStatic && methodInfo.ReturnType == typeof(Color)) {

					stackLayout.Children.Add (CreateColorLabel((Color)info.GetValue(null) ,info.Name));
				}
			}

//			foreach (var color in colors) {
//			
//				stackLayout.Children.Add (
//				
//					new Label{
//					
//						Text = color.name,
//						TextColor = color.value,
//						FontSize = Device.GetNamedSize(NamedSize.Large , typeof(Label))
//					}
//
//				);
//			}

			Padding = new Thickness (5 ,Device.OnPlatform(20 , 5 , 5) , 5 ,5);
			Content = new ScrollView{
				Content = stackLayout,
				Orientation = ScrollOrientation.Horizontal
			};
		}

		Label CreateColorLabel(Color color , String name)
		{

			Color backgroundColor = Color.Default;

			if (color != Color.Default) {

				double luminance = 0.30 * color.R +
					// Create the Label.
					0.59 * color.G +
					0.11 * color.B;

				backgroundColor = luminance > 0.5 ? Color.Black : Color.White;
			}

			return new Label {

				Text = name,
				TextColor = color,
				FontSize = Device.GetNamedSize(NamedSize.Large , typeof(Label)),
				BackgroundColor = backgroundColor
			};
		}
	}

}