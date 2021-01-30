using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : State
{
    private void OnEnable()
    {
        Player.Animator.Play("Run");
        Player.Grounding();
    }

    private void Update()
    {
        Player.Rigidbody2D.velocity = new Vector2(Player.Speed,0);
    }
}