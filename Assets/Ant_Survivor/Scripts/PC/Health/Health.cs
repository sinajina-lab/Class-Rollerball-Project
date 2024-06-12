using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 1f;

    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Player.transform.position = respawnPoint.transform.position;
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
