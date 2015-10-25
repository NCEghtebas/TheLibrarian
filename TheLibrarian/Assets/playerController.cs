using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public GameObject m_camera;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
//		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		Vector3 forMov = m_camera.transform.forward * speed * Input.GetAxis ("Vertical") * Time.deltaTime;
		Vector3 sideMov = m_camera.transform.right * speed * Input.GetAxis ("Horizontal") * Time.deltaTime;
		Vector3 forMovClamp = new Vector3 (forMov.x,0f , forMov.z);
		Vector3 sideMovClamp = new Vector3 (sideMov.x,0f ,sideMov.z);
		controller.Move (forMovClamp);
		controller.Move (sideMovClamp);
		//		moveDirection = transform.TransformDirection(moveDirection);
//		moveDirection *= speed;
//		controller.Move(moveDirection * Time.deltaTime);
	}
}