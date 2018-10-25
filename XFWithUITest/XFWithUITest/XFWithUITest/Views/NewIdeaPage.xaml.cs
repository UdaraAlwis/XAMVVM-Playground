using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFWithUITest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewIdeaPage : ContentPage
	{
		public NewIdeaPage()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

	        IdeaTitleEditor.Focus();
	    }
	}
}