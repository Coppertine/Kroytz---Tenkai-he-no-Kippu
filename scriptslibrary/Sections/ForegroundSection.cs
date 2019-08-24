using StorybrewScripts;
using OpenTK.Graphics;
using StorybrewCommon.Storyboarding;

public class ForegroundSection : Section
{
    public ForegroundSection()
    {
        var manager = GetManager<ForegroundManager>();
        manager.generateSprites();

        manager.LetterboxFade(11784, 1);
        manager.LetterboxFade(22755, 0);
        manager.LetterboxScale(11784, 80);
        manager.LetterboxScale(OsbEasing.InOutCubic, 22070, 22412, 80, 240);
        manager.LetterboxColor(11784,Color4.Black);

        manager.vigenetteFade(812, 0.8);
        manager.vigenetteFade(11784, 12212, 0.8, 0);

        
    }
}