using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MausUI : MonoBehaviour {
	private Text lifeCount;
	private Text touchCount;
	// Use this for initialization
	void Start () {
		lifeCount = GetComponentsInChildren<Text> () [2];
		touchCount = GetComponentsInChildren<Text> () [1];
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateLifes(int lifes, int totallifes) {
		lifeCount.text = lifes.ToString () + "/" + totallifes;
	}

	public void UpdateTouchCount(int count) {
		touchCount.text = "Mauscounter: " + count.ToString ();
	}
}
