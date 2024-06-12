using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;
using UnityEngine.EventSystems;


public class ExplosionGun : MonoBehaviour
{
	public GameObject explosion;    // The explosion prefab
	public Camera cam;              // Reference to the Player camera

	public TimeManager timeManager;
	const float double_click_time = .2f;
	private float lastClickTime;

	//public int tapTimes;
	//public float resetTimer;

	//[SerializeField] private VisualEffect visualEffesct;

	[Header("BuletTime")]
	public Image abilityImage;
	bool isCooldown = false;
	public float coolDown = 1;
	//public float coolDownTimer;

    private void Start()
    {
		abilityImage.fillAmount = 0;
    }

    void Update()
	{
		// If the player presses fire
		if (Input.GetMouseButtonDown(0))
			//Shoot();

		//float timeSinceLastClick = timeSinceLastClick.time - lastClickTime;

		//if(timeSinceLastClick <= double_click_time)
        {
			
		}

		/*if(coolDownTimer > 0)
        {
			coolDownTimer -= Time.deltaTime;
        }

		if(coolDownTimer < 0)
        {
			coolDown = 0;
        }

		if (Input.GetButton("Fire1") && coolDownTimer == 0)
		{
			Debug.Log("SlowMotion");
			coolDownTimer = coolDown;
			//StartCoroutine("ResetTapTimes");
			//tapTimes++;

			Shoot();
		} */

		if (Input.GetButton("Fire1") && isCooldown == false && !EventSystem.current.IsPointerOverGameObject())
		{
			//visualEffesct.SetFloat("")

			isCooldown = true;
			abilityImage.fillAmount = 1;

			Shoot();
		}

		if (isCooldown)
		{
			abilityImage.fillAmount -= 1 / coolDown * Time.deltaTime;
		}

		if (abilityImage.fillAmount <= 0)
		{
			abilityImage.fillAmount = 0;
			isCooldown = false;
		}
	}

	void Shoot()
	{
		RaycastHit _hitInfo;
		// If we hit something
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hitInfo))
		{
			// Create an explosion at the impact point
			Instantiate(explosion, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));

			timeManager.DoSlowmotion();
		}
	}
}