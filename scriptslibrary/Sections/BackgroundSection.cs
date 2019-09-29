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
        // var normalBG = backgroundManager.GetBackgroundSprite(BackgroundType.War);
        var sunsetBG = backgroundManager.GetBackgroundSprite(BackgroundType.Sunset);

        //  Intro  //
        normalBG.Fade(284, 0.8);
               
       // Verse 1 //
        
        normalBG.Fade(28074, 0.7);
        normalBG.Fade(48284, 0.4);

        normalBG.Fade(50653, 50811, 0.4, 0.8);
        normalBG.Fade(66995, 67232,0.8, 0.5);

        // Kiai 1 //
         //normalBG.Fade(44698, 0.85);
        //normalBG.Fade(66641, 0);
        normalBG.Fade(68495, 0.8);
        normalBG.Fade(83653, 0.55);

        // Fast Kiai 1 //
        normalBG.Fade(88706, 0.8);
        normalBG.Fade(129127, 129206, 0.8, 0);

        // Credits //
        blurBG.Fade(129127, 129206, 0, 0.8);
        blurBG.Fade(148074,0);


        // Second Kiai //
        normalBG.Fade(149337, 0.8);
        normalBG.Fade(164495, 0.5);

        // Fast Second Kiai //
        normalBG.Fade(169548, 0.8);
        normalBG.Fade(209337,209969, 0.8, 0);

        // Guitar Solo //
        sunsetBG.Fade(209337,209969,0, 0.8);
        sunsetBG.Fade(230179, 0);

        // After Guitar Solo //
        normalBG.Fade(230179, 0.8);
        normalBG.Fade(247863, 0.5);

        // Kiai 3 //
        normalBG.Fade(250390, 0.8);
        normalBG.Fade(290811, 0);

        // Last Section //
        sunsetBG.Fade(293337, 0.8);
        sunsetBG.Fade(310706, 0);
    }
}