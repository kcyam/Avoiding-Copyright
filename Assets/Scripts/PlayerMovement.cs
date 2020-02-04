using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
	
	public Transform LookTransform;
	public Vector3 Gravity = Vector3.down * 9.81f;
	public float RotationRate = 0.1f;
	public float Velocity = 8;
	public float GroundControl = 1.0f;
	public float AirControl = 0.2f;
	public float JumpVelocity = 5;
	public float GroundHeight = 1.1f;
	private bool jump;

    public int stamina;

    public bool canMove; //For dialogue talking
    public bool yMatters;

	void Start() { 
		GetComponent<Rigidbody>().freezeRotation = true;
		GetComponent<Rigidbody>().useGravity = false;
        stamina = 1800;
        canMove = true;
	}
	
	void Update() {
		jump = jump || Input.GetButtonDown("Jump");

        if (yMatters)
        {
            if (this.transform.position.y <= 90)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
	
	void FixedUpdate() {
	    if(!canMove)
        {
            return;
        }

		// Cast a ray towards the ground to see if the Walker is grounded
		bool grounded = Physics.Raycast(transform.position, Gravity.normalized, GroundHeight);
		
		// Rotate the body to stay upright
		Vector3 gravityForward = Vector3.Cross(Gravity, transform.right);
		Quaternion targetRotation = Quaternion.LookRotation(gravityForward, -Gravity);
		GetComponent<Rigidbody>().rotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, RotationRate);
		
		// Add velocity change for movement on the local horizontal plane
		Vector3 forward = Vector3.Cross(transform.up, -LookTransform.right).normalized;
		Vector3 right = Vector3.Cross(transform.up, LookTransform.forward).normalized;
		Vector3 targetVelocity = (forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal")) * Velocity;
		Vector3 localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
		Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity) - localVelocity;
		
		// The velocity change is clamped to the control velocity
		// The vertical component is either removed or set to result in the absolute jump velocity
		velocityChange = Vector3.ClampMagnitude(velocityChange, grounded ? GroundControl : AirControl);
		velocityChange.y = jump && grounded ? -localVelocity.y + JumpVelocity : 0;
		velocityChange = transform.TransformDirection(velocityChange);
		GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);
		
		// Add gravity
		GetComponent<Rigidbody>().AddForce(Gravity * GetComponent<Rigidbody>().mass);
		
		jump = false;

        if(Input.GetKey("left shift") && (Input.GetKey("w") || Input.GetKey("a") ||
            Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("up arrow") || Input.GetKey("left arrow") ||
            Input.GetKey("right arrow") || Input.GetKey("down arrow")))
        {
            if (stamina > 0)
                Velocity = 16;
            else
                Velocity = 8;
            stamina -= 30;
        }

        if (Input.GetKeyUp("left shift"))
        {
            Velocity = 8;
        }

        if(stamina > 1800)
            stamina++;
        //print(stamina);
    }
	
}