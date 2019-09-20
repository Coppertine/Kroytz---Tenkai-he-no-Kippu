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
            220074,
            222600,
            225127,
            225442,
            225758,
            226074,
            226390,
            226706,
            227653,
            227969,
            228285,
            228600,
            229863,
            230179, // After Bridge
            232706,
            233021,
            233337,
            233653,
            237758,
            238074,
            238390,
            238706,
            240285,
            242179,
            242811,
            244074,
            245337,
            247390,
            247863,
            248495,
            249127,
            247232,
            250074,
            250390, // Kiai 3
            252285,
            252916,
            254811,
            255442,
            257337,
            257969,
            260495,
            262390,
            263021,
            264285,
            265548,
            267442,
            268074,
            269337,
            270600,
            272495,
            273127,
            275021,
            275653,
            277548,
            278179,
            280706,
            282600,
            283232,
            284495,
            285758,
            288285,
            288916,
            290811,
            291442,
            292232, // Ending
            293337,
            296811,
            297127,
            299653,
            300285,
            300600,
            300916,
            301863,
            310706

        };
    #endregion        
        particleManager.DarkyRingHit(RingPool, RingTimings);

#endregion      
    
#region Hitlights
        var HitLightPool = particleManager.hitlightpool(Layers.Hitobject, "sb/dot.png");
        List<intRange> hitlightTimes = new List<intRange> {
            new intRange(10074, 10390),
            new intRange(17969, 28074),
            new intRange(122811, 124074),
            new intRange(126600, 129127),
            new intRange(137969, 148074), // after credits
            new intRange(203653, 204916), // fast kiai 2
            new intRange(207442, 209969),
            new intRange(218811, 220074), // Guitar Solo
            new intRange(233969, 235232), // After Bridge
            new intRange(239653, 240285),
            new intRange(244074, 245337),
            new intRange(284495, 285758), // Kiai 3
            new intRange(289548, 290811),
            new intRange(292232, 310706), // Ending


        };

        particleManager.PPHitLight(HitLightPool, hitlightTimes, new intRange(5, 20), new Vector2(320, 0));
