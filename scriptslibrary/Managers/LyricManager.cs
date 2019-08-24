using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;
using StorybrewCommon.Subtitles;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;
public class LyricManager : Manager
{
    public FontGenerator GetFont(LyricFont fontType)
    {
        return LoadFont($"sb/f/{GetFontString(fontType)}", new FontDescription {
            FontPath = GetFontPath(fontType),
            FontSize = 30
        });
    }

    public List<Lyric> LoadLyric(string filePath)
    {
        return JsonConvert.DeserializeObject<List<Lyric>>(File.ReadAllText($"{MainStoryboard.Instance.ProjectPath}/{filePath}"));
    }

    public void CreateLyrics(FontGenerator font, List<Lyric> lyrics, LyricGeneration lyricType)
    {
        
    }
}