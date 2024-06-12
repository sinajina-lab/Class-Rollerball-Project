using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AntCollecter : MonoBehaviour
{
    private int ant = 0;

    [SerializeField] private TextMeshProUGUI foodText;

    [SerializeField] private AudioSource AntSoundEffect;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            AntSoundEffect.Play();

            Destroy(collision.gameObject);
            ant++;
            foodText.text = "Food: " + ant;
        }
    }

    public void NextLevelFun()
    {
        SceneManager.LoadScene("MainMenu");
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
