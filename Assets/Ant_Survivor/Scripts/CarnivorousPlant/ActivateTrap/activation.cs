using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activation : MonoBehaviour
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            transform.GetComponent<Animator>().Play("Snap");

            Health player = other.transform.GetComponent<Health>();
            if(player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
