using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPicker : MonoBehaviour
{
    public int coins;
    //public float rotateSpeed;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Update()
    {
        //gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }

    public void OnTriggerEnter(Collider Col)
    {
        //GameManager.instance.Collect(coins, gameObject);

        //AudioSource source = GetComponent<AudioSource>();
        //source.Play();

        if(Col.gameObject.tag =="Coins")
        {
            collectionSoundEffect.Play();

            Debug.Log("Coins collected!");
            coins = coins + 1;
            //Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }
    }
}
