using CalculatorClientApp.Views;

namespace CalculatorClientApp;

public partial class App : Application
{
	public App(CalculatorView v)
	{
		InitializeComponent();

		MainPage = v;
	}
}
