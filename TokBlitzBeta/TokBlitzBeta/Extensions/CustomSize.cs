using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;
using Xamarin.Forms;
namespace TokBlitzBeta
{
   public static class CustomSize
    {
        public static CCSprite setSizeLogoLarge(this CCSprite sprite,float width = 150, float height = -150) {
            sprite.ContentSize = new CCSize((App.ScreenWidth/2) + width,(App.ScreenHeight/2) + height);
            return sprite;
        }

      
        public static CCSize FullScreen { get {
                return new CCSize(App.ScreenWidth, App.ScreenHeight);
            } }

    }
}
