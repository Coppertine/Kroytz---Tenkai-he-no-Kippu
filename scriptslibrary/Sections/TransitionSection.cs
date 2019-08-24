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

        // After Credits //
        afterCredits();
        
        // General Flashes //
        flashes();
    }


    public void afterCredits()
    {
        var LeftSwipeDown = transitionManager.SwipePaneNoFade(
            GetLayer(Layers.Foreground),
            OsbEasing.OutExpo, 
            SwipeDirection.Bottom, 
            "sb/pixel.png", 
            10755, 
            11098,
            new Vector2(0,0), new Vector2(214,0), new Vector2(214,480)
        );

        LeftSwipeDown.Fade(10755,1);
        LeftSwipeDown.Fade(11784,0);

        var RightSwipeUp = transitionManager.SwipePaneNoFade(
            GetLayer(Layers.Foreground),
            OsbEasing.OutExpo, 
            SwipeDirection.Top, 
            "sb/pixel.png", 
            10755, 
            11098,
            new Vector2(650,480), new Vector2(214,0), new Vector2(214,480)
        );

        RightSwipeUp.Fade(10755,1);
        RightSwipeUp.Fade(11784,0);

        var triangle = transitionManager.TriangleAnimation(GetLayer(Layers.Foreground),11098, 15);
        triangle.Fade(11098,1);
        triangle.Fade(11784,0);
        triangle.Scale(OsbEasing.OutExpo,11098,11441,0,0.5);

        triangle.Scale(OsbEasing.InBounce, 11441, 11784, 0.5, 0);
        triangle.Color(11098, Color4.Black);
    }

    public void flashes()
    {
        // Setup
        var flash = transitionManager.FullscreenFlash(GetLayer(Layers.OverlayHitobject),"sb/pixel.png");

        // After Credits //
        flash.Fade(11784, 12355, 1, 0);

        // Verse 1 //
        flash.Fade(22755, 23384, 1, 0);

        // Lets mess around with colour... // 

    #region First Spectrum
        transitionManager.ColouredFlash(flash, 33727, 34155, 0.7, 0);
        transitionManager.ColouredFlash(flash, 34412, 34841, 0.7, 0);
        transitionManager.ColouredFlash(flash, 34412, 34841, 0.7, 0);

        transitionManager.ColouredFlash(flash, 35098, 35270, 0.5, 0);
        transitionManager.ColouredFlash(flash, 35355, 35527, 0.5, 0);
        transitionManager.ColouredFlash(flash, 35612, 35741, 0.5, 0);
        transitionManager.ColouredFlash(flash, 35784, 36384, 0.7, 0);

        transitionManager.ColouredFlash(flash, 36470, 36641, 0.5, 0);
        transitionManager.ColouredFlash(flash, 36727, 36898, 0.5, 0);
        transitionManager.ColouredFlash(flash, 36984, 37112, 0.5, 0);
        transitionManager.ColouredFlash(flash, 37155, 37755, 0.7, 0);

        transitionManager.ColouredFlash(flash, 37841, 38012, 0.5, 0);
        transitionManager.ColouredFlash(flash, 38098, 38270, 0.5, 0);
        transitionManager.ColouredFlash(flash, 38355, 38527, 0.5, 0);
        transitionManager.ColouredFlash(flash, 38612, 38784, 0.5, 0);
        transitionManager.ColouredFlash(flash, 38870, 39127, 0.7, 0);

        flash.Color(39212, Color4.White);
        flash.Fade(39212, 39812, 1, 0);
    #endregion
    
    
    }
}