#endregion

        // var dustParticles = particleManager.MovingParticles(
        //     Layers.Overlay,
        //     "sb/dot.png",
        //     OsbOrigin.Centre);
       // particleManager.CustomParticle(dustParticles, )

       var orbParticles = particleManager.MovingParticles(
           Layers.Foreground,
           "sb/dot.png",
           OsbOrigin.Centre
       );
       var cloudParticles = particleManager.MovingParticles(
           Layers.Foreground,
           "sb/p/cloud.png",
           OsbOrigin.Centre
       );
    // First verse
        particleManager.CustomParticles(orbParticles,
         new ParticleParamaters {
             startTime = 28074,
             endTime = 47969,
             direction = ParticleDirection.Top,
             Positions = new Vector2Range(
                 new Vector2(780, 400),   // Bottom Right
                 new Vector2(-110, -50) // Top Left                 
             ),
             easing = OsbEasing.None,
             duration = GetBeatDuration(28074,1) * 4,
             particleAmmount = 16,
             randomX = true,
             randomY = false,
             randomYEnd = false,
             sameYEnd = false,
             rotation = new Vector2(1,360),
             randomRotation = true
         });

            // Clouds
        particleManager.CustomParticles(cloudParticles,
         new ParticleParamaters {
             startTime = 28074,
             endTime = 47969,
             direction = ParticleDirection.Right,
             Positions = new Vector2Range(
                 new Vector2(-220, -50), // Top Left    
                 new Vector2(850, 300)   // Bottom Right                              
             ),
             easing = OsbEasing.None,
             duration = GetBeatDuration(28074,1) * 5,
             particleAmmount = 4,
             randomX = false,
             randomY = true,
             sameYEnd = true,
             randomYEnd = false,
             fade = 0.3,
             //rotation = new Vector2(1,360),
             //randomRotation = true
         });

         // 68495 (Sloish Section to Kiai 1)
         particleManager.CustomParticles(orbParticles,
         new ParticleParamaters {
             startTime = 68495,
             endTime = 83653,
             direction = ParticleDirection.Top,
             Positions = new Vector2Range(
                 new Vector2(780, 400),   // Bottom Right
                 new Vector2(-110, -50) // Top Left            
             ),
             easing = OsbEasing.None,
             duration = GetBeatDuration(28074, 1) * 3,
             particleAmmount = 16,
              randomX = true,
             randomY = false,
             randomYEnd = false,
             sameYEnd = false,
             rotation = new Vector2(0,360),
             randomRotation = true
         });

         // 88706 (Fast Kiai 1)
        particleManager.CustomParticles(orbParticles,
         new ParticleParamaters {
             startTime = 88706,
             endTime = 129127,
             direction = ParticleDirection.Top,
             Positions = new Vector2Range(
                 new Vector2(780, 400),   // Bottom Right
                 new Vector2(-110, -50) // Top Left            
             ),
             easing = OsbEasing.None,
             duration = GetBeatDuration(28074, 1) * 1.5,
             particleAmmount = 16,
             randomX = true,
             randomY = false,
             randomYEnd = false,
             sameYEnd = false,
             rotation = new Vector2(0,360),
             randomRotation = true
         });


         // 149337 (Slowish section to kiai 2)
         particleManager.CustomParticles(orbParticles,
         new ParticleParamaters {
             startTime = 149337,
             endTime = 164495,
             direction = ParticleDirection.Bottom,
             Positions = new Vector2Range(
                 new Vector2(780, 400),   // Bottom Right
                 new Vector2(-110, -50) // Top Left            
             ),
             easing = OsbEasing.None,
             duration = GetBeatDuration(28074, 1) * 3,
             particleAmmount = 16,
             randomX = true,
             randomY = false,
             randomYEnd = false,
             sameYEnd = false,
             rotation = new Vector2(0,360),
             randomRotation = true
         });


         // (Fast kiai 2)
         particleManager.CustomParticles(orbParticles,
         new ParticleParamaters {
             startTime = 169548,
             endTime = 209969,
             direction = ParticleDirection.Bottom,
             Positions = new Vector2Range(
                 new Vector2(780, 400),   // Bottom Right
                 new Vector2(-110, -50) // Top Left            
             ),
             easing = OsbEasing.None,
             duration = GetBeatDuration(28074, 1) * 1.5,
             particleAmmount = 16,
             randomX = true,
             randomY = false,
             randomYEnd = false,
             sameYEnd = false,
             rotation = new Vector2(0,360),
             randomRotation = true
         });

         // Furious Sunset Bridge
         particleManager.CustomParticles(orbParticles,
         new ParticleParamaters {
             startTime = 220074,
             endTime = 230179,
             direction = ParticleDirection.Bottom,
             Positions = new Vector2Range(
                 new Vector2(780, 400),   // Bottom Right
                 new Vector2(-110, -50) // Top Left            
             ),
             easing = OsbEasing.None,
             duration = GetBeatDuration(28074, 1) * 2.5,
             particleAmmount = 16,
              randomX = true,
             randomY = false,
             randomYEnd = false,
             sameYEnd = false,
             rotation = new Vector2(0,360),
             randomRotation = true
         });

         // After Bridge
         particleManager.CustomParticles(orbParticles,
         new ParticleParamaters {
             startTime = 230179,
             endTime = 247863,
             direction = ParticleDirection.Bottom,
             Positions = new Vector2Range(
                 new Vector2(780, 400),   // Bottom Right
                 new Vector2(-110, -50) // Top Left            
             ),
             easing = OsbEasing.None,
             duration = GetBeatDuration(28074, 1) * 3,
             particleAmmount = 16,
             randomX = true,
             randomY = false,
             randomYEnd = false,
             sameYEnd = false,
             rotation = new Vector2(0,360),
             randomRotation = true
         });

         // Kiai 3
         particleManager.CustomParticles(orbParticles,
         new ParticleParamaters {
             startTime = 250390,
             endTime = 290811,
             direction = ParticleDirection.Bottom,
             Positions = new Vector2Range(
                 new Vector2(780, 400),   // Bottom Right
                 new Vector2(-110, -50) // Top Left
             ),
             easing = OsbEasing.None,
             duration = GetBeatDuration(28074, 1) * 1.5,
             particleAmmount = 16,
             randomX = false,
             randomY = true,
             randomYEnd = false,
             sameYEnd = false,
             rotation = new Vector2(0,360),
             randomRotation = true
         });
    }
}