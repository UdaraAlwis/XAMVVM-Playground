using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFWithUnitTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTextPage : ContentPage
	{
		public NewTextPage()
		{
			InitializeComponent();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

            TextTitleEditor.Focus();
	    }
	}
}