using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCFollow : MonoBehaviour
{
    public GameObject Pc;

    // Start is called before the first frame update
    void Start()
    {
        Pc = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, Pc.transform.position, 1f);
    }

    // Update is called once per frame

}
