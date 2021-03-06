﻿using System;
using ListadoPersonas.Utilidades.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ListadoPersonas
{
	public class BaseViewModel: PropertyChangedBase
			{
				protected readonly IWebService service = ServiceContainer.Resolve<IWebService>();
			
				
				public event EventHandler IsBusyChanged;

				private bool isBusy = false;

				public bool IsBusy
				{
					get { return isBusy; }
					set
					{
						if (isBusy != value) {
							isBusy = value;

							OnPropertyChanged ("IsBusy");
							OnIsBusyChanged ();
						}
					}
				}



				public event EventHandler IsValidChanged;

				readonly List<string> errors = new List<string> ();



				public BaseViewModel ()
				{

					Validate ();
				}


				public bool IsValid
				{
					get { return errors.Count == 0; }
				}


				protected List<string> Errors
				{
					get { return errors; }
				}


				public virtual string Error
				{
					get
					{
						return errors.Aggregate (new StringBuilder (), (b, s) => b.AppendLine (s)).ToString ().Trim ();
					}
				}


				protected virtual void Validate ()
				{
					OnPropertyChanged ("IsValid");
					OnPropertyChanged ("Errors");

					var method = IsValidChanged;
					if (method != null)
						method (this, EventArgs.Empty);
				}


				protected virtual void ValidateProperty (Func<bool> validate, string error)
				{
					if (validate ()) {
						if (!Errors.Contains (error))
							Errors.Add (error);
					} else {
						Errors.Remove (error);
					}
				}


				protected virtual void OnIsBusyChanged ()
				{
					var method = IsBusyChanged;
					if (method != null)
						IsBusyChanged (this, EventArgs.Empty);
				}
			}
		}
