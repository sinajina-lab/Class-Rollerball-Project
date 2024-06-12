using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    List<Rigidbody> RigidbodiesInWindZoneList = new List<Rigidbody>();
    public float windStrength = 5;
    public Vector3 windDirection;

    private void OnTriggerEnter(Collider col)
    {
        Rigidbody objectRigid = col.gameObject.GetComponentInParent<Rigidbody>();
        if(objectRigid != null)
        {
            RigidbodiesInWindZoneList.Add(objectRigid);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        Rigidbody objectRigid = col.gameObject.GetComponentInParent<Rigidbody>();
        if(objectRigid != null)
        {
            RigidbodiesInWindZoneList.Remove(objectRigid);
            //objectRigid.isKinematic = true;
        }
    }

    private void FixedUpdate()
    {
        if(RigidbodiesInWindZoneList.Count > 0)
        {
            foreach(Rigidbody rigid in RigidbodiesInWindZoneList)
            {
                rigid.AddForce(windDirection * windStrength);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
