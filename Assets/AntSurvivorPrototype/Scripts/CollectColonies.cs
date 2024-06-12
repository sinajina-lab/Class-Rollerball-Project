using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectColonies : MonoBehaviour
{
    private int colony = 0;

    [SerializeField] private TextMeshProUGUI colonyText;

    [SerializeField] private AudioSource CrunchSoundEffect;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Colony"))
        {
            Inventory.Reference.coloniesFound += 1;

            CrunchSoundEffect.Play();

            Destroy(collision.gameObject);
            colony++;
            colonyText.text = "Colony: " + colony;
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
