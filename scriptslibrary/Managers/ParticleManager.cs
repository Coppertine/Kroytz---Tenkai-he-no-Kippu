using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;
using StorybrewCommon.Storyboarding.Util;
using System;
using System.Collections.Generic;
using StorybrewCommon.Mapset;
using System.Linq;
using OpenTK;
public class ParticleManager : Manager
{
    
    public void MarchingParticle(Layers layer, int startTime, int endTime, int divisor, string spriteFile, ParticleGeneration particleGenType, ParticleDirection direction)
    {
        if(particleGenType == ParticleGeneration.Pool)
        {
            using(var pool = new OsbSpritePool(GetLayer(layer), spriteFile, OsbOrigin.Centre, (sprite, sTime, eTime) => {
                sprite.Fade(sTime, Random(0.2f, 0.9f));
                sprite.Scale(sTime, Random(20f, 80f));
                if(direction == ParticleDirection.Top || direction == ParticleDirection.Bottom)
                    sprite.MoveX(sTime, Random(-107, 757));
                else if(direction == ParticleDirection.Left || direction == ParticleDirection.Right)
                    sprite.MoveY(sTime, Random(0, 512));

                if(eTime > endTime - GetBeatDuration(startTime, divisor) * 4) //Hide sprites if they cross the end time
                    sprite.Fade(endTime, 0f);

            }))
            {
                
                for(var sTime = (double)startTime; sTime <= endTime - GetBeatDuration(startTime, 1) * 4; sTime += GetBeatDuration(startTime, 2))
                {
                    var baseSpeed = Random(40, 120);
                    var eTime = sTime + Math.Ceiling(930f / baseSpeed) * GetBeatDuration(startTime, 1);

                   
                    var sprite = pool.Get(sTime, eTime);

                    bool fromTop = direction == ParticleDirection.Bottom || direction == ParticleDirection.Right;
                    var moveSpeed = baseSpeed * (fromTop ? 1 : -1);
                    var currentTime = sTime + (sTime - GetOffset((int)sTime)) % GetBeatDuration(startTime, 1);

                    if(direction == ParticleDirection.Bottom || direction == ParticleDirection.Top)
                        sprite.MoveY(sTime, fromTop ? -60 : 540);
                    else if(direction == ParticleDirection.Left || direction == ParticleDirection.Right)
                        sprite.MoveX(sTime, fromTop ? -130 : 800);


                    if(direction == ParticleDirection.Bottom || direction == ParticleDirection.Top)
                    {
                        while(fromTop ? sprite.PositionAt(currentTime).Y < 540 : sprite.PositionAt(currentTime).Y > -60) {

                            var yPos = sprite.PositionAt(currentTime).Y;
                            var yRot = sprite.RotationAt(currentTime);

                            sprite.MoveY(OsbEasing.OutExpo, currentTime, currentTime + GetBeatDuration(startTime, 1), yPos, yPos + moveSpeed);
                            sprite.Rotate(OsbEasing.OutExpo, currentTime, currentTime + GetBeatDuration(startTime, 1), yRot, yRot + Math.PI * 0.25f);

                            currentTime += GetBeatDuration(startTime, 1);
                        }
                    }
                    else if(direction == ParticleDirection.Left || direction == ParticleDirection.Right)
                    {
                        while(fromTop ? sprite.PositionAt(currentTime).X < 800 : sprite.PositionAt(currentTime).X > -120) {

                            var xPos = sprite.PositionAt(currentTime).X;
                            var xRot = sprite.RotationAt(currentTime);

                            sprite.MoveX(OsbEasing.OutExpo, currentTime, currentTime + GetBeatDuration(startTime, 1), xPos, xPos + moveSpeed);
                            sprite.Rotate(OsbEasing.OutExpo, currentTime, currentTime + GetBeatDuration(startTime, 1), xRot, xRot + Math.PI * 0.25f);

                            currentTime += GetBeatDuration(startTime, 1);
                        }
                    }
                    //thx Darky
                    if(Random(0, 4) > 0) //HACK move the time back in order to increase the particle count without running into syncing issues
                        sTime -= GetBeatDuration(startTime, 2); 
                }
            }
        }
    }
    
    public OsbSpritePool MovingParticles(Layers layers, string fileName, OsbOrigin origin, Action<OsbSprite, double, double> finalizeSprite = null)
    {
        return new OsbSpritePool(GetLayer(layers), fileName, OsbOrigin.Centre, finalizeSprite);
    }

