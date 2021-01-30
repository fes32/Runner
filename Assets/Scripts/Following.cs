using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _targetDistance;

    public void Update()
    {
        transform.position = new Vector3(_target.transform.position.x+_targetDistance,transform.position.y,transform.position.z);
    }
}
