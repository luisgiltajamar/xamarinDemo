// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace ListaPersonas.IOS
{
	[Register ("ListaPersonas_IOSViewController")]
	partial class ListaPersonas_IOSViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnReg { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtApellido { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtEdad { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtNombre { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnReg != null) {
				btnReg.Dispose ();
				btnReg = null;
			}
			if (txtApellido != null) {
				txtApellido.Dispose ();
				txtApellido = null;
			}
			if (txtEdad != null) {
				txtEdad.Dispose ();
				txtEdad = null;
			}
			if (txtNombre != null) {
				txtNombre.Dispose ();
				txtNombre = null;
			}
		}
	}
}