    public OsbSpritePool MovingParticles(Layers layers, string fileName, OsbOrigin origin, bool Additive)
    {
        return new OsbSpritePool(GetLayer(layers), fileName, OsbOrigin.Centre, Additive);
    }

    public void CustomParticles(OsbSpritePool pool, ParticleParamaters paramaters) {
        using(pool) 
        {
            var timeStep = paramaters.duration / paramaters.particleAmmount;
            for (double time = paramaters.startTime; time <= paramaters.endTime; time += timeStep)
            {
               
                var particleEndTime = time + paramaters.duration;
                var sprite = pool.Get(time, particleEndTime);
                var startX = paramaters.randomX ?
                    Random(paramaters.Positions.from.X, paramaters.Positions.to.X)
                        : paramaters.Positions.from.X;
                var startY = paramaters.randomY ?
                    Random(paramaters.Positions.from.Y, paramaters.Positions.to.Y)
                        : paramaters.Positions.from.Y;

                var endX = paramaters.randomX ?
                    Random(paramaters.Positions.from.X, paramaters.Positions.to.X)
                        : paramaters.Positions.to.X;
                var endY = paramaters.sameYEnd ?
                    startY 
                    : paramaters.randomYEnd ?
                        Random(paramaters.Positions.from.Y, paramaters.Positions.to.Y)
                        : paramaters.Positions.to.Y;

                sprite.Move(paramaters.easing, 
                    time, particleEndTime, 
                    startX, startY, endX, endY);
                sprite.Fade(time, paramaters.fade);
                sprite.Fade(particleEndTime, 0);

                if ((bool)paramaters.randomRotation == true)
                {
                    sprite.Rotate(
                        paramaters.easing,
                        time, particleEndTime, 
                        DegreesToRadians(
                            Random(((Vector2)paramaters.rotation).X, ((Vector2)paramaters.rotation).Y)), 
                        DegreesToRadians(
                            Random(((Vector2)paramaters.rotation).X, ((Vector2)paramaters.rotation).Y)));
                }
                else
                { 
                    sprite.Rotate(
                        paramaters.easing,
                        time, particleEndTime,
                        DegreesToRadians(((Vector2)paramaters.rotation).X), 
                        DegreesToRadians(((Vector2)paramaters.rotation).Y));
                }

                //  if(Random(0, 4) > 0) //HACK move the time back in order to increase the particle count without running into syncing issues
                //           time -= GetBeatDuration((int)time, 2);

            }
        }
    }

    #region Hitobject Particles
    
    public OsbSpritePool DarkyRing(Layers layers)
    {
        return new OsbSpritePool(GetLayer(layers), "sb/ring.png", OsbOrigin.Centre, (sprite, startTime, endTime) =>
        {});
    }

    public void DarkyRingHit(OsbSpritePool pool, List<int> timeList) => DarkyRingHit(pool, timeList, 0, 0.5);
    public void DarkyRingHit(OsbSpritePool pool, List<int> timeList, double sizeStart, double sizeEnd)
    {
        using(pool)
        {
            foreach(var hitobject in MainStoryboard.Instance.Beatmap.HitObjects)
            {
                foreach(var time in timeList)
                {
                    if(InTime((int)hitobject.StartTime, time, 5))
                    {
                        var sprite = pool.Get(
                            hitobject.StartTime, 
                            hitobject.EndTime + 
                            GetBeatDuration((int)hitobject.StartTime, 1) + 
                            (GetBeatDuration((int)hitobject.StartTime,4) * 3));
                        
                        sprite.Scale(OsbEasing.OutExpo,hitobject.StartTime, hitobject.EndTime + 
                            GetBeatDuration((int)hitobject.StartTime, 1) + 
                            (GetBeatDuration((int)hitobject.StartTime,4) * 3), sizeStart, sizeEnd);
                        
                        sprite.Fade(hitobject.StartTime, hitobject.EndTime + 
                            GetBeatDuration((int)hitobject.StartTime, 1) + 
                            (GetBeatDuration((int)hitobject.StartTime,4) * 3), 1, 0);
                        sprite.Move(hitobject.StartTime,hitobject.Position);
                    }
                    else if(InTime((int)hitobject.EndTime, time, 5)) {
                        var sprite = pool.Get(
                            hitobject.EndTime, 
                            hitobject.EndTime + 
                            GetBeatDuration((int)hitobject.StartTime, 1) + 
                            (GetBeatDuration((int)hitobject.StartTime,4) * 3));
                        
                        sprite.Scale(OsbEasing.OutExpo,hitobject.EndTime, hitobject.EndTime + 
                            GetBeatDuration((int)hitobject.EndTime, 1) + 
                            (GetBeatDuration((int)hitobject.EndTime,4) * 3), sizeStart, sizeEnd);
                        
                        sprite.Fade(hitobject.EndTime, hitobject.EndTime + 
                            GetBeatDuration((int)hitobject.EndTime, 1) + 
                            (GetBeatDuration((int)hitobject.EndTime,4) * 3), 1, 0);
                        sprite.Move(hitobject.EndTime,hitobject.EndPosition);
                    }
                }
            }
        }
    }

    public void DarkyRingHit(OsbSpritePool pool, int startTime, int endTime) => DarkyRingHit(pool, startTime, endTime, 0, 0.5);
    public void DarkyRingHit(OsbSpritePool pool, int startTime, int endTime, double sizeStart, double sizeEnd)
    {
        using(pool)
        {
            foreach(var hitobject in MainStoryboard.Instance.Beatmap.HitObjects)
            {
                if(InTime((int)hitobject.StartTime, startTime, 5))
                {
                    var sprite = pool.Get(hitobject.StartTime, endTime);
                    sprite.Scale(OsbEasing.OutExpo,hitobject.StartTime, endTime, sizeStart, sizeEnd);
                    
                    sprite.Fade(hitobject.StartTime, endTime, 1, 0);
                    sprite.Move(hitobject.StartTime,hitobject.Position);
                }
                
            }
        }
    }
    
    public OsbSpritePool hitlightpool(Layers layers, string file) {
        return new OsbSpritePool(GetLayer(layers), file, OsbOrigin.Centre, (sprite, startTime, endTime) =>
        {});
    }

    public void Hitlight(OsbSpritePool pool, List<intRange> ranges)
    {
        using(pool)
        {
            foreach(var hitobject in MainStoryboard.Instance.Beatmap.HitObjects)
            {
                foreach(var range in ranges)
                {
                    if(InTime((int)hitobject.StartTime, range.from, range.to, 5) ||
                       InTime((int)hitobject.EndTime, range.from, range.to, 5))
                    {
                        var sprite = pool.Get(hitobject.StartTime - 100, hitobject.EndTime + 100);
                        sprite.Color(hitobject.StartTime - 100, hitobject.Color);
                        sprite.Fade(hitobject.StartTime - 100, hitobject.EndTime + 100, 1, 0);
                        sprite.Scale(hitobject.StartTime - 100, hitobject.StartTime, 0, 0.25);
                        sprite.Move(hitobject.StartTime - 100, hitobject.Position);
                        if(hitobject is OsuSlider)
                        {
                            
                            for(var i = hitobject.StartTime; i < hitobject.EndTime; i += GetBeatDuration((int)hitobject.StartTime, 4))
                            {
                                sprite.Move(
                                    i,
                                    i + GetBeatDuration((int)i, 4),
                                    hitobject.PositionAtTime(i), 
                                    hitobject.PositionAtTime(i + GetBeatDuration((int)i, 4))
                                );
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Creates litle particles that dispirse from the hitobject and ease into the centre location
    /// </summary>
    public void PPHitLight(OsbSpritePool pool, List<intRange> ranges, intRange particleAmmount, Vector2 CentreLocation,
                            OsbEasing easing = OsbEasing.None, int duration = 1000)
    {
        // Only effect hti object start positions.
        using (pool) 
        {
            foreach(var hitobject in MainStoryboard.Instance.Beatmap.HitObjects)
            {
                foreach(var range in ranges)
                {
                    if(InTime((int)hitobject.StartTime, range.from, range.to, 5) ||
                       InTime((int)hitobject.EndTime, range.from, range.to, 5))
                    {
                        for (int i = 0; i < Random(particleAmmount.from, particleAmmount.to); i++)
                        {
                            var sprite = pool.Get(hitobject.StartTime - 100, hitobject.StartTime + duration * 1.5);
                            var angle = Random(0, Math.PI*2);
                            var radius = Random(50, 200);
                            var position = new Vector2(
                                hitobject.Position.X + (float)Math.Cos(angle) * radius,
                                hitobject.Position.Y + (float)Math.Sin(angle) * radius
                            );

                            
                            sprite.Move(OsbEasing.OutExpo, hitobject.StartTime, hitobject.StartTime + duration, hitobject.Position, position);
                            sprite.Move(OsbEasing.OutExpo , hitobject.StartTime + duration, hitobject.StartTime + duration * 1.5, position, CentreLocation);
                            sprite.Fade(hitobject.StartTime, 1);
                            sprite.Fade(range.to, 0) ;
                            
                        }
                    }
                }
            }
        }
    }
    #endregion

}