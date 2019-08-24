using System;
using System.Collections.Generic;
using StorybrewScripts;

public class ManagerLocator
{
    private Dictionary<Type, object> references = new Dictionary<Type, object>();
    public T Get<T>() => (T)references[typeof(T)];
    public void Register<T>(T obj) => references.Add(typeof(T), obj);
}