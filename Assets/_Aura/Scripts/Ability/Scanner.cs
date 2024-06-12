using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    ParticleSystem particleSystem;
   List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        particleSystem= GetComponent<ParticleSystem>();
        collisionEvents= new List<ParticleCollisionEvent>();
    }
    private void OnParticleCollision(GameObject other)
    {
        var numCollisionEvents =  particleSystem.GetCollisionEvents(other,collisionEvents);
        foreach (var item in collisionEvents)
        {
            item.colliderComponent.gameObject.GetComponentInParent<IScannable>().OnScanned();
        }
    }
}
