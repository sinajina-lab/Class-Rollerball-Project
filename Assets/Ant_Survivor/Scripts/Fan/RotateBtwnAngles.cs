using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBtwnAngles : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 60f;

    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * rotateSpeed, 180) -45);
    }
}
