using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : State
{
    private void OnEnable()
    {
        Player.Animator.Play("Jump");
        Player.Jump();
    }
}