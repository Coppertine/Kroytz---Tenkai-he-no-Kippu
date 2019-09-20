using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;

public class ParticleMaskManager : Manager
{
    public OsbSprite ParticleMask(string filePath)
    {
        return GetLayer(Layers.Foreground).CreateSprite(filePath);
    }
}