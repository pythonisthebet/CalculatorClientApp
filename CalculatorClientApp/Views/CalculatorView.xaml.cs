using CalculatorClientApp.ViewModels;

namespace CalculatorClientApp.Views;

public partial class CalculatorView : ContentPage
{
	public CalculatorView(CalculatorViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}