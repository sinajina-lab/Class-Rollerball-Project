using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private bool _isGrounded;
    [SerializeField]private float _castDistance;
    public LayerMask ground;

    private void Update()
    {
        if(Physics.Raycast(transform.position,Vector3.down,_castDistance,ground))
        {
            _isGrounded= true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    public bool GetGroundedStatus()
    {
        return _isGrounded;
    }
}
