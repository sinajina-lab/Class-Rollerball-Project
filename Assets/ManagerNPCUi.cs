using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerNPCUi : MonoBehaviour
{
    private GameObject objPlayer;
    public Image prefabUi;
    private Image uiUse;
    private Transform tr_head;
    private Vector3 offset = new Vector3(0, 1.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        objPlayer = GameObject.FindGameObjectWithTag("Player");
        uiUse = Instantiate(prefabUi, FindObjectOfType<Canvas>(true).transform).GetComponent<Image>();
        tr_head = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (tr_head != null)
        {

            uiUse.transform.position = Camera.main.WorldToScreenPoint(tr_head.position + offset);
        }

        //Get Distance fromt the Player
        float dist = 1 / Vector3.Distance(transform.position, objPlayer.transform.position) * 2f;

        //Deform UI size
        dist = Mathf.Clamp(dist, 0.5f, 1.0f);
        uiUse.transform.localScale = new Vector3(dist, dist, 0);
    }
}
