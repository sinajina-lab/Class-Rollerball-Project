using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderOnTrigger : MonoBehaviour
{
    //the object that the script will move
    public GameObject sphere;

    //empty object to determine where the platform starts
    public Transform startPosition;

    //empty object to determine where the platform moves to
    public Transform targetPosition;

    //value to determine if the object should move into places or move back to start
    public bool inTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        var step = 2 * Time.deltaTime;

        //moves platform into position when in the trigger
        if(inTrigger)
        {
            sphere.transform.position = Vector3.MoveTowards(sphere.transform.position, targetPosition.position, step);
        }
        //moves the platform back to the initial position when the player is not in the trigger
        else
        {
            sphere.transform.position = Vector3.MoveTowards(sphere.transform.position, startPosition.position, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
}
