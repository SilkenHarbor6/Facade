using Facade.Model;
using Facade.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Facade.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPage
	{
		public EditPage (Persona item)
		{
			InitializeComponent ();
            BindingContext = new EditPageViewModel(item);
		}
	}
}