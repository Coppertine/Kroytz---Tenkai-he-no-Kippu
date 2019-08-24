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

        // Verse 1 //
        flash.Fade(28074, 28627, 1, 0);

        //  //
        //flash.Fade(22755, 23384, 1, 0);

        
    
    
    }
}