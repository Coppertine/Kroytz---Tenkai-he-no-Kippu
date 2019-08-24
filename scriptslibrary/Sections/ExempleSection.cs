using StorybrewScripts;
public class ExampleSection : Section
{
    public ExampleSection()
    {
        var exampleManager = GetManager<ExampleManager>();
        exampleManager.ExampleEffect();
    }
}