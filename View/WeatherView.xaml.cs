using WeatherApp.Model;
using WeatherApp.Service;

namespace WeatherApp.View;

public partial class WeatherView : ContentPage
{
	public List<Model.List> WeatherList;
	private double latitude;
	private double longitude;
	public WeatherView()
	{
		InitializeComponent();
		WeatherList = new List<Model.List>();
	}
    protected override async void OnAppearing()
    {
		base.OnAppearing();
		await GetLocation();
        await GetWeatherDataByLocation(latitude, longitude);
    }

	public async Task GetLocation()
	{
		//var location = await GetLocation.GetLocationAsync()
		var location = await Geolocation.GetLocationAsync();
		latitude = location.Latitude;
		longitude = location.Longitude;
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        base.OnAppearing();
        await GetWeatherDataByLocation( latitude,longitude);
    }

	public async Task GetWeatherDataByLocation(double latitude, double longitude)
	{
        var result = await ApiService.Getweather(latitude, longitude);
        UpdateUI(result);
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
      var response =  await DisplayPromptAsync(title: "", message: "", placeholder: "Search weather by city", accept: "Search", cancel: "Cancel");
        if(response != null)
        {
            await GetWeatherDataByCity(response);
        }
    }


    public async Task GetWeatherDataByCity(string city)
    {
        var result = await ApiService.GetweatherByCity(city);
        UpdateUI(result);
    }

    public void UpdateUI(dynamic result)
    {
        foreach (var items in result.list)
        {
            WeatherList.Add(items);
        }
        CvWeather.ItemsSource = WeatherList;
        LblCity.Text = result.city.name;
        lblWeatherDescription.Text = result.list[0].weather[0].description;
        //LblTemperature.Text = result.list.Count[0].main.temp + "°C";
        LblTemperature.Text = result.list[0].main.temperature + "°C";
        LblHumidity.Text = result.list[0].main.humidity + "%";
        LblWind.Text = result.list[0].wind.speed + "km/h";
        ImgWeatherIcon.Source = result.list[0].weather[0].fullIconUrl;
    }
}