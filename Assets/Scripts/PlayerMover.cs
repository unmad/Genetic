using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

	public float speed = 6.0F;
	public GameObject gun;

	private Vector3 moveDirection = Vector3.zero;

	void Update() {
		if (transform.position.y > 1.1f || transform.position.y < 0.9f){
			float y = transform.position.y - 1f;
			Vector3 tr = new Vector3 (0f, -transform.position.y + 1f, 0f);
			Debug.Log(transform.position.y + " - " + y);
			transform.Translate(tr);
		}
		var mouseX = Input.mousePosition.x;
		var mouseY = Input.mousePosition.y;
		var mouseZ = Camera.main.transform.position.y - gun.transform.position.y;

		Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX,  mouseY, mouseZ));
		
		Vector3 turretLookDirection = new Vector3(worldPos.x,gun.transform.position.y, worldPos.z);
		
		gun.transform.LookAt(turretLookDirection);


		CharacterController controller = GetComponent<CharacterController>();

		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		controller.Move(moveDirection * Time.deltaTime);
	}
}