using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public GameObject gun;
	public Camera mainCam;

	private Vector3 moveDirection = Vector3.zero;

	void Update() {
		var mouseX = Input.mousePosition.x;
		var mouseY = Input.mousePosition.y;
		var mouseZ = mainCam.transform.position.y - gun.transform.position.y;

		Vector3 worldPos = mainCam.ScreenToWorldPoint(new Vector3(mouseX,  mouseY, mouseZ));
		
		Vector3 turretLookDirection = new Vector3(worldPos.x,gun.transform.position.y, worldPos.z);
		
		gun.transform.LookAt(turretLookDirection);


		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			/*if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;*/
			}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}