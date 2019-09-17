using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;

public class ForegroundManager : Manager
{
    private OsbSprite vigenette;
    private OsbSprite[] Letterbox = new OsbSprite[2];

    public void generateSprites()
    {
        vigenette = GetLayer(Layers.Overlay).CreateSprite("sb/v.png");
        vigenette.Scale(0,480.0f/1080f);
        vigenette.Fade(0,0);


        //0 = Top
        //1 = bottom
        Letterbox[0] = GetLayer(Layers.Foreground).CreateSprite("sb/pixel.png",OsbOrigin.TopCentre, new Vector2(320, 0));
        Letterbox[1] = GetLayer(Layers.Foreground).CreateSprite("sb/pixel.png",OsbOrigin.BottomCentre, new Vector2(320, 480));
    }

    public void vigenetteFade(double start, double end, double startOpa, double endOpacity) => 
        vigenette.Fade(start,end,startOpa,endOpacity);
    public void vigenetteFade(double start, double opacity) => 
        vigenette.Fade(start,opacity);

    public void LetterboxScale(OsbEasing easing , double start, double end, double startScale, double endScale) 
    {
        Letterbox[0].ScaleVec(easing, start,end,new Vector2(854, (float)startScale),new Vector2(854, (float)endScale));
        Letterbox[1].ScaleVec(easing, start, end, new Vector2(854, (float)startScale),new Vector2(854, (float)endScale));
    }

    public void LetterboxScale(double start, double scale) 
    {
        Letterbox[0].ScaleVec(start, new Vector2(854, (float)scale));
        Letterbox[1].ScaleVec(start,new Vector2(854, (float)scale));
    }

    public void vigenetteColor(double start, double end, Color4 startColor, Color4 endColor) =>
        vigenette.Color(start,end,startColor,endColor);
    
    public void vigenetteColor(double start, Color4 color) =>
        vigenette.Color(start,color);
    
    public void LetterboxColor(double start, double end, Color4 colorStart, Color4 colorEnd) 
    {
        Letterbox[0].Color(start, end, colorStart, colorEnd);
        Letterbox[1].Color(start, end, colorStart, colorEnd);
    }

    public void LetterboxColor(double start, Color4 Color) 
    {
        Letterbox[0].Color(start,Color);
        Letterbox[1].Color(start,Color);
    }

    public void LetterboxFade(double start, double end, double fadeStart, double fadeEnd) 
    {
        Letterbox[0].Fade(start, end, fadeStart, fadeEnd);
        Letterbox[1].Fade(start, end, fadeStart, fadeEnd);
    }

    public void LetterboxFade(double start, double opa) 
    {
        Letterbox[0].Fade(start,opa);
        Letterbox[1].Fade(start,opa);
    }

    public OsbSprite FlareSprite(string filePath) 
    {
        OsbSprite sprite = GetLayer(Layers.Overlay).CreateSprite(filePath);
        sprite.Scale(0,1);
        sprite.Fade(0,0);
        return sprite;
    }
}