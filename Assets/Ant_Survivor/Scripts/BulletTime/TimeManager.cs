using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
	private static TimeManager _instance;
	public static TimeManager Instance 
	{
        get
        {
			if(_instance == null)
            {
				_instance = FindObjectOfType<TimeManager>();
				if(_instance == null)
                {
					_instance = new GameObject().AddComponent<TimeManager>();
                }
            }
			return _instance;
        }
	}

    private void Awake()
    {
		_instance = this;
    }
    //[SerializeField] private VisualEffect visualEffesct;

	private ParticleSystem blood;

	public float slowdownFactor = 0.05f;
	public float slowdownLength = 2f;

	bool hasClickedPauseBtn = false;
    private void Start()
    {
		
    }
    private void SetInGameTimeScale()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    private void Update()
    {
        if(hasClickedPauseBtn == false)
        {
			SetInGameTimeScale();
        }
        else
        {
			Time.timeScale = 0;
        }
    }
    public void DoSlowmotion()
	{
		Debug.Log("Inside Timemanager : DoSlowMotion()");
		Time.timeScale = slowdownFactor;
		Time.fixedDeltaTime = Time.timeScale * .02f;
	}

	/// <summary>
	/// Api for handling Pausing and Unpausing
	/// if _value == true, pause if false unpause
	/// </summary>
	/// <param name="_value"></param>
	public void PauseGame(bool _value)
    {
	
		if(_value == true)
        {
			Time.timeScale = 0;
			hasClickedPauseBtn = true;
		}
		if(_value == false)
        {
			
			hasClickedPauseBtn = false;
			SetInGameTimeScale();
		}
    }

}