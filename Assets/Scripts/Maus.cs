using UnityEngine;
using System.Collections;

public class Maus : MonoBehaviour {
	public Sprite[] mausLeft;
	public Sprite[] mausRight;
	public Sprite[] mausUp;
	public Sprite[] mausDown;
	private Sprite[] mausMove;



	private MausController mausController;
	private SpriteRenderer sp;

	private int frameCount;
	[Range(0.5f,2.5f)]
	public float mouseSpeed;

	private static float x = 3.5f;
	private static float y = 5.4f;
	private static float MausZ = -1.71f;

	private Vector3 newMausMove;
	// Use this for initialization
	void Start () {
		mausController = FindObjectOfType<MausController> ();
		sp = GetComponent<SpriteRenderer> ();
		mausMove = mausRight;
		newMausMove = new Vector3 (0.25f * mouseSpeed, 0, 0);
		frameCount = 0;


	}

	public void StartMaus() {
		Run ();
		SetColor ();
		Respawn ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		//Debug.Log ("Mausbutton down");
		mausController.MausClicked ();
		Respawn ();

	}

	public void SetMausSpeed(float speed) {
		mouseSpeed = speed;
	}
	public void Respawn() {

		int a, b, c;
		a = Random.Range (0, 2);
		b = Random.Range (0, 2);
		if (a == 0) { //run x achse
			c = Random.Range (1, 12);
			if (b == 0) {
				this.transform.position = new Vector3 (-x,-y + c*1 ,MausZ);
				newMausMove = new Vector3 (0.25f* mouseSpeed, 0, 0);
				mausMove = mausRight;
			} else {
				this.transform.position = new Vector3 (x,-y + c*1 ,MausZ);
				newMausMove = new Vector3 (-0.25f* mouseSpeed, 0, 0);
				mausMove = mausLeft;
			}

		} else { // run y achse
			c = Random.Range(1,5);
			if (b == 0) {
				this.transform.position = new Vector3 (-x + c*1,-y ,MausZ);
				newMausMove = new Vector3 (0, 0.25f* mouseSpeed, 0);
				mausMove = mausUp;
			} else {
				this.transform.position = new Vector3 (-x + c*1,y ,MausZ);
				newMausMove = new Vector3 (0, -0.25f* mouseSpeed, 0);
				mausMove = mausDown;
			}
		}


	}

	void Run() {
		InvokeRepeating ("MausRun", 0, 0.1f);
	}

	void MausRun() {
		if (frameCount == 4) {
			frameCount = 0;
		}
		if (this.transform.position.x > 3.6 || this.transform.position.x < -3.6 ||
			this.transform.position.y > 5.5 || this.transform.position.y < -5.5) {
			//Maus.transform.position -= new Vector3 (5.8f, 0, 0);
			mausController.MausEscaped();
			Respawn();
		}
		this.transform.position += newMausMove;

		sp.sprite = mausMove [frameCount];
		frameCount++;
	}

	void SetColor() {
		Color farbe = new Color (Random.Range(0,255)/255f, Random.Range(0,255)/255f, Random.Range(0,255)/255f,1f);
		Color farbe2 = new Color (0.5F, 0.5F, 0.5F, 1F);
		Debug.Log (farbe);
		Debug.Log (sp); 
		Debug.Log (sp.color);
		sp.material.color = farbe2;
		//sp.material.SetColor("_Color",farbe);
		//Debug.Log (sp.color);
		//sp.color = farbe; 
		//Debug.Log (sp.color);
	}

	/* void MouseHit() {
		mouseHit = true;
		controller.touchCount++;
		controller.text.text = "MouseCounter: " + controller.touchCount;
		mouseHit = false;
		controller.NewMaus ();
		RespawnMouse ();
	} */

}
