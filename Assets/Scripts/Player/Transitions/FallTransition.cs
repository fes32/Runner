using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTransition : Transition
{
    private void Update()
    {
        if (Player.Rigidbody2D.velocity.y<0)
            NeedTransit = true;
    }
}
