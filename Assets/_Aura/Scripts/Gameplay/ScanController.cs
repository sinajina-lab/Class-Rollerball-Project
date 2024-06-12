using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanController : MonoBehaviour
{
    public GameObject scanFX;
    public float scanInterval;
    private bool canScan = true;
    public void FireScanFX()
    {
        if (canScan == true)
        {
            Instantiate(scanFX,transform.position,Quaternion.identity);
            StartCoroutine(ToggleScanAbility());
        }
    }    

    IEnumerator ToggleScanAbility()
    {
        canScan = false;
        yield return new WaitForSeconds(scanInterval);
        canScan= true;
    }
}
