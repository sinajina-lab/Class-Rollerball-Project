using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CarnivorousPlantTap : MonoBehaviour
    {
        public void Snap()
        {
            if(this.transform.localPosition.y < 0f)
            {
                StartCoroutine(_Snap());
            }
        }

        IEnumerator _Snap()
        {
            float delay = Random.Range(0f, 0.25f);

            yield return new WaitForSeconds(delay);

            this.transform.localPosition += (Vector3.up * 1f);
        }

        //Makes it go back to its original position
        public void Retract()
        {
            if (this.transform.localPosition.y > 0f)
            {
                StartCoroutine(_Retract());
            }
        }

        IEnumerator _Retract()
        {
            float delay = Random.Range(0f, 0.25f);

            yield return new WaitForSeconds(delay);

            this.transform.localPosition -= (Vector3.up * 1f);
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

