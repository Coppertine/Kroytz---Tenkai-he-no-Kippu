using StorybrewScripts;
public class BackgroundSection : Section
{
    public BackgroundSection()
    {
        var backgroundManager = GetManager<BackgroundManager>();
        backgroundManager.RemoveBackgrounds();
        backgroundManager.SetupBackgrounds();

        //  Intro  //
        backgroundManager.FadeBlur(812, 0.8);
        backgroundManager.FadeBlur(22755, 0);

       // Verse 1 //
        backgroundManager.FadeRegular(22755, 0.7);
        backgroundManager.FadeRegular(33727, 0);

        // Kiai 1 //
        backgroundManager.FadeRegular(44698, 0.85);
        backgroundManager.FadeRegular(66641, 0);
    }
}