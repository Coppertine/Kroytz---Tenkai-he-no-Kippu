using StorybrewScripts;
using StorybrewCommon.Storyboarding;
using OpenTK;
using OpenTK.Graphics;
public class TransitionSection : Section
{
    private TransitionManager transitionManager;
    public TransitionSection()
    {   
        transitionManager = GetManager<TransitionManager>();

            
        // General Flashes //
        flashes();
        
    }


    

    public void flashes()
    {
        // Setup
        var flash = transitionManager.FullscreenFlash(GetLayer(Layers.OverlayHitobject),"sb/pixel.png");
        var bgFlash = transitionManager.BackgroundOverlayPopup(GetLayer(Layers.OverlayHitobject), "BG.jpg");
        var bgWarFlash = transitionManager.BackgroundOverlayPopup(GetLayer(Layers.OverlayHitobject),"sb/bg/red.jpg");
        var bgSunsetFlash = transitionManager.BackgroundOverlayPopup(GetLayer(Layers.OverlayHitobject), "sb/bg/sunset.png");

        // Intro //
        bgFlash.Fade(10390, 10784, 0.7, 0);
        bgFlash.Scale(10390, 10784, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25,
        854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width);

        // Verse 1 //
        flash.Fade(28074, 28627, 1, 0);

        // 50811 //
        bgSunsetFlash.Fade(50811, 51206, 0.7, 0);
        bgSunsetFlash.Scale(50811, 51206, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25,
        854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width);

        // Kiai 1 //
        // 68495
        bgFlash.Fade(68495, 68732, 0.7, 0);
        bgFlash.Scale(68495, 68732, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25,
        854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width);
        //83653
        bgFlash.Fade(83653, 83890, 0.7, 0);
        bgFlash.Scale(OsbEasing.OutExpo,83653, 83890, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);

        //88706
        bgWarFlash.Fade(88706, 88942, 0.7, 0);
        bgWarFlash.Scale(OsbEasing.OutCubic, 88706, 88942, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);
    
    
    }
}