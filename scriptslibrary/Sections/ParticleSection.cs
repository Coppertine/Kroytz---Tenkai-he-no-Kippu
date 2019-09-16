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
            88706, // Fast Kiai 1
            90600,
            91232,
            93127,
            93758,
            95653,
            96285,
            98811,
            100706,
            101337,
            102600,
            103863,
            105758,
            106390,
            107653,
            108916,
            110811,
            111442,
            113337,
            113969,
            115863,
            116495,
            119021,
            120285,
            120916,
            121548,
            122811,
            123442,
            123758,
            124074,
            125969,
            126600,
            129127,  
            144284, // After Credits
            144916, 
            145548,
            146179,
            146811,
            147442,
            148074,
            148390, // Slow Kiai 2
            148706,
            149021,
            149337,
            151232,
            151863,
            153127,
            154390,
            156916,
            158179,
            159442,
            161337,
            161969,
            163232,
            164495,
            165127,
            165758,
            166390,
            166706,
            167021,
            167653,
            168285,
            168916,
            169548, // Fast Kiai 2
            171442,
            172074,
            173969,
            174600,
            176495,
            177127,
            179653,
            181548,
            183442,
            184706,
            186600,
            187232,
            188495,
            189758,
            191653,
            192285,
            194179,
            194811,
            196706,
            197337,
            199863,
            201758,
            202390,
            203653,
            204916,
            206811,
            207127,
            207442,
            208074,
            208706,
            209969, // Bridge (sunset)
            
        };
    #endregion        
        particleManager.DarkyRingHit(RingPool, RingTimings);

#endregion      
    
#region Hitlights
        var HitLightPool = particleManager.hitlightpool(Layers.Hitobject, "sb/highlight.png");
        List<intRange> hitlightTimes = new List<intRange> {
            new intRange(10074, 10390),
            new intRange(17969, 28074),

            new intRange(122811, 124074),
            new intRange(126600, 129127),
            new intRange(137969, 148074), // after credits
            new intRange(203653, 204916), // fast kiai 2
            new intRange(207442, 209969)
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
             rotation = new Vector2(1,360),
             randomRotation = true
         });

         // 68495 (Sloish Section to Kiai 1)
         particleManager.CustomParticles(foreGroundFeathers,
         new ParticleParamaters {
             startTime = 68495,
             endTime = 83653,
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

         // 88706 (Fast Kiai 1)
        particleManager.CustomParticles(foreGroundFeathers,
         new ParticleParamaters {
             startTime = 88706,
             endTime = 129127,
             direction = ParticleDirection.Bottom,
             Positions = new Vector2Range(
                 new Vector2(-110, 100), // Top Left
                 new Vector2(780, 500)   // Bottom Right
             ),
             easing = OsbEasing.None,
             duration = GetBeatDuration(28074, 1) * 1.5,
             particleAmmount = 16,
             randomX = false,
             randomY = true,
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


         // (Fast kiai 2)
         particleManager.CustomParticles(foreGroundFeathers,
         new ParticleParamaters {
             startTime = 169548,
             endTime = 209969,
             direction = ParticleDirection.Bottom,
             Positions = new Vector2Range(
                 new Vector2(-110, 100), // Top Left
                 new Vector2(780, 500)   // Bottom Right
             ),
             easing = OsbEasing.None,
             duration = GetBeatDuration(28074, 1) * 1.5,
             particleAmmount = 16,
             randomX = false,
             randomY = true,
             rotation = new Vector2(0,360),
             randomRotation = true
         });
    }
}