﻿using Facade.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Facade.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPage : ContentPage
	{
		public NewPage ()
		{
			InitializeComponent ();
            BindingContext = new NewPageViewModel();
		}
	}
}