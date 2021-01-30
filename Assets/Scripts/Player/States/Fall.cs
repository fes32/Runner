using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : State
{
    private void OnEnable()
    {
        Player.Animator.Play("Fall");
    }
}