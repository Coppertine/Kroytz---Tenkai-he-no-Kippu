using StorybrewScripts;
using OpenTK.Graphics;
using StorybrewCommon.Storyboarding;
using OpenTK;

public class ForegroundSection : Section
{
    public ForegroundSection()
    {
        var manager = GetManager<ForegroundManager>();
        manager.generateSprites();
        // Intro //
        // manager.LetterboxFade(17890, 1);
        // manager.LetterboxFade(28074, 0);
        // manager.LetterboxScale(OsbEasing.InOutCubic, 17890, 18206, 0, 80);
        // manager.LetterboxScale(OsbEasing.InOutCubic, 26811, 28074, 80, 240);
        // manager.LetterboxColor(17890,Color4.Black);

        

        // // After Credits //
        // manager.LetterboxScale(OsbEasing.InOutCubic, 139153, 139469, 0, 80);
        // manager.LetterboxFade(139153, 1);
        // manager.LetterboxFade(146811, 0);
        // manager.LetterboxScale(OsbEasing.InOutCubic, 144048, 144284, 80, 150);
        // manager.LetterboxScale(OsbEasing.InOutElastic, 146416, 146811, 150, 0);

        // // Ending
        // manager.LetterboxScale(OsbEasing.InOutCubic, 305811, 305969, 0, 80);
        // manager.LetterboxFade(305811, 1);
        // manager.LetterboxFade(310706, 0);
        // manager.LetterboxScale(OsbEasing.InOutCubic, 310548, 310706, 80, 240);
        
        // Vignettes
        manager.vigenetteFade(284, 0.8);
        manager.vigenetteFade(10074, 10390, 0.8, 0);
        manager.vigenetteFade(50811, 0.8);
        manager.vigenetteFade(58390, 58627, 0.8, 0);
        manager.vigenetteFade(209969, 0.6);
        manager.vigenetteFade(220074, 220271, 0.6, 0);

        // Flares //
        var sunsetFlare = manager.FlareSprite("sb/sunsetFlare.png");
        var warFlare = manager.FlareSprite("sb/warFlare.png");

        sunsetFlare.Move(0, new Vector2(320,0));
        sunsetFlare.Fade(220074, .6);
        sunsetFlare.Fade(230179,0);
        sunsetFlare.Additive(0,314495);

        warFlare.Additive(0,314495);
        warFlare.Move(0, new Vector2(320,0));
        warFlare.Fade(88706, .6);
        warFlare.Fade(129127, 0);


        
        
    }
}