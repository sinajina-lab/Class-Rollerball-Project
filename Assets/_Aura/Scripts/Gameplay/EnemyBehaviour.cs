using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour :MonoBehaviour,IScannable
{
    public GameObject scannedIndicator;

    public bool isIndicating;

    public float scannedDuration;

    private void Start()
    {
        scannedIndicator.SetActive(false);
    }

    private IEnumerator TimeDownIndicator()
    {
       while(scannedDuration > 0)
        {
            scannedDuration-= Time.deltaTime;
            yield return new WaitForSeconds(.1f);
        }
        scannedIndicator.SetActive(false);
        isIndicating= false;
    }

    public void OnScanned()
    {
        if (isIndicating == false)
        {
            scannedIndicator.SetActive(true);
            isIndicating = true;
            StartCoroutine(TimeDownIndicator());
        }
    }

   
}
