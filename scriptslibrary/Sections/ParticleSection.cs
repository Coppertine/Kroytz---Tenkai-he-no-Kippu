using StorybrewScripts;
using System.Collections.Generic;
using StorybrewCommon;
using StorybrewCommon.Storyboarding;
using OpenTK;
public class ParticleSection : Section
{
    public ParticleSection()
    {
        var particleManager = GetManager<ParticleManager>();
        // particleManager.MarchingParticle(
        //     Layers.Foreground,
        //     11784, 22755, 
        //     1, "sb/pixel.png",
        //     ParticleGeneration.Pool, 
        //     ParticleDirection.Right);
#region Rings
        var RingPool = particleManager.DarkyRing(Layers.Hitobject);
        

    #region RingTimings
        List<int> RingTimings = new List<int>() {
            
            2811,
            3127,
            3442,
            3758,
            7863,
            8179,
            8495,
            8811,
            10390,
            12285,
            12916,
            14179,
            15442,
            17337,
            28074,
            33127,
            36916,
            38179,
            43232,
            45758,
            47021,
            47969,
            48127,
            48285,
            48916,
            49548,
            50811,
            53337,
            55863,
            58074,
            58390,
            58627,
            58863,
            59021,
            59653,
            59890,
            60127,
            60285,
            60916,
            61548,
            63442,
            67232,
            67548,
            67863,
            68179,
            68495,
            69758,
            70390,
            71021,
            72285,
            73548,
            76074,
            77337,
            78600,
            80495,
            81127,
            82390,
            83653,
            84285,
            84916,
            85548,
            85706,
            85863,
            86021,
            86179,
            86811,
            87442,
            88074,
            88706,
            
           148390,
           148706,
           149021,
           149337
        };
    #endregion        
        particleManager.DarkyRingHit(RingPool, RingTimings);

#endregion      
    
#region Hitlights
        var HitLightPool = particleManager.hitlightpool(Layers.Hitobject, "sb/highlight.png");
        List<intRange> hitlightTimes = new List<intRange> {
            new intRange(10074, 10390),
            new intRange(17969, 28074)
        };

        particleManager.Hitlight(HitLightPool, hitlightTimes);
#endregion

        // var dustParticles = particleManager.MovingParticles(
        //     Layers.Overlay,
        //     "sb/dot.png",
        //     OsbOrigin.Centre);
       // particleManager.CustomParticle(dustParticles, )

       var foreGroundFeathers = particleManager.MovingParticles(
           Layers.Foreground,
           "sb/feather.png",
           OsbOrigin.Centre
       );
    // First verse
       particleManager.CustomParticles(foreGroundFeathers,
        new ParticleParamaters {
            startTime = 28074,
            endTime = 47969,
            direction = ParticleDirection.Bottom,
            Positions = new Vector2Range(
                new Vector2(-110, -50), // Top Left
                new Vector2(780, 500)   // Bottom Right
            ),
            easing = OsbEasing.None,
            duration = GetBeatDuration(28074,1) * 4,
            particleAmmount = 16,
            randomX = true,
            randomY = false,
            rotation = new Vector2(0,360),
            randomRotation = true
        });

        // 149337 (Slowish section to kiai 2)
        particleManager.CustomParticles(foreGroundFeathers,
        new ParticleParamaters {
            startTime = 149337,
            endTime = 164495,
            direction = ParticleDirection.Bottom,
            Positions = new Vector2Range(
                new Vector2(-110, 100), // Top Left
                new Vector2(780, 500)   // Bottom Right
            ),
            easing = OsbEasing.None,
            duration = GetBeatDuration(28074, 1) * 3,
            particleAmmount = 16,
            randomX = false,
            randomY = true,
            rotation = new Vector2(0,360),
            randomRotation = true
        });
    }
}