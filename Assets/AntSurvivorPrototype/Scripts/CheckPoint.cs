using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    public string nextLevel;

    public int foodToCollect = 5;
    public int colonies = 5;
    public int antsCollected = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WinPoint")
        {
            if(Inventory.Reference.foodCollected > foodToCollect)
            {
                //Load the next level if collected the minimum number
                Application.LoadLevel(nextLevel);
            }

            if (Inventory.Reference.coloniesFound > colonies)
            {
                //Load the next level if collected the minimum number
                Application.LoadLevel(nextLevel);
            }

            if (Inventory.Reference.collectedAnts > antsCollected)
            {
                //Load the next level if collected the minimum number
                Application.LoadLevel(nextLevel);
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
