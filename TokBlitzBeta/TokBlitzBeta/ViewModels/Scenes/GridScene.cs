using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;
namespace TokBlitzBeta.ViewModels
{
    public class GridScene : CCScene
    {
        CCNode _box;
        CCSprite _grid;
        CCSprite GameBoard = new CCSprite();
        CCDrawNode ProfileBoard = new CCDrawNode();
        CCDrawNode LetterBoard = new CCDrawNode();
        CCDrawNode AnswerBank = new CCDrawNode();
        CCDrawNode Menus = new CCDrawNode();

        public static int RowSetter { get; set; } = 3;
        public static int ColoumnSetter { get; set; } = 3;
        public GridScene(CCGameView gameView) : base(gameView)
        {
            var layer = new CCLayerColor(CCColor4B.Transparent);
            var profilepos = (App.ScreenHeight / 5.25f);
            var boardpos = (App.ScreenHeight / 2.50f) + (App.ScreenHeight / 5f);
            var letpos = (App.ScreenHeight / 2.50f) + (App.ScreenHeight / 5f) + (App.ScreenHeight / 9f) ;
            var bankpos= (App.ScreenHeight / 2.50f) + (App.ScreenHeight / 5f) + (App.ScreenHeight / 9.25f) + (App.ScreenHeight / 5.5f);
            //var menpos = (App.ScreenHeight / 2.50f) + (App.ScreenHeight / 5f) + (App.ScreenHeight / 9.25f) + (App.ScreenHeight / 5.5f) + (App.ScreenHeight / 10f);
            this.AddLayer(layer);
            CCRect rectprof = new CCRect(0, App.ScreenHeight -profilepos, App.ScreenWidth, App.ScreenHeight / 5.25f);
          //  CCRect rect = new CCRect(0, App.ScreenHeight - boardpos, App.ScreenWidth, App.ScreenHeight / 2.50f);
            CCRect rectlet = new CCRect(0, App.ScreenHeight - letpos, App.ScreenWidth, App.ScreenHeight / 9.25f);
            CCRect recbank = new CCRect(0, App.ScreenHeight - bankpos, App.ScreenWidth, App.ScreenHeight / 5.75f);
            CCRect recmen = new CCRect(0,0, App.ScreenWidth, App.ScreenHeight / 9.5f);
          
            ProfileBoard.DrawRect(rectprof,CCColor4B.White);
            // GameBoard.DrawRect(rect,CCColor4B.Red);
            GameBoard.Position = new CCPoint(0, App.ScreenHeight - boardpos);
            GameBoard.ContentSize = new CCSize(App.ScreenWidth, App.ScreenHeight / 2.50f);
            LetterBoard.DrawRect(rectlet,CCColor4B.AliceBlue);
            AnswerBank.DrawRect(recbank,CCColor4B.Orange);
            Menus.DrawRect(recmen,CCColor4B.Green);
          
            _grid = new CCSprite("Images/Sprites/wordframe.png");
            GameboardCreation();
            layer.AddChild(GameBoard);
            layer.AddChild(ProfileBoard);
            layer.AddChild(LetterBoard);
            layer.AddChild(AnswerBank);
            layer.AddChild(Menus);
          
          
           
            
        }

        private void GameboardCreation() {
            /* CCSprite[,] box = new CCSprite[2,4];
             for (int row = 0; row < 2; row++) {
                 for (int col =0;col<4;col++) {
                     box[row, col] = new CCSprite("Images/Sprites/wordframe.png");
                     box[row, col].Position = new CCPoint(GameBoard.AnchorPoint.X,(col +1)*10);
                     GameBoard.AddChild(box[row,col]);
                 }
             }*/
            #region Test Case Grid
            
            CCSprite[,] box = new CCSprite[RowSetter, ColoumnSetter];
            CCLabel[,] texts = new CCLabel[RowSetter, ColoumnSetter];
            float DivideHeightBy2 = GameBoard.ContentSize.Height / 2, DividedWidthBy2 = GameBoard.ContentSize.Width / 2;
            float DivideHeightBy4 = GameBoard.ContentSize.Height / 4, DividedWidthBy4 = GameBoard.ContentSize.Width / 4;
            float fixedWidth = GameBoard.ContentSize.Width, fixedHeight = GameBoard.ContentSize.Height;
            float WidthDividend = 3.10f, HeightDividend = 6, AdjusterValueWidth = 1.05f, AdjusterValueHeight = 1.3f, AdjustPositionHeigth = 2.25f, AdjustPositionWidth = 2;
            float BoxWidth = 8.5f, BoxHeight = 8.5f;
            // float ExtendY = 0, ExtendX = 0;

            if (RowSetter > 5) {
                int heightControl = RowSetter - 5;
                for (int i = 0; i < heightControl; i++) {
                    HeightDividend += 1f;
                 
                    
                        AdjusterValueHeight -= .15f;
                    
               
                
                }
            }
            if (ColoumnSetter > 3)
            {
                int widthControl = ColoumnSetter - 2;
                for (int i = 0; i < widthControl; i++)
                {
                    WidthDividend += .5f;
                    if (i > 0)
                    {
                        AdjusterValueWidth -= .01f;
                    }

                }
            }
         
            float _Width = fixedWidth / WidthDividend;
            for (int row = 0; row < RowSetter; row++)
            {

                for (int col = 0; col < ColoumnSetter; col++)
                {
                    box[row, col] = new CCSprite("Images/Sprites/wordframe.png");
                    texts[row, col] = new CCLabel("BOX" + (col + row), "arial", 22f);
                    box[row, col].ContentSize = new CCSize(fixedWidth / WidthDividend, fixedHeight / HeightDividend);
                    if (row == 0)
                    {
                        if (col == 0)
                        {
                          box[row, col].Position = new CCPoint((fixedWidth / WidthDividend) / 2, fixedHeight - (fixedHeight / HeightDividend) / AdjustPositionHeigth);
                        }
                        else
                        {
                            box[row, col].Position = new CCPoint(box[row, col - 1].PositionX  + box[row, col - 1].ContentSize.Width * AdjusterValueWidth, fixedHeight - (fixedHeight / HeightDividend) / AdjustPositionHeigth);
                        }
                    }
                    else {



                        if (col == 0)
                        {
                            box[row, col].Position = new CCPoint((fixedWidth / WidthDividend) / 2, box[row - 1, col].PositionY - box[row - 1, col].ContentSize.Height * AdjusterValueHeight);
                        }
                        else
                        {
                            box[row, col].Position = new CCPoint(box[row, col - 1].PositionX + box[row, col - 1].ContentSize.Width * AdjusterValueWidth, box[row - 1, col].PositionY - box[row - 1, col].ContentSize.Height * AdjusterValueHeight);
                        }


                    }
                    texts[row, col].Position = new CCPoint(box[row, col].ContentSize.Width / 2, box[row, col].ContentSize.Height / 2);
                    GameBoard.AddChild(box[row, col]);
                    box[row, col].AddChild(texts[row, col]);

                }

            }

            #endregion
            #region Sample Codes
            /*
         
                switch (col)
                            {
                                case 0: box[row, col].Position = new CCPoint((fixedWidth / WidthDividend) / 2, box[row - 1, col].PositionY - box[row - 1, col].ContentSize.Height * AdjusterValueHeight); break;
                                case 1: box[row, col].Position = new CCPoint(DividedWidthBy2, box[row - 1, col].PositionY - box[row - 1, col].ContentSize.Height * AdjusterValueHeight); break;
                                case 2: box[row, col].Position = new CCPoint(fixedWidth - (fixedWidth / WidthDividend) / 2, box[row - 1, col].PositionY - box[row - 1, col].ContentSize.Height * AdjusterValueHeight); break;        
                            }
            var text1 = new CCLabel("BOX1","arial",22f);
           var text2 = new CCLabel("BOX2", "arial", 22f);
           var text3 = new CCLabel("BOX3", "arial", 22f);
           var text4 = new CCLabel("BOX4", "arial", 22f);
           var text5 = new CCLabel("BOX5", "arial", 22f);
           var text6 = new CCLabel("BOX6", "arial", 22f);
           var text7 = new CCLabel("BOX7", "arial", 22f);
           var text8 = new CCLabel("BOX8", "arial", 22f);
           var text9 = new CCLabel("BOX9", "arial", 22f);

           float DividedHeight = GameBoard.ContentSize.Height / 2;
           float fixedWidth = GameBoard.ContentSize.Width / 3.75f, fixedHeight = GameBoard.ContentSize.Height / 6;
           CCSprite box1 = new CCSprite("Images/Sprites/wordframe.png");
           box1.ContentSize = new CCSize(fixedWidth ,fixedHeight);
           box1.Position = new CCPoint(fixedWidth/2, fixedHeight /2);

           text1.Position = new CCPoint(box1.ContentSize.Width /2, box1.ContentSize.Height /2) ;
           box1.AddChild(text1);
           GameBoard.AddChild(box1);
           CCSprite box2 = new CCSprite("Images/Sprites/wordframe.png");
           box2.ContentSize = new CCSize(fixedWidth, fixedHeight);
           box2.Position = new CCPoint(GameBoard.ContentSize.Width / 2, fixedHeight / 2);

           text2.Position = new CCPoint(box2.ContentSize.Width / 2, box2.ContentSize.Height / 2);
           box2.AddChild(text2);
           GameBoard.AddChild(box2);
           CCSprite box3 = new CCSprite("Images/Sprites/wordframe.png");
           box3.ContentSize = new CCSize(fixedWidth, fixedHeight);
           box3.Position = new CCPoint(GameBoard.ContentSize.Width - fixedWidth / 2, fixedHeight / 2);

           text3.Position = new CCPoint(box2.ContentSize.Width / 2, box2.ContentSize.Height / 2);
           box3.AddChild(text3);
           GameBoard.AddChild(box3);
           //=================================================================//s
           CCSprite box4 = new CCSprite("Images/Sprites/wordframe.png");
           box4.ContentSize = new CCSize(fixedWidth, fixedHeight);
           box4.Position = new CCPoint(fixedWidth / 2,GameBoard.ContentSize.Height - fixedHeight/2);

           text4.Position = new CCPoint(box4.ContentSize.Width / 2, box4.ContentSize.Height / 2);
           box4.AddChild(text4);
           GameBoard.AddChild(box4);
           CCSprite box5 = new CCSprite("Images/Sprites/wordframe.png");
           box5.ContentSize = new CCSize(fixedWidth, fixedHeight);
           box5.Position = new CCPoint(GameBoard.ContentSize.Width / 2, GameBoard.ContentSize.Height - fixedHeight / 2);

           text5.Position = new CCPoint(box5.ContentSize.Width / 2, box5.ContentSize.Height / 2);
           box5.AddChild(text5);
           GameBoard.AddChild(box5);
           CCSprite box6 = new CCSprite("Images/Sprites/wordframe.png");
           box6.ContentSize = new CCSize(fixedWidth, fixedHeight);
           box6.Position = new CCPoint(GameBoard.ContentSize.Width - fixedWidth / 2, GameBoard.ContentSize.Height - fixedHeight / 2);

           text6.Position = new CCPoint(box6.ContentSize.Width / 2, box6.ContentSize.Height / 2);
           box6.AddChild(text6);
           GameBoard.AddChild(box6);

           //=================================================================//s
           CCSprite box7 = new CCSprite("Images/Sprites/wordframe.png");
           box7.ContentSize = new CCSize(fixedWidth, fixedHeight);
           box7.Position = new CCPoint(fixedWidth / 2,box4.PositionY - box4.ContentSize.Height *1.5f );
           //  GameBoard.ContentSize.Height - fixedHeight/.6f
           text7.Position = new CCPoint(box7.ContentSize.Width / 2, box7.ContentSize.Height / 2);
           box7.AddChild(text7);
           GameBoard.AddChild(box7);
           CCSprite box8 = new CCSprite("Images/Sprites/wordframe.png");
           box8.ContentSize = new CCSize(fixedWidth, fixedHeight);
           box8.Position = new CCPoint(GameBoard.ContentSize.Width / 2, GameBoard.ContentSize.Height/2);

           text8.Position = new CCPoint(box8.ContentSize.Width / 2, box8.ContentSize.Height / 2);
           box8.AddChild(text8);
           GameBoard.AddChild(box8);
           CCSprite box9 = new CCSprite("Images/Sprites/wordframe.png");
           box9.ContentSize = new CCSize(fixedWidth, fixedHeight);
           box9.Position = new CCPoint(GameBoard.ContentSize.Width - fixedWidth / 2, GameBoard.ContentSize.Height/2);

           text9.Position = new CCPoint(box9.ContentSize.Width / 2, box9.ContentSize.Height / 2);
           box9.AddChild(text9);
           GameBoard.AddChild(box9);
           */
            #endregion
        }
    }
}
