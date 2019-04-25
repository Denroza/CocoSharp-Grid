using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CocosSharp;
using TokBlitzBeta.ViewModels;

namespace TokBlitzBeta
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Main());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (int.Parse(RowSet.Text) >= 8 || int.Parse(ColSet.Text) >= 5)
            {
                await DisplayAlert("Warning", "Maximum Row: 7" + Environment.NewLine + "Maximum Coloumn: 4", "OK");
                return;
            }
            else {
                GridScene.RowSetter = int.Parse(RowSet.Text);
                GridScene.ColoumnSetter = int.Parse(ColSet.Text);
                await Navigation.PushAsync(new GridPage());
            }

           
        }
    }
}
