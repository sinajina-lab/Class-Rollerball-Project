using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aura
{

	public class InputManager : MonoBehaviour
	{
        #region public events
        public UnityEvent OnTappedScreen = new UnityEvent();
        public UnityEvent<Vector2> OnTiltScreen = new UnityEvent<Vector2>();
        public UnityEvent<float> OnSideTilt= new UnityEvent<float>();
        #endregion

        #region public fields
        [SerializeField] private float forwardBackCutOff;
        #endregion
        #region Private fields
        private Vector2 tiltInput = Vector2.zero;
        private float currentForwardTiltValue;
        private float previousForwardTiltValue;
        #endregion
        private void Update()
        {
         
            //Handle Tilt
            HandleTilt();
            
        }

        private void HandleTilt()
        {
            tiltInput.x = Input.acceleration.x;
            tiltInput.y = Input.acceleration.y;


            if(tiltInput.y > -forwardBackCutOff)
            {
                tiltInput.y = 1;
            }
            else if(tiltInput.y < -forwardBackCutOff)
            {
                tiltInput.y = -1;
            }


            OnTiltScreen?.Invoke(tiltInput);
            OnSideTilt?.Invoke(tiltInput.x);

        }
      
    }  
}

