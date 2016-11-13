﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Shapes;

#if WINDOWS_UWP

namespace Xamarin.Forms.Platform.UWP
#else

namespace Xamarin.Forms.Platform.WinRT
#endif
{
	public class BoxViewRenderer : ViewRenderer<BoxView, Windows.UI.Xaml.Shapes.Rectangle>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					var rect = new Windows.UI.Xaml.Shapes.Rectangle();
					rect.DataContext = Element;
					rect.SetBinding(Shape.FillProperty, new Windows.UI.Xaml.Data.Binding { Converter = new ColorConverter(), Path = new PropertyPath("Color") });

					SetNativeControl(rect);
				}
			}
		}
	}
}