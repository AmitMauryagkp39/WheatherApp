using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.View;

namespace WeatherApp.ViewModel
{
    public class WelcomeViewModel
    {
        public Command WeatherPageCmd { get { return new Command(() => WeatherPageTab()); } }
        public Command WeatherCmd { get { return new Command(() => WeatherTab()); } }

        private async void WeatherTab()
        {
            //await  App.Current.MainPage.Navigation.PushAsync(new WeatherView());
            App.Current.MainPage.Navigation.PushAsync(new WeatherView());
        }

        private async void WeatherPageTab()
        {
            if (WeatherPageTab != null)
            {
              await  App.Current.MainPage.Navigation.PushAsync(new WeatherView());
            }
        }
    }
}
