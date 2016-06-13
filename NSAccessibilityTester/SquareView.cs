using System;

using AppKit;
using CoreGraphics;
using Foundation;

namespace NSAccessibilityTester
{
	[Register ("SquareView")]
	public class SquareView : NSView, INSAccessibilityButton
	{
		public NSColor Color { get; set; }

		string altText;
		public string AltText { 
			get {
				return altText;
			}

			set {
				altText = value;
				AccessibilityLabel = altText;
			}
		}

		bool highlighted;

		public SquareView ()
		{
		}

		public override void DrawRect (CGRect dirtyRect)
		{
			base.DrawRect (dirtyRect);

			(highlighted ? NSColor.Green : Color).SetFill ();
			NSBezierPath.FillRect (dirtyRect);
		}

		public override string AccessibilityLabel {
			get {
				return altText;
			}
			set {
				base.AccessibilityLabel = value;
			}
		}

		public override bool AccessibilityPerformPress ()
		{
			highlighted = !highlighted;
			NeedsDisplay = true;

			return true;
		}
	}
}

