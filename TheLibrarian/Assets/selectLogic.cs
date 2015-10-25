using UnityEngine;
using System.Collections;
using Leap;

public class selectLogic : MonoBehaviour {
	private Controller m_controller;
	public GameObject obj; 
	public GameObject m_camera;
	private string lastUrl="";
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
				int layerMask=1<<8;
				CircleGesture circ = new CircleGesture(gesture);
				Vector3 facing= m_camera.transform.forward;
				RaycastHit hit= new RaycastHit();
				if (Physics.Raycast(m_camera.transform.position,facing,out hit,1000.0f,layerMask)){
					BookLogic the_book=hit.collider.gameObject.GetComponent<BookLogic>();
					string the_url=the_book.getUrl();
					if (lastUrl!=the_url){
						Application.OpenURL(the_url);
						lastUrl=the_url;
					}
				}
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
