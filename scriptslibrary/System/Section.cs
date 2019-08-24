using StorybrewScripts;

public abstract class Section : Generator
{
    public T GetManager<T>() => MainStoryboard.Instance.Locator.Get<T>();
}