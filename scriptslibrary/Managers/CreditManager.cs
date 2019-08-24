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

        CreateCredit(GetLayer(Layers.Foreground), 812, 6298, "嗚呼 絢爛の泡沫(ゆめ)が如く", "ういにゃす・おっちょこバニー | Epsilon");
        CreateCredit(GetLayer(Layers.HitobjectBackground), 6298, 9041, GetMapDiff()[0], GetMapDiff()[1]);
        CreateCredit(GetLayer(Layers.Foreground), 9041, 10412, "Storyboard", "Coppertine");
        
    }

    public void CreateLine()
    {
        var bar = GetLayer(Layers.Foreground).CreateSprite("sb/pixel.png");
        bar.ScaleVec(OsbEasing.OutExpo, 812, 1412, new Vector2(0,5), new Vector2(450,5));
        bar.ScaleVec(OsbEasing.OutExpo, 10412, 10755, new Vector2(450,5), new Vector2(450,500));
        bar.Fade(812,1);
        bar.Fade(11784,0);
        bar.Color(812,Color4.White);
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
            "Easy","Normal", "Advanced", "Hard", "Light Insane", "Insane", " Another", "Extra", "Eternal Dream",
            "GIDZ", "Flask", "Little", "Lasse | Nao Tomori", "Deppyforce", "SnowNino_ | Hey lululu", "Matha",
            "Sing", "xLolicore-", "Regou", "Skystar"
        };

        foreach(string credit in creditList)
        {
            font.GetTexture(credit);
        }
    }

    public string[] GetMapDiff()
    {
        string[] tmp = new string[2];

        switch(MainStoryboard.Instance.Beatmap.Name)
        {
            case "Easy":
                tmp[0] = "Easy";
                tmp[1] = "GIDZ";
                break;
            case "Flask's Normal":
                tmp[0] = "Normal";
                tmp[1] = "Flask";
                break;
            case "Little's Advanced":
                tmp[0] = "Advanced";
                tmp[1] = "Little";
                break;
            case "Naosse's Hard":
                tmp[0] = "Hard";
                tmp[1] = "Lasse | Nao Tomori";
                break;
            case "Deppy's Light Insane":
                tmp[0] = "Light Insane";
                tmp[1] = "Deppyforce";
                break;
            case "Dailycare's Insane":
                tmp[0] = "Insane";
                tmp[1] = "Dailycare";
                break;
            case "HeyNino's Insane":
                tmp[0] = "Insane";
                tmp[1] = "SnowNino_ | Hey lululu";
                break;
            case "Matha's Insane":
                tmp[0] = "Insane";
                tmp[1] = "Matha";
                break;
            case "Sing's Another":
                tmp[0] = "Another";
                tmp[1] = "Sing";
                break;
            case "Extra":
                tmp[0] = "Extra";
                tmp[1] = "GIDZ";
                break;
            case "Loli's Extra":
                tmp[0] = "Extra";
                tmp[1] = "xLolicore-";
                break;
            case "Regou's Extra":
                tmp[0] = "Extra";
                tmp[1] = "Regou";
                break;
            case "Skystar's Eternal Dream":
                tmp[0] = "Eternal Dream";
                tmp[1] = "Skystar";
                break;
            default:
                break;
        }
        return tmp;
    }

    #endregion
}