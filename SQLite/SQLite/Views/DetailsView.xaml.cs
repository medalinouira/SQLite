﻿/// Mohamed Ali NOUIRA
/// http://www.sweetmit.com
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsView : ContentPage
    {
        public DetailsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send<string>("DetailsViewLoaded", "DetailsViewLoadedMessage");
        }
    }
}