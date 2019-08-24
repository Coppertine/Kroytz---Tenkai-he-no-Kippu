using OpenTK;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;
using System;
using StorybrewCommon.Subtitles;
using Newtonsoft.Json;

public abstract class Generator
{
    public MainStoryboard Storyboard = MainStoryboard.Instance;
    public StoryboardLayer GetLayer(Layers layer)
    {
        string layerName = Enum.GetName(typeof(Layers), layer);
        return MainStoryboard.Instance.GetLayer(layerName);
    }
    public void Log(string message)
    {
        MainStoryboard.Instance.Log($"[{this.GetType().Name}]");
        MainStoryboard.Instance.Log(message.ToString());
        MainStoryboard.Instance.Log(" ");
    }

    public FontGenerator LoadFont(string directory, FontDescription description, params FontEffect[] effects)
    {
        return MainStoryboard.Instance.LoadFont(directory,description,effects);
    }

            
    public int Random(int minValue, int maxValue) => MainStoryboard.Instance.Random(minValue, maxValue);
    public int Random(int maxValue) => MainStoryboard.Instance.Random(maxValue);
    public double Random(double minValue, double maxValue) => MainStoryboard.Instance.Random(minValue, maxValue);
    public double Random(double maxValue) => MainStoryboard.Instance.Random(maxValue);

        
    public int GetBeatDuration(int startTime, double divisor)
    {

        return Convert.ToInt32(MainStoryboard.Instance.Beatmap.GetTimingPointAt(startTime).BeatDuration / divisor);
    }

    public double GetOffset(int sTime) => MainStoryboard.Instance.Beatmap.GetTimingPointAt(sTime).Offset;

    public float[] GetFft(double time, string path = null) => MainStoryboard.Instance.GetFft(time,path);
    public float[] GetFft(double time, int magnitudes, string path = null, OsbEasing easing = OsbEasing.None) => MainStoryboard.Instance.GetFft(time,magnitudes,path,easing);

    public bool InTime(int TimeOne, int TimeTwo, int offset)
    {   
        
        bool value = TimeOne >= TimeTwo - offset && TimeOne < TimeTwo + offset;
       
        return value;
    }

    public bool InTime(int startTime, int TimeOne, int TimeTwo, int offset)
    {   
        
        bool value = startTime >= TimeOne - offset && startTime < TimeTwo + offset;
       
        return value;
    }

    public class Lyric {

        [JsonProperty("sentence")] 
        public string sentence {get; set;}

        [JsonProperty("startTime")]
        public int startTime {get; set;}

        [JsonProperty("endTime")]
        public int endTime {get; set;}

        [JsonProperty("x")]
        public int posX {get; set;}

        [JsonProperty("y")]
        public int posY {get; set;}

    }

    public String GetFontString(LyricFont lyricType)
    {
        switch(lyricType)
        {
            case LyricFont.MontserratLight:
                return "monl";
            case LyricFont.NottoSerifLight:
                return "nol";
            case LyricFont.NottoSerifRegular:
                return "nor";
            case LyricFont.SawarabiMincho:
                return "s";
            default:
                return "";
        }
    }


    public String GetFontPath(LyricFont lyricType)
    {
        switch(lyricType)
        {
            case LyricFont.MontserratLight:
                return "fonts/Montserrat-Light.ttf";
            case LyricFont.NottoSerifLight:
                return "fonts/NotoSerifJP-Light.otf";
            case LyricFont.NottoSerifRegular:
                return "fonts/NotoSerifJP-Regular.otf";
            case LyricFont.SawarabiMincho:
                return "fonts/SawarabiMincho-Regular.ttf";
            default:
                return "";
        }
    }
}