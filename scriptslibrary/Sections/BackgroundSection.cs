using StorybrewScripts;
public class BackgroundSection : Section
{
    public BackgroundSection()
    {
        var backgroundManager = GetManager<BackgroundManager>();
        backgroundManager.RemoveBackgrounds();
        
        // Set up Backgrounds //
        var normalBG = backgroundManager.GetBackgroundSprite(BackgroundType.Normal);
        var blurBG = backgroundManager.GetBackgroundSprite(BackgroundType.Blur);
        var warBG = backgroundManager.GetBackgroundSprite(BackgroundType.War);
        var sunsetBG = backgroundManager.GetBackgroundSprite(BackgroundType.Sunset);

        //  Intro  //
        normalBG.Fade(284, 0.8);
        normalBG.Fade(17732, 17969, 0.8, 0);
        blurBG.Fade(17732, 17969, 0, 0.8);

       // Verse 1 //
        blurBG.Fade(28074,0);
        normalBG.Fade(28074, 0.7);
        normalBG.Fade(48284, 0);

        sunsetBG.Fade(50811, 0.8);
        sunsetBG.Fade(67232, 0);

        // Kiai 1 //
         //normalBG.Fade(44698, 0.85);
        //normalBG.Fade(66641, 0);
        normalBG.Fade(68495, 0.8);
        normalBG.Fade(83653, 0.55);
        normalBG.Fade(88706, 0);

        // Fast Kiai 1 //
        warBG.Fade(88706, 0.8);
        warBG.Fade(129127, 129206, 0.8, 0);

        // Credits //
        blurBG.Fade(129127, 129206, 0, 0.8);
        blurBG.Fade(148074,0);


        // Second Kiai //
        normalBG.Fade(149337, 0.8);
        normalBG.Fade(164495, 0.5);
        normalBG.Fade(169548, 0);

        // Fast Second Kiai //
        warBG.Fade(169548, 0.8);
        warBG.Fade(209969, 0);

        // Guitar Solo //
        sunsetBG.Fade(209969, 0.8);
        sunsetBG.Fade(230179, 0);
    }
}