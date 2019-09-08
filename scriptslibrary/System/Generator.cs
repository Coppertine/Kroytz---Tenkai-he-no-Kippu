using OpenTK;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;
using System;
using StorybrewCommon.Subtitles;
using Newtonsoft.Json;
using StorybrewCommon.Animations;
using StorybrewCommon.Mapset;
using StorybrewCommon.Subtitles.Parsers;
using StorybrewCommon.Util;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;


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

    public float Random(float minValue, double maxValue) => (float)MainStoryboard.Instance.Random(minValue, maxValue);
    public float Random(float maxValue) => (float)MainStoryboard.Instance.Random(maxValue);

        
    public int GetBeatDuration(int startTime, double divisor)
    {

        return Convert.ToInt32(MainStoryboard.Instance.Beatmap.GetTimingPointAt(startTime).BeatDuration / divisor);
    }

    public double GetOffset(int sTime) => MainStoryboard.Instance.Beatmap.GetTimingPointAt(sTime).Offset;

    public float[] GetFft(double time, string path = null) => MainStoryboard.Instance.GetFft(time,path);
    public float[] GetFft(double time, int magnitudes, string path = null, OsbEasing easing = OsbEasing.None) => MainStoryboard.Instance.GetFft(time,magnitudes,path,easing);

    /// <summary>
    /// Opens a project file in read-only mode. 
    /// You are responsible for disposing it.
    /// </summary>
    public Stream OpenProjectFile(string path, bool watch = true)
        => MainStoryboard.Instance.OpenProjectFile(path, watch);

    /// <summary>
    /// Opens a mapset file in read-only mode. 
    /// You are responsible for disposing it.
    /// </summary>
    public Stream OpenMapsetFile(string path, bool watch = true)
        => MainStoryboard.Instance.OpenMapsetFile(path, watch);
    
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

    public double DegreesToRadians(double degree) => (Math.PI / 180) * degree;    

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

    public struct ParticleParamaters {
        public ParticleDirection direction {get; set;}

        public Vector2Range Positions{get; set;}
        public OsbEasing easing{get; set;}
        public double duration{get; set;}

        public int particleAmmount{get; set;}

        public double startTime{get; set;}
        public double endTime{get; set;}

        public bool randomX{get; set;}
        public bool randomY{get; set;}

        public Vector2? scale {
            get { return scale ?? new Vector2(); } 
            set { scale = value; }
        }        
        public bool? randomScale {
            get { return randomScale ?? false; } 
            set { randomScale = value; } 
        }

        public Vector2? rotation {
            get { return rotation ?? new Vector2(0,0); } 
            set { rotation = value; }
        }        
        public bool? randomRotation {
            get { return randomRotation ?? false; } 
            set { randomRotation = value; } 
        }

        public ParticleParamaters(
            double start, 
            double end,
            ParticleDirection particleDir, 
            Vector2Range pos, OsbEasing ease, 
            double dur, int partAmmount,
            bool randX = false, bool randY = true
            )
        {
            this.direction = particleDir;
            this.Positions = pos;
            this.easing = ease;
            this.duration = dur;
            this.particleAmmount = partAmmount;
            this.randomX = randX;
            this.randomY = randY;
            this.startTime = start;
            this.endTime = end;

        }

    }

    public class Vector2Range {
        public Vector2 from;
        public Vector2 to;

        public Vector2Range(Vector2 inputFrom, Vector2 inputTo)
        {
            from = inputFrom;
            to = inputTo;
        }
    }

    public class intRange {
        public int from;
        public int to;

        public intRange(int inputFrom, int inputTo)
        {
            from = inputFrom;
            to = inputTo;
        }
    }

    
}