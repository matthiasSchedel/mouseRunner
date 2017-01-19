using UnityEngine;
using System.Collections;


public class MausController : MonoBehaviour {

	private int lifes;
	[Range(1,20)]
	public int maxLifes;
	private int touchCount;
	private AudioSource audioSource;
	private AudioClip mausMissed;
	private AudioClip mausClicked;
	public GameObject particle;
	private LevelManager levelmanager;
	public AudioClip[] clips;
	[Range(1,30)]
	public int spawnMouseEveryXTouches;

	//private static float x = 3.7f;
	//private static float y = 5.61f;
	//private static float MausZ = 1.71f;

	private MausUI ui;
	private MausSpawner mausSpawner;
	// 2.7 * 2 = 5.4
	// 5.6 * 2 = 12 


	// Use this for initialization
	void Start () {
		levelmanager = FindObjectOfType<LevelManager> ();
		lifes = maxLifes;
		touchCount = 0;
		mausSpawner = FindObjectOfType<MausSpawner> ();
		ui = FindObjectOfType<MausUI> ();
		audioSource = GetComponent<AudioSource> ();
		mausMissed = clips[0];
		mausClicked = clips[1];	
		mausSpawner.SpawnMaus ();
		ui.UpdateLifes (lifes, maxLifes);
		ui.UpdateTouchCount (touchCount);



		//MausArray [0].Run ();
	}

	void StartMaus(Maus maus) {
		
	}

	public void MausClicked() {
		audioSource.clip = mausClicked;
		audioSource.Play ();
		if (++touchCount % spawnMouseEveryXTouches == 0) {
			mausSpawner.SpawnMaus ();
		}
		ui.UpdateTouchCount (touchCount);
	}

	public void MausEscaped() {
		audioSource.clip = mausMissed;
		audioSource.Play ();
		if (--lifes == 0) {
			levelmanager.LoadLevel ("03 Game Over");
		}
		ui.UpdateLifes (lifes, maxLifes);
		Debug.Log ("MausEscaped");
	}



}
