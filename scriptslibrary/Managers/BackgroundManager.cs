using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;

public class BackgroundManager : Manager
{
    private OsbSprite blurBg, mainBG;
    public void RemoveBackgrounds()
    {
        GetLayer(Layers.HitobjectBackground).CreateSprite(GetBackground(BackgroundType.Normal)).Fade(0,0);
    }

    public void SetupBackgrounds()
    {
        blurBg = GetLayer(Layers.HitobjectBackground).CreateSprite(GetBackground(BackgroundType.Blur));
        blurBg.Scale(0,854.0f / MainStoryboard.Instance.GetMapsetBitmap(GetBackground(BackgroundType.Blur)).Width);
        blurBg.Fade(0,0);

        mainBG = GetLayer(Layers.HitobjectBackground).CreateSprite(MainStoryboard.Instance.Beatmap.BackgroundPath);
        mainBG.Scale(0,854.0f / MainStoryboard.Instance.GetMapsetBitmap(GetBackground(BackgroundType.Normal)).Width);
        mainBG.Fade(0,0);
    }

    public void FadeBlur(int startTime, int endTime, double startOpacity, double endOpacity) => blurBg.Fade(startTime,endTime,startOpacity,endOpacity);
    public void FadeBlur(int time, double opacity) => blurBg.Fade(time, opacity);
    
    public void FadeRegular(int startTime, int endTime, double startOpacity, double endOpacity) => mainBG.Fade(startTime,endTime,startOpacity,endOpacity);
    public void FadeRegular(int time, double opacity) => mainBG.Fade(time, opacity);
    
    public string GetBackground(BackgroundType type)
    {
        return type.Equals(BackgroundType.Blur) ? "sb/blur.jpg" : MainStoryboard.Instance.Beatmap.BackgroundPath;
    }
}