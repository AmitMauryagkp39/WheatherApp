﻿using WeatherApp.View;

namespace WeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new WeatherView();
        }
    }
}