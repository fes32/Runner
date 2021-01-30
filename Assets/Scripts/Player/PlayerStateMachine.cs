using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;
    private Player _player;

    public State CurrentState => _currentState;

    private void Start()
    {
        _player = GetComponent<Player>();
        Transit(_firstState);
    }

    private  void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if(nextState!=null)
            Transit(nextState);
    }


    private void Transit(State nextState)
    {
        if(_currentState!=null)
           _currentState.Exit();

        _currentState = nextState;

        if (_currentState!= null)
          _currentState.Enter(_player);
    }

}
