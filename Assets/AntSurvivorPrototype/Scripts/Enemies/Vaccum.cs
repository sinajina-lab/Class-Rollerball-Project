using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccum : MonoBehaviour
{
    public Transform vacuum;
    public float moveSpeed = 3;
    public float rotationSpeed = 3;
    public Transform myTransform;
    public float dist = 10;
    public float scaledown = 0.03f;
    public float curDist;
    public Vector3 startScale;
    public Vector3 startPosition;
    public bool moving = false;
    public Vector3 originalScale;

    private void Awake()
    {
        myTransform = transform;
    }

    private void Start()
    {
        vacuum = FindObjectOfType<Vaccum>().transform;
    }

    public void Update()
    {
        var distance = Vector3.Distance(myTransform.position, vacuum.position);
        var dir = myTransform.position - vacuum.position;
        if (distance <= dist)
        {
            if (!moving)
            {
                    moving = true;
                    startScale = myTransform.localScale;
                    startPosition = myTransform.position;

                myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(vacuum.position - myTransform.position), rotationSpeed * Time.deltaTime);
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
                //Scale now changes dependent on how far away the object is from the vacuum
                //curDist is the distance between where the object began and where the vacuum is now
                curDist = Vector3.Distance(startPosition, vacuum.position);
                //This takes the original scale of the object and modifies it by a percentage of it's distance traveled to the vacuum
                myTransform.localScale = startScale * (distance / curDist);
            }
            else
            {
                moving = false;
            }
        }

        //Slowly grow back to original scale if not being attracted by the vacuum
        if (!moving && myTransform.localScale.x < originalScale.x)
        {
            myTransform.localScale = Vector3.Slerp(myTransform.localScale, originalScale, 0.01f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject.tag == "Player")
        //    Destroy(gameObject);
    }
}