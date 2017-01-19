using UnityEngine;
using System.Collections;

public class MausSpawner : MonoBehaviour {
	public GameObject mausPrefab;
	private GameObject mausParent;
	[Range(0.5f,2.5f)]
	public float mausSpeed;
	// Use this for initialization
	void Start () {
		mausParent = GameObject.Find ("MausParent");
		if (!mausParent) {
			mausParent = new GameObject("MausParent");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnMaus() {
		GameObject newMaus = (GameObject)Instantiate (mausPrefab);
		newMaus.GetComponent<Maus> ().StartMaus ();
	}
}
