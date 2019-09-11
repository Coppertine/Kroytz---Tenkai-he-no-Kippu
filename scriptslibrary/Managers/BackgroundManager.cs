using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;

public class BackgroundManager : Manager
{
    
    public void RemoveBackgrounds()
    {
        GetLayer(Layers.HitobjectBackground).CreateSprite(GetBackground(BackgroundType.Normal)).Fade(0,0);
    }

    public OsbSprite GetBackgroundSprite(BackgroundType type) 
    {
        OsbSprite sprite = GetLayer(Layers.HitobjectBackground).CreateSprite(GetBackground(type));
        sprite.Scale(0,854.0f / MainStoryboard.Instance.GetMapsetBitmap(GetBackground(type)).Width);
        sprite.Fade(0,0);
        return sprite;        
    }

        
    private string GetBackground(BackgroundType type)
    {
        switch(type)
        {
            case BackgroundType.Blur:
                return "sb/bg/blur.jpg";
            case BackgroundType.War:
                return "sb/bg/red.jpg";
            case BackgroundType.Sunset:
                return "sb/bg/sunset.png";
            case BackgroundType.Normal:
                return MainStoryboard.Instance.Beatmap.BackgroundPath;
            default:
                return "";
        }
    }
}