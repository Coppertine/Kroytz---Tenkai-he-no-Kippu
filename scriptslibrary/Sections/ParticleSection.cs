using StorybrewScripts;
using System.Collections.Generic;
using StorybrewCommon;
using StorybrewCommon.Storyboarding;
public class ParticleSection : Section
{
    public ParticleSection()
    {
        var particleManager = GetManager<ParticleManager>();
        particleManager.MarchingParticle(
            Layers.Foreground,
            11784, 22755, 
            1, "sb/pixel.png",
            ParticleGeneration.Pool, 
            ParticleDirection.Right);
#region Rings
        var RingPool = particleManager.DarkyRing(Layers.Hitobject);
        

    #region RingTimings
        List<int> RingTimings = new List<int>() {
            // First spectrum //
            33727,
            34412,
            35784,
            36470,
            36727,
            36984,
            35098,
            35355,
            35612,
            37155,
            37841,
            38098,
            38355,
            38613,
            38870,
            39212,
            //  //
        };
    #endregion        
        particleManager.DarkyRingHit(RingPool, RingTimings);

#endregion      
    
        
        var dustParticles = particleManager.MovingParticles(
            Layers.Overlay,
            "sb/dot.png",
            OsbOrigin.Centre);
    }
}