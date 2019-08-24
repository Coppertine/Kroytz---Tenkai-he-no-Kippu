using StorybrewScripts;
public class BackgroundSection : Section
{
    public BackgroundSection()
    {
        var backgroundManager = GetManager<BackgroundManager>();
        backgroundManager.RemoveBackgrounds();
        backgroundManager.SetupBackgrounds();

        //  Intro  //
        backgroundManager.FadeRegular(284, 0.8);
        backgroundManager.FadeRegular(17732, 17969, 0.8, 0);
        backgroundManager.FadeBlur(17732, 17969, 0, 0.8);

       // Verse 1 //
       backgroundManager.FadeBlur(28074,0);
        backgroundManager.FadeRegular(28074, 0.7);
        backgroundManager.FadeRegular(48284, 0);

        // Kiai 1 //
        // backgroundManager.FadeRegular(44698, 0.85);
        // backgroundManager.FadeRegular(66641, 0);


        // Credits //
        backgroundManager.FadeBlur(129127, 0.8);
        backgroundManager.FadeBlur(148074,0);
    }
}