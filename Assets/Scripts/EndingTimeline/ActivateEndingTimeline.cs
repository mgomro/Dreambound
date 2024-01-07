using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateEndingTimeline : GameActivable
{
    public PlayableDirector director;

    public override void Activate()
    {
        director.Play();
    }
}
