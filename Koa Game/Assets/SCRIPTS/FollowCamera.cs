using UnityEngine;
using UnityEngine.Collections;

public class FollowCamera : MonoBehaviour
{
	private const float Y_ANGLE_MIN = 0f;
	private const float Y_ANGLE_MAX = 30.0f;

	public Transform lookAt;
	public Transform camTransform;
	public float rotationspeed = 10.0f;

	private float distance = 10.0f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;

	public CursorLockMode cursor;

	void SetCursorState(){
		Cursor.lockState = cursor;
		Cursor.visible = (CursorLockMode.Locked != cursor);
	}

	private void start()
	{

		camTransform = transform;

	}

	private void Update()
	{
		currentX += Input.GetAxis("Mouse X")*rotationspeed *Time.deltaTime;
		currentY -= Input.GetAxis("Mouse Y")*rotationspeed *Time.deltaTime;

		currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
	}

	private void LateUpdate()
	{
		Vector3 dir = new Vector3(0, 0, -distance);
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
		camTransform.position = (lookAt.position + rotation * dir);

		camTransform.LookAt(lookAt.position);
	}

	void OnGUI()
	{
		GUILayout.BeginVertical ();
		// Release cursor on escape keypress
		if (Input.GetKeyDown (KeyCode.Escape))
			Cursor.lockState = cursor = CursorLockMode.None;
		GUILayout.EndVertical();
		SetCursorState ();
	}
}
