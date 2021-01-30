using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTransition : Transition
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Ground>())
          NeedTransit = true;
    }
}
