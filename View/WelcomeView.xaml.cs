namespace WeatherApp.View;

public partial class WelcomeView : ContentPage
{
	public WelcomeView()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PushAsync(new WeatherView());
    }
}