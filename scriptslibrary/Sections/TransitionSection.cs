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
       // flashes();
        
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

        // Kiai 2 //
        // 149337 //
        bgFlash.Fade(149337, 149574, 0.7, 0);
        bgFlash.Scale(OsbEasing.OutExpo,149337, 149574, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);

        // 164495
        bgFlash.Fade(164495, 164732, 0.7, 0);
        bgFlash.Scale(OsbEasing.OutExpo,164495, 164732, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);

        // Fast Kiai 2 //
        // 169548
        bgWarFlash.Fade(169548, 169784, 0.7, 0);
        bgWarFlash.Scale(OsbEasing.OutCubic, 169548, 169784, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);

        // 209969
        bgSunsetFlash.Fade(209969, 210206, 0.7, 0);
        bgSunsetFlash.Scale(209969, 210206, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);

        // 220074
        bgSunsetFlash.Fade(220074, 220311, 0.7, 0);
        bgSunsetFlash.Scale(220074, 220311, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);

        // After Guitar Solo //
        // 230179
        bgFlash.Fade(230179, 230416, 0.7, 0);
        bgFlash.Scale(OsbEasing.OutExpo,230179, 230416, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);

        // 247863
        bgFlash.Fade(247863, 248100, 0.7, 0);
        bgFlash.Scale(OsbEasing.OutExpo,247863, 248100, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);


        // Fast Kiai 2
        // 250390
        bgWarFlash.Fade(250390, 250627, 0.7, 0);
        bgWarFlash.Scale(OsbEasing.OutCubic, 250390, 250627, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);

        // 290811
        bgWarFlash.Fade(290811, 291048, 0.7, 0);
        bgWarFlash.Scale(OsbEasing.OutCubic, 290811, 291048, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);

        // 293337
        bgSunsetFlash.Fade(293337, 293574, 0.7, 0);
        bgSunsetFlash.Scale(293337, 293574, 
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width),
        (854.0f / MainStoryboard.Instance.GetMapsetBitmap(MainStoryboard.Instance.Beatmap.BackgroundPath).Width) * 1.25);
    }
}