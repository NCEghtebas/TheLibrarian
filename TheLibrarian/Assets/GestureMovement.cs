using UnityEngine;
using System.Collections;
using Leap;

public class GestureMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Controller controller = GetComponent<Controller>();
		controller.EnableGesture (Gesture.GestureType.TYPE_KEY_TAP);
		Debug.Log ("Gestate");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
