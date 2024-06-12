using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aura
{
    public class PlayerMovement : MonoBehaviour
    {
        public Rigidbody rb;
        public float forwardBackSpeed;
        public CameraController camController;
        public GroundChecker groundChecker;

        public float jumpForce;
        public float _gravityModifier;
        public float _dashSpeed;

        private Vector3 MovementInput = new Vector3(0, 0);
        private Vector3 SideMovement = Vector3.zero;
        private Vector3 ForwardMovement = Vector3.zero;
        private Vector3 UpDownMovement = Vector3.zero;

        [SerializeField] private bool isJumping;
        [SerializeField] public bool isInAir { get; private set; }
        [SerializeField] private bool isDashing;

        public void SetIsJumping(bool _Val)
        {
            isJumping = _Val;
        }
        public void SetIsDashing(bool _Val)
        {
            isInAir= _Val;
        }
        public void SetTiltInput(Vector2 input)
        {
            SetForwardBackTiltInput(input.y);
            SetSideInput(input.x);
        }


        private void SetSideInput(float x)
        {

            MovementInput.x = x * forwardBackSpeed;
        }

        public void SetForwardBackTiltInput(float forwardBackTiltInput)
        {
            MovementInput.z = forwardBackTiltInput * forwardBackSpeed;
        }
     

        private void FixedUpdate()
        {
            UpDownMovement.y = Physics.gravity.y;

            if (isJumping == true)
            {        
                    rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
                    isJumping = false;
            }
            if (groundChecker.GetGroundedStatus() == false)
            {
                isInAir = true;
                UpDownMovement.y -= Physics.gravity.y * _gravityModifier;
            }
            else
            {
                isInAir = false;
            }

            SideMovement = camController.GetRightVector() * MovementInput.x;

            if(isDashing== true)
            {
                rb.AddForce(camController.GetForwardVector() * _dashSpeed, ForceMode.Impulse);
                isDashing = false;
            }
            else
            {
                ForwardMovement = camController.GetForwardVector() * MovementInput.z;
            }

            MovementInput = ForwardMovement + SideMovement + UpDownMovement;
            rb.AddForce(MovementInput, ForceMode.Acceleration);
        }
    }
}
