using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] protected State _targetState;

    protected Player Player { get; set; }

    public bool NeedTransit { get; protected set; }
    public State TargetState => _targetState;

    public void Init(Player player)
    {
        Player = player;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
