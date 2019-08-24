using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewScripts;
using OpenTK;
using OpenTK.Graphics;

public class TransitionManager : Manager
{
    public OsbSprite FullscreenFlash(StoryboardLayer layer, string file)
    {
        var sprite = layer.CreateSprite(file);
        sprite.ScaleVec(0,new Vector2(854,480));
        sprite.Color(0,Color4.White);
        sprite.Fade(0,0);
        return sprite;
    }

    public void ColouredFlash(OsbSprite flash, double startTime, double endTime,  double startOpacity, double endOpacity)
    {
        foreach(var hitobject in MainStoryboard.Instance.Beatmap.HitObjects)
        {
            if(InTime((int)hitobject.StartTime, (int)startTime, 5) ||
               InTime((int)hitobject.EndTime, (int)startTime, 5))
            {
                Log("Found it!");
                flash.Color(startTime, hitobject.Color);
                flash.Fade(startTime, endTime, startOpacity, endOpacity);
            }
        }
    }
    public OsbSprite SwipePaneNoFade(StoryboardLayer layer, OsbEasing easing, SwipeDirection direction, string file, double start, double end, Vector2 Postion, Vector2 ScaleFrom, Vector2 ScaleTo)
    {   
        var Origin = OsbOrigin.TopCentre;
        switch(direction)
        {
            case SwipeDirection.Top:
                Origin = OsbOrigin.BottomCentre;
                break;
            case SwipeDirection.Bottom:
                Origin = OsbOrigin.TopCentre;
                break;
            case SwipeDirection.Left:
                Origin = OsbOrigin.CentreRight;
                break;
            case SwipeDirection.Right:
                Origin = OsbOrigin.CentreLeft;
                break;
        }
        var sprite = layer.CreateSprite(file,Origin);
        sprite.ScaleVec(easing, start, end, ScaleFrom, ScaleTo); 
        sprite.Move(start,Postion);

        return sprite;

    }

    public OsbSprite TriangleAnimation(StoryboardLayer layer, double start, double frameduration)
    {
        return layer.CreateAnimation("sb/ani/tri/Triangle.png",21,frameduration,OsbLoopType.LoopOnce);
    }
}