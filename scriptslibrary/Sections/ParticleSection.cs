using StorybrewScripts;
using System.Collections.Generic;
using StorybrewCommon;
using StorybrewCommon.Storyboarding;
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