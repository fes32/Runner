using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] protected List<Transition> Transitions;

    protected Player Player { get; set; }

    public void Enter(Player player)
    {
        if (enabled == false)
        {
            Player = player;
            enabled = true;
            foreach (var transition in Transitions)
            {
                transition.enabled = true;
                transition.Init(Player);
            }
        }
    }
    
    public void Exit()
    {
        if (enabled)
        {
            foreach(var transiton in Transitions)
            {
                transiton.enabled = false;
            }
            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transition in Transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }
        return null;
    }
}