using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeftRigtControls : MonoBehaviour
{
	[Header("Player Collision Variables")] //Seperate components in inspector - to  make the project user friendly, not needed
	/*public LayerMask whatIsGround; //make the public variable to assign which unity layer is to be considered as ground
	public bool isGround; //boolean to store if pc is colliding with anything on Ground Layer
	public Transform groundCheckFrontTransform; //Store the GroundCheckFront Transform in Inspector
	public Transform groundCheckBackTransform; //Store the GroundCheckBack Transform in Inspector */

	public Transform playerTransform;
	public Animator playerAnimator;
	public float speed = 2f;
	[SerializeField] private AudioSource jumpSoundEffect;

	public int score;
	public LayerMask groundLayer;
	public Transform landedSphere;

	public Rigidbody rb;


	bool IsGrounded()
	{
		RaycastHit hit;
		bool grounded = (Physics.Raycast(transform.position, -transform.up, out hit, 1.5f, groundLayer));
		if (grounded)
		{
			landedSphere = hit.collider.gameObject.transform;
		}

		return grounded;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Ground"))
		{
			score++;
			Debug.Log("Score" + score);
		}
	}

	void HorizontalMovementBehavoir()
	{
		Vector2 currentAcceleration = Input.acceleration;

		float keyboardHorizontal = Input.GetAxis("Horizontal");
		Debug.Log("TiltAcceleration =" + currentAcceleration + " |||AND||| Keyboard Acceleration is" + keyboardHorizontal);

		if (keyboardHorizontal != 0f)
		{
			currentAcceleration = new Vector2(keyboardHorizontal, 0f);
		}

		Vector3 currentPosition = playerTransform.position;
		Vector3 displacement = currentAcceleration * Time.deltaTime * speed;
		displacement.z = 0f;
		displacement.y = 0f;
		Vector3 nextPosition = currentPosition + displacement;
		playerTransform.position = nextPosition;

		//add some clamping to the "next position" in case it's out of bounds/etcetera etcetera
	}
	/*
	private void OnEnable()
    {
		PlayerHealth.OnPlayDeath += DisablePlayerMovement;
    }

	private void OnDisable()
    {
		PlayerHealth.OnPlayerDeath -= DisablePlayerMovement;
    }

	private void Start()
    {
		EnablePlayerMovement();
	}
	*/

	private void Update()
	{
		HorizontalMovementBehavoir();

		if (ShouldJump())
		{
			playerAnimator.SetTrigger("Jump");
			jumpSoundEffect.Play();
		}
	}


	bool ShouldJump()
	{
		//Debug.Log("Input.Touches = " + Input.touches.Length);


		if (Input.touches.Length > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				return true;
			}
		}
		else if (Input.GetMouseButtonDown(0))
		{
			return true;
		}

		return false;
	}



	IEnumerator DoJump()
	{
		yield return null;
	}
}
