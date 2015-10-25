using UnityEngine;
using System.Collections;
using Leap;

public class selectLogic : MonoBehaviour {
	private Controller m_controller;
	public GameObject obj; 
	// Use this for initialization
	void Start () {
		m_controller = new Controller();
		m_controller.EnableGesture (Gesture.GestureType.TYPE_SCREEN_TAP);
		m_controller.EnableGesture (Gesture.GestureType.TYPE_KEY_TAP);
		m_controller.EnableGesture (Gesture.GestureType.TYPE_CIRCLE);
		m_controller.EnableGesture (Gesture.GestureType.TYPE_SWIPE);
		m_controller.EnableGesture (Gesture.GestureType.TYPE_INVALID);
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = m_controller.Frame ();
		foreach (Gesture gesture in frame.Gestures()) {
			if (gesture.Type == Gesture.GestureType.TYPE_SCREEN_TAP){
				ScreenTapGesture stg= new ScreenTapGesture(gesture);
				Debug.Log ("SCREEN TAP");
			}else if (gesture.Type ==Gesture.GestureType.TYPE_KEY_TAP){
				KeyTapGesture ktg = new KeyTapGesture(gesture);
				Debug.Log ("KEY TAP");
			}
			else if (gesture.Type ==Gesture.GestureType.TYPE_CIRCLE){
				CircleGesture circ = new CircleGesture(gesture);
				Leap.Vector center=circ.Center;
				Leap.Vector norm=circ.Normal;
//				Debug.DrawRay(center,norm*3,Color.red);
				Vector3 cen=center.ToUnity();
				Debug.DrawRay(cen,Vector3.one,Color.red);
				Debug.Log (cen);
				obj=new GameObject();
				obj.transform.position=cen;
			}
			else if (gesture.Type ==Gesture.GestureType.TYPE_SWIPE){
				SwipeGesture swipe = new SwipeGesture(gesture);
				Debug.Log ("SWIPE");
			}
			else if (gesture.Type ==Gesture.GestureType.TYPE_INVALID){
				Debug.Log ("INVALID");
			}
		}
	}
}
