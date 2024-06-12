using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    //public bool isFalling = false;
    //public float downSpeed = 0;

    Rigidbody rb;
    public float fallDelay;


    private void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.name == "Player")
        {
            StartCoroutine(Falling());
        }

        /*if(collider.gameObject.name == "Player")
        {
            isFalling = true;
            Destroy(gameObject, 10);
        }*/
    }

    IEnumerator Falling()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.isKinematic = false;
        GetComponent<Collider>().isTrigger = true;
        yield return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(isFalling)
        {
            downSpeed += Time.deltaTime/100;
            transform.position = new Vector3(transform.position.x, transform.position.y -downSpeed, transform.position.z);
        }*/
    }
}
