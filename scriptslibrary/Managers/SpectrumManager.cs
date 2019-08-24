using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;
using System.Collections.Generic;
using System;
using StorybrewCommon.Animations;
using OpenTK;
public class SpectrumManager : Manager
{
    private List<OsbSprite> WubSpectrumSprites = new List<OsbSprite>();
    
    public void SetupSprites()
    {
        var barCount = 20;
        for (var i = 0; i < barCount; i++)
        {
            WubSpectrumSprites.Add(GetLayer(Layers.Foreground).CreateSprite("sb/bar2.png"));
            WubSpectrumSprites[i].Fade(0,0);
        }

    }

    public void CreateFakeSpectrum(double startTime, double duration, int Count, bool sine)
    {
        var barWidth = 350 / WubSpectrumSprites.Count;
        var heightKeyframes = new KeyframedValue<float>[WubSpectrumSprites.Count];
        for (var i = 0; i < WubSpectrumSprites.Count; i++)
            heightKeyframes[i] = new KeyframedValue<float>(null);
        Log($"Completed all {WubSpectrumSprites.Count}");
        for (var time = (double)startTime; time < startTime + (duration * Count); time += duration)
        {

            var fft = GetFft(time, WubSpectrumSprites.Count, null, OsbEasing.InExpo);
            for (var i = 0; i < WubSpectrumSprites.Count; i++)
                    {
                        var height = (float)Math.Log10(1 + fft[i] * 600) * 100 / 56;
                        
                        heightKeyframes[i].Add(time, height);
                    }
        }

        for (var i = 0; i < WubSpectrumSprites.Count; i++)
        {
            
            var keyframes = heightKeyframes[i];
            keyframes.Simplify1dKeyframes(0.2, h => h);

            var bar = WubSpectrumSprites[i];
            
                        
            bar.Move(startTime, new Vector2(0f + (i * 2) * barWidth, 240));
            bar.Fade(startTime,1);
            bar.Fade(startTime + (duration * Count), 0);
            
            var hasScale = false;
            keyframes.ForEachPair(
                (start, end) =>
                {
                    hasScale = true;
                    bar.ScaleVec(OsbEasing.OutCubic, start.Time, end.Time,
                        0.75, start.Value,
                        0.75, start.Value - (start.Value * 0.5));
                },
                1f,
                s => (float)Math.Round(s, 2)
            );
            if (!hasScale) bar.ScaleVec(startTime, 1, 1f);
        }

    }
}