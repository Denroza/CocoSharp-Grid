using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TokBlitzBeta.ViewModels;
using CocosSharp;

namespace TokBlitzBeta.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
        MainScene mainScene;
        public Main()
        {
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
                gameView.ResolutionPolicy = CCViewResolutionPolicy.ShowAll;
                // GameScene is the root of the CocosSharp rendering hierarchy:
                mainScene = new MainScene(gameView);


                // Starts CocosSharp:
                gameView.RunWithScene(mainScene);
            }
        }
    }
}