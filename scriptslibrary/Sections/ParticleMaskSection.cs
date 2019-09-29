using StorybrewScripts;
using OpenTK;
using OpenTK.Graphics;
public class ParticleMaskSection : Section
{
    public ParticleMaskSection()
    {
        var manager = GetManager<ParticleMaskManager>();
        
        var mask = manager.ParticleMask("sb/girl.png");
        mask.Scale(0, 854.0f / 1920);
        mask.Fade(0,0);
        mask.Fade(28074, 1);
        mask.Color(28074, new Color4(174,174,174, 255));

    
        mask.Fade(47969, 0);
        mask.Color(47969, Color4.White);
        mask.Fade(68495, 1);
        mask.Fade(83258, 83653, 1,0);
        mask.Fade(88706, 1);
        mask.Fade(129127,0);

    }
}