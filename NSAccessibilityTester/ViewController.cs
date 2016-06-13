using System;

using AppKit;
using Foundation;

namespace NSAccessibilityTester
{
	public partial class ViewController : NSViewController
	{
		
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Do any additional setup after loading the view.

			for (int i = 0; i < 10; i++) {
				var v = new SquareView ();
				v.Frame = new CoreGraphics.CGRect (0, 0, 20, 20);
				v.Color = NSColor.FromRgb ((256.0f / i) / 256.0f, 0, 0);
				v.AltText = $"Square {i}";

				container.AddSquare (v);
			}
		}

		public override NSObject RepresentedObject {
			get {
				return base.RepresentedObject;
			}
			set {
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}
	}
}
