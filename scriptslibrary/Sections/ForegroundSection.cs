using StorybrewScripts;
using OpenTK.Graphics;
using StorybrewCommon.Storyboarding;

public class ForegroundSection : Section
{
    public ForegroundSection()
    {
        var manager = GetManager<ForegroundManager>();
        manager.generateSprites();
        // Intro //
        manager.LetterboxFade(17890, 1);
        manager.LetterboxFade(28074, 0);
        manager.LetterboxScale(OsbEasing.InOutCubic, 17890, 18206, 0, 80);
        manager.LetterboxScale(OsbEasing.InOutCubic, 26811, 28074, 80, 240);
        manager.LetterboxColor(17890,Color4.Black);

        

        // After Credits //
        manager.LetterboxScale(OsbEasing.InOutCubic, 139153, 139469, 0, 80);
        manager.LetterboxFade(139153, 1);
        manager.LetterboxFade(146811, 0);
        manager.LetterboxScale(OsbEasing.InOutCubic, 144048, 144284, 80, 150);
        manager.LetterboxScale(OsbEasing.InOutElastic, 146416, 146811, 150, 0);

        // Vignettes
        manager.vigenetteFade(284, 0.8);
        manager.vigenetteFade(10074, 10390, 0.8, 0);
        manager.vigenetteFade(50811, 0.8);
        manager.vigenetteFade(58390, 58627, 0.8, 0);
        
    }
}