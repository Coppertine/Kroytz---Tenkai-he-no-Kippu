using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;

public class BackgroundManager : Manager
{
    private OsbSprite blurBg, mainBG;
    public void RemoveBackgrounds()
    {
        GetLayer(Layers.HitobjectBackground).CreateSprite(MainStoryboard.Instance.Beatmap.BackgroundPath).Fade(0,0);
    }

    public void SetupBackgrounds()
    {
        blurBg = GetLayer(Layers.HitobjectBackground).CreateSprite(GetBackground(BackgroundType.Blur));
        blurBg.Scale(0,480.0f / MainStoryboard.Instance.GetMapsetBitmap(GetBackground(BackgroundType.Blur)).Height);
        blurBg.Fade(0,0);

        mainBG = GetLayer(Layers.HitobjectBackground).CreateSprite(MainStoryboard.Instance.Beatmap.BackgroundPath);
        mainBG.Scale(0,480.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Height);
        mainBG.Fade(0,0);
    }

    public void FadeBlur(int startTime, int endTime, double startOpacity, double endOpacity) => blurBg.Fade(startTime,endTime,startOpacity,endOpacity);
    public void FadeBlur(int time, double opacity) => blurBg.Fade(time, opacity);
    
    public void FadeRegular(int startTime, int endTime, double startOpacity, double endOpacity) => mainBG.Fade(startTime,endTime,startOpacity,endOpacity);
    public void FadeRegular(int time, double opacity) => mainBG.Fade(time, opacity);
    
    public string GetBackground(BackgroundType type)
    {
        string bg = "";
        if(type == BackgroundType.Blur)
        {
            switch(MainStoryboard.Instance.Beatmap.Name)
            {
                case "Little's Advanced":
                case "Dailycare's Insane":
                    bg = "sb/bg/little_blur.jpg";
                    break;
                case "Sing's Another":
                    bg = "sb/bg/sing_blur.jpg";
                    break;
                case "Skystar's Eternal Dream":
                case "Skystar's Eternal dream":
                    bg = "sb/bg/Skystar_blur.jpg";
                    break;
                case "Deppy's Light Insane":
                case "Loli's Extra":
                    bg = "sb/bg/g_blur.jpg";
                    break;
                case "Regou's Extra":
                    bg = "sb/bg/Regou_blur.jpg";
                    break;
                default:
                    bg = "sb/bg/main_blur.jpg";
                    break;

            }
        }

        return bg;
    }
}