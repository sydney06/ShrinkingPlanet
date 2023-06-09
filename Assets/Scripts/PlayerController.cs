using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotationSpeed = 10f;
	public float rotationIntensity = 2;

	private float rotation;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		rotation = Input.GetAxisRaw("Horizontal");

        if (MobileInput.Instance.SwipeLeft)
        {
			MovePlayerLeft();
			Debug.Log("Swiped left!!");
        }

		else if (MobileInput.Instance.SwipeRight)
		{
			MovePlayerRight();
			Debug.Log("Swiped right!!");
		}
	}

	void FixedUpdate ()
	{
		rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
		Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
		Quaternion deltaRotation = Quaternion.Euler(yRotation);
		Quaternion targetRotation = rb.rotation * deltaRotation;
		rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
		//transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
	}

    public void MovePlayerLeft()
    {
		rotation = -1f * rotationIntensity;
    }

	public void MovePlayerRight()
    {
		rotation = 1f * rotationIntensity;
    }
}
