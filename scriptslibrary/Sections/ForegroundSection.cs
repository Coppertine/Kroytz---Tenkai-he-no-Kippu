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
        manager.vigenetteFade(284, 679,0, 0.8);
        manager.vigenetteFade(10074, 10390, 0.8, 0);
        manager.vigenetteFade(50653, 50811,0, 0.8);
        manager.vigenetteFade(58390, 58627, 0.8, 0);
        manager.vigenetteFade(209258, 209969,0, 0.6);
        manager.vigenetteFade(220074, 0.8);
        manager.vigenetteFade(219758, 220074, 0.8, 0);

        // Flares //
        var sunsetFlare = manager.FlareSprite("sb/sunsetFlare.png");
        // var warFlare = manager.FlareSprite("sb/warFlare.png");
        var regularFlare = manager.FlareSprite("sb/flare.png");

        sunsetFlare.Move(0, new Vector2(320,0));
        
        
        sunsetFlare.Fade(26732, 28074, 0, 0.7);
        sunsetFlare.Fade(28074, 28469, 0.7, 0 );
        
        sunsetFlare.Fade(67784, 68495, 0, 0.9);
        sunsetFlare.Fade(68495, 68732, 0.9, 0);
        sunsetFlare.Fade(87995, 88706, 0, 0.95);
        sunsetFlare.Fade(88706, 89337, 0.9, 0.35);

        // kiai 1 Loop
        sunsetFlare.StartLoopGroup(89337, 7);

        sunsetFlare.Fade(0, GetBeatDuration(0,1) * 8, 0.35, 0.45);
        sunsetFlare.Fade(GetBeatDuration(0,1) * 8, GetBeatDuration(0,1) * 16, 0.45, 0.35);

        sunsetFlare.EndGroup();
        sunsetFlare.Fade(128732, 129206, 0.35, 0);

        sunsetFlare.Fade(148942, 149337, 0, 0.95);
        sunsetFlare.Fade(149337, 149732, 0.95, 0);

        sunsetFlare.Fade(47100, 48285, 0, 0.7);
        sunsetFlare.Fade(48285, 48521, 0.7, 0 );
        sunsetFlare.Fade(169153, 169548, 0, 0.95);
        sunsetFlare.Fade(169548, 170179, 0.95, 0.35);
        // kiai 2 Loop
        sunsetFlare.StartLoopGroup(170179, 7);

        sunsetFlare.Fade(0, GetBeatDuration(0,1) * 8, 0.35, 0.5);
        sunsetFlare.Fade(GetBeatDuration(0,1) * 8, GetBeatDuration(0,1) * 16, 0.5, 0.35);

        sunsetFlare.EndGroup();
        sunsetFlare.Fade(219521, 220074,0, .65);
        sunsetFlare.Fade(229784, 230179, 0.65, 0.95);
        sunsetFlare.Fade(230179, 230416, 0.95, 0);
        

        sunsetFlare.Fade(249995, 250390, 0, 0.95);
        sunsetFlare.Fade(250390, 251100, 0.95, 0.35);
        // kiai 2 Loop
        sunsetFlare.StartLoopGroup(251100, 7);

        sunsetFlare.Fade(0, GetBeatDuration(0,1) * 8, 0.35, 0.5);
        sunsetFlare.Fade(GetBeatDuration(0,1) * 8, GetBeatDuration(0,1) * 16, 0.5, 0.35);

        sunsetFlare.EndGroup();
        sunsetFlare.Fade(290416, 290811, 0.35, 0.95);
        sunsetFlare.Fade(290811, 291048, 0.95, 0);
        sunsetFlare.Additive(0,314495);

        // warFlare.Additive(0,314495);
        // warFlare.Move(0, new Vector2(320,0));
        // warFlare.Fade(88706, .6);
        // warFlare.Fade(129127, 0);

        regularFlare.Additive(0,314495);
        regularFlare.Move(0, new Vector2(320,0));
        // Pre Kiai 1 loop
        regularFlare.StartLoopGroup(68495, 8);
        regularFlare.Fade(0, GetBeatDuration(0,1) * 4, 0.4, 0.55);
        regularFlare.Fade(GetBeatDuration(0,1) * 4, GetBeatDuration(0,1) * 8, 0.55, 0.4);
        regularFlare.EndGroup();
        regularFlare.Fade(129127, 0);

        //Kiai 2
        regularFlare.Fade(169390, 169548, 0, 0.6);
        regularFlare.Fade(219758,220074, 0.6, 0);



        
        
    }
}