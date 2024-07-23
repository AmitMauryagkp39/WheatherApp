﻿using WeatherApp.View;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new WeatherView());
        }
    }

}