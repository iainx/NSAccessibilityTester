using System;

using AppKit;
using CoreGraphics;
using Foundation;

namespace NSAccessibilityTester
{
	[Register ("SquareContainerView")]
	public class SquareContainerView : NSView, INSAccessibilityGroup
	{
		readonly Random rnd = new Random ();

		public SquareContainerView (IntPtr handle) : base (handle)
		{
			
		}

		public void AddSquare (SquareView view)
		{
			AddSubview (view);

			var childCount = AccessibilityChildren.Length;
			var newChildren = new NSObject[childCount + 1];

			if (childCount > 0) {
				Array.Copy (AccessibilityChildren, newChildren, childCount);
			}

			newChildren[childCount] = view;

			AccessibilityChildren = newChildren;

			int maxX, maxY;

			maxX = (int) (Frame.Width - view.Frame.Width);
			maxY = (int) (Frame.Height - view.Frame.Height);

			int x, y;

			x = rnd.Next (maxX);
			y = rnd.Next (maxY);

			CGRect sqFrame = new CGRect (x, y, view.Frame.Width, view.Frame.Height);
			view.Frame = sqFrame;
		}
	}
}

