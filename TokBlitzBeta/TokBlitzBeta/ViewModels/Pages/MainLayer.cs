using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TokBlitzBeta.ViewModels
{
    public class MainLayer : ContentPage
    {

        MainScene mainScene;
        public MainLayer(){
            var Flex = new StackLayout();
            var gameView = new CocosSharpView()
            {  // Notice it has the same properties as other XamarinForms Views
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                // This gets called after CocosSharp starts up:
                ViewCreated = HandleViewCreated
            };

            Flex.Children.Add(gameView);
            Content = Flex;
            NavigationPage.SetHasNavigationBar(this, false);
        }
        void HandleViewCreated(object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;

            if (gameView != null)
            {
                // This sets the game "world" resolution to 100x100:
                gameView.DesignResolution = new CCSizeI(App.ScreenWidth, App.ScreenHeight);
                gameView.ResolutionPolicy = CCViewResolutionPolicy.NoBorder;
                // GameScene is the root of the CocosSharp rendering hierarchy:
                mainScene = new MainScene(gameView);


                // Starts CocosSharp:
                gameView.RunWithScene(mainScene);
            }
        }
    }
}
