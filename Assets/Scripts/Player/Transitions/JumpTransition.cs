using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTransition : Transition
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)&Player.Grounded)
            NeedTransit = true;
    }
}
