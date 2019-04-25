using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CocosSharp;
using Xamarin.Forms;
using TokBlitzBeta.ViewModels;
namespace TokBlitzBeta.ViewModels
{
    public class GridPage : ContentPage
    {
        GridScene gridScene;
        public GridPage()
        {
            var Flex = new Grid();
            var gameView = new CocosSharpView()
            {  // Notice it has the same properties as other XamarinForms Views
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                // This gets called after CocosSharp starts up:
                ViewCreated = HandleViewCreated
            };

            Flex.Children.Add(gameView);
            Content = gameView;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void HandleViewCreated(object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;

            if (gameView != null)
            {
                // This sets the game "world" resolution to 100x100:
                gameView.DesignResolution = new CCSizeI(App.ScreenWidth, App.ScreenHeight);
                gameView.ResolutionPolicy = CCViewResolutionPolicy.NoBorder;
                // GameScene is the root of the CocosSharp rendering hierarchy:
                gridScene = new GridScene(gameView);


                // Starts CocosSharp:
                gameView.RunWithScene(gridScene);
            }
        }
    }
}