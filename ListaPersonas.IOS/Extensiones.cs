﻿using System;
using MonoTouch.UIKit;
using System.Linq;
namespace ListaPersonas.IOS
{



		public static class UIKitExtensions
		{
			public static void DisplayError(this Exception exc)
			{
				string error;
				AggregateException aggregate = exc as AggregateException;
				if (aggregate != null)
				{
					error = aggregate.InnerExceptions.First().Message;
				}
				else
				{
					error = exc.Message;
				}

				new UIAlertView("Oops!", error, null, "Ok").Show();
			}
		}



}

