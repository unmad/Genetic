using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

	public float speed;
	public float maxSpeed;
	public float momentum;
	public GameObject gun;
	public GameObject floor;

	private Vector3 moveDirection = Vector3.zero;
	private Vector3 lastDirection = Vector3.zero;

	void Update() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit);
		Vector3 mousePos = hit.point;
		mousePos.y = 1f;

		if (transform.position.y > 1.1f || transform.position.y < 0.9f){
			Vector3 tr = new Vector3 (0f, 1f, 0f);
			transform.Translate(tr);
		}
		Debug.DrawLine(transform.position, mousePos, Color.red);
		gun.transform.LookAt(mousePos);


		CharacterController controller = GetComponent<CharacterController>();

		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		moveDirection += lastDirection * momentum;
		moveDirection = Vector3.ClampMagnitude(moveDirection, maxSpeed);

		controller.Move(moveDirection * Time.deltaTime);
		lastDirection = moveDirection;

		Vector3 camPos = new Vector3 (0f, 0f, 0f);
		camPos = (mousePos/2f + transform.position) / 2f;
		camPos.y = Camera.main.transform.position.y;
		Camera.main.transform.position = camPos;
	}
}