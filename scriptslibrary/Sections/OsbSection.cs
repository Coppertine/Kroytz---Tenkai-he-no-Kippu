using StorybrewScripts;
public class OsbSection : Section
{
    public OsbSection()
    {
        var manager = GetManager<OsbManager>();
        manager.ImportOsb("osbs/lyrics.osb");

    }
}