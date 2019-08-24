using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;
using StorybrewCommon.Subtitles;
using OpenTK;
using OpenTK.Graphics;

public class CreditManager : Manager
{   
    private FontGenerator font;
    
    public void GenerateCollab()
    {
        // startTime = 812
        // start of difficulty = 6298

        CreateLine();

        CreateCredit(GetLayer(Layers.Foreground), 129127, 131653, "天界への切符", "Dragon Guardian");
        CreateCredit(GetLayer(Layers.HitobjectBackground), 131653, 134179, GetMapDiff()[0], GetMapDiff()[1]);
        CreateCredit(GetLayer(Layers.Foreground), 134179, 137969, "Storyboard", "Coppertine");
        
    }

    public void CreateLine()
    {
        var bar = GetLayer(Layers.Foreground).CreateSprite("sb/pixel.png");
        bar.ScaleVec(OsbEasing.OutExpo, 129127, 129521, new Vector2(0,5), new Vector2(450,5));
        bar.ScaleVec(OsbEasing.OutExpo, 137653, 137969, new Vector2(450,5), new Vector2(0,5));
        bar.Fade(129127,1);
        bar.Fade(137969,0);
        bar.Color(129127,Color4.White);
    }

    #region TEXT

    public void CreateCredit(StoryboardLayer layer, double startTime, double endTime, string topString, string bottomString)
    {

        // Top Sprite //
        var topSprite = layer.CreateSprite(font.GetTexture(topString).Path);
        topSprite.MoveY(startTime,240 - (font.GetTexture(topString).BaseHeight * 0.55) * 0.7);
        topSprite.Fade(startTime, startTime + 250, 0, 1);
        topSprite.Fade(endTime - 250, endTime, 1,0);
        topSprite.Scale(startTime,0.55);
        topSprite.MoveX(OsbEasing.OutExpo, startTime, startTime + 250, 400, 325);  
        topSprite.MoveX(startTime + 250, endTime - 250, 325, 300);
        topSprite.MoveX(OsbEasing.InOutCubic, endTime - 250, endTime, 300, 250);
        

        // Bottom Sprite //
        var bottomSprite = layer.CreateSprite(font.GetTexture(bottomString).Path);
            
        bottomSprite.MoveY(startTime,240 + (font.GetTexture(bottomString).BaseHeight * 0.55)* 0.7);
        bottomSprite.Fade(startTime, startTime + 250, 0, 1);
        bottomSprite.Fade(endTime - 250, endTime, 1,0);
        bottomSprite.Scale(startTime,0.55);
        bottomSprite.MoveX(OsbEasing.OutExpo,startTime, startTime + 250, 250, 300);  
        bottomSprite.MoveX(startTime + 250, endTime - 250, 300, 325);
        bottomSprite.MoveX(OsbEasing.InOutCubic,endTime - 250, endTime, 325, 400);

    }
    public void SetupFont()
    {
        font = LoadFont("sb/f/c", new FontDescription(){
            FontPath = "fonts/Montserrat-Light.ttf",
            FontSize = 38,
          
        });

        string[] creditList = {
            "Tenkai", "Kroytz"
        };

        foreach(string credit in creditList)
        {
            font.GetTexture(credit);
        }
    }

    public string[] GetMapDiff()
    {
        
        return new string[2] {"Tenkai", "Kroytz"};
    }

    #endregion
}