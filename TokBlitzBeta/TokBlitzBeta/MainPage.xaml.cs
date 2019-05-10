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

            await Navigation.PushAsync(new MainLayer());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            if (int.Parse(RowSet.Text) > 28)
            {
                await DisplayAlert("Warning", "Maximum Word Length: 28" , "OK");
                return;
            }
            else {
                // GridScene.RowSetter = int.Parse(RowSet.Text);
                //  GridScene.ColoumnSetter = int.Parse(ColSet.Text);
                GridScene.WordLength = int.Parse(RowSet.Text);
                if (GridScene.WordLength >= 21 && GridScene.WordLength <= 28)
                {
                    GridScene.RowSetter = 7;
                    GridScene.ColoumnSetter = 4;
                }
                else if (GridScene.WordLength >= 13 && GridScene.WordLength <= 20)
                {
                    GridScene.RowSetter = 5;
                    GridScene.ColoumnSetter = 4;
                }
                else
                {
                    GridScene.RowSetter = 4;
                    GridScene.ColoumnSetter = 3;
                }
                await Navigation.PushAsync(new GridPage());
            }

           
        }
    }
}
