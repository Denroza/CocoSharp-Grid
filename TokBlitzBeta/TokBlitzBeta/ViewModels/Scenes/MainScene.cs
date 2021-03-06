﻿using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;
using TokBlitzBeta;
namespace TokBlitzBeta.ViewModels
{
    public class MainScene : CCScene
    {
        CCSprite _background;
        CCSprite _logo;
        public MainScene(CCGameView gameView) : base(gameView)
        {
            var layer = new CCLayerColor(CCColor4B.Transparent);
            this.AddLayer(layer);
            _background = new CCSprite("Images/Background/bg.png");
            _logo = new CCSprite("Images/Sprites/logo_tokblitz.png");
            _logo.setSizeLogoLarge();
            _logo.Position = new CCPoint(App.ScreenWidth / 2, App.ScreenHeight / 2);
            _background.ContentSize = CustomSize.FullScreen;
            _background.Position = new CCPoint(App.ScreenWidth/2,App.ScreenHeight/2);
            layer.AddChild(_background);
            _background.AddChild(_logo);
        }
    }
}
