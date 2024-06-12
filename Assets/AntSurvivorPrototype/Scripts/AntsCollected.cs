using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AntsCollected : MonoBehaviour
{
    private int ant = 0;

    [SerializeField] private TextMeshProUGUI antText;

    [SerializeField] private AudioSource CrunchSoundEffect;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ant"))
        {
            Inventory.Reference.collectedAnts += 5;

            CrunchSoundEffect.Play();

            Destroy(collision.gameObject);
            ant++;
            antText.text = "Ant: " + ant;
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
