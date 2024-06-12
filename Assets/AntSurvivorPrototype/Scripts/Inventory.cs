using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Reference;

    public int collectedAnts;
    public int coloniesFound;
    public int foodCollected;

    // Start is called before the first frame update
    void Awake()
    {
        Reference = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
