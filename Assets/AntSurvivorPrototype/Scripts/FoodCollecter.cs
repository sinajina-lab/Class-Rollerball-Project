using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodCollecter : MonoBehaviour
{
    private int food = 0;

    [SerializeField] private TextMeshProUGUI foodText;

    [SerializeField] private AudioSource CrunchSoundEffect;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            Inventory.Reference.foodCollected += 1;

            CrunchSoundEffect.Play();

            Destroy(collision.gameObject);
            food++;
            foodText.text = "Food: " + food;
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
