using StorybrewScripts;
using OpenTK.Graphics;
using StorybrewCommon.Storyboarding;

public class ForegroundSection : Section
{
    public ForegroundSection()
    {
        var manager = GetManager<ForegroundManager>();
        manager.generateSprites();

        manager.LetterboxFade(17890, 1);
        manager.LetterboxFade(28074, 0);
        manager.LetterboxScale(OsbEasing.InOutCubic, 17890, 18206, 0, 80);
        manager.LetterboxScale(OsbEasing.InOutCubic, 26811, 28074, 80, 240);
        manager.LetterboxColor(17890,Color4.Black);

        manager.vigenetteFade(284, 0.8);
        manager.vigenetteFade(10074, 10390, 0.8, 0);

        
    }
}