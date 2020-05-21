using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggLauncher : MonoBehaviour
{
	public GameObject prefabToSpawn;

	// The key to press to create the objects/projectiles
	public KeyCode keyToPress = KeyCode.Space;

	// The rate of creation, as long as the key is pressed
	public float creationRate = .5f;

	private float newCreationRate;

	// The speed at which the object are shot along the Y axis
	public float shootSpeed = 40f;

    //Sets the intial direction that objects will be launched
	public Vector2 shootDirection = new Vector2(0f, 1f);

	public bool relativeToRotation = true;

	public float timeOfLastSpawn;
	// Use this for initialization
	void Start()
	{
		newCreationRate = creationRate;
		timeOfLastSpawn = -creationRate;
		
	}


	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(keyToPress)
		   && Time.time >= timeOfLastSpawn + newCreationRate)
		{
			Vector2 actualEggDirection = (relativeToRotation) ? (Vector2)(Quaternion.Euler(0, 0, transform.eulerAngles.z) * shootDirection) : shootDirection;

			GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
			newObject.transform.position = this.transform.position;
			newObject.transform.eulerAngles = new Vector3(0f, 0f, Angle(actualEggDirection));

			// push the created objects, but only if they have a Rigidbody2D
			Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>();
			if (rigidbody2D != null)
			{
				rigidbody2D.AddForce(actualEggDirection * shootSpeed, ForceMode2D.Impulse);
			}
			timeOfLastSpawn = Time.time;
		}
	}

    //determines the direction the 
	public static float Angle(Vector2 inputVector)
	{
		if (inputVector.x < 0) return (Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg * -1) - 360;
		else return -Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg;
	}

    //Takes input from the slider UI element to adjust the creation rate of
    //egg launches
    public void adjustCreationSpeed(float sliderAmount)
    {
        newCreationRate = creationRate * sliderAmount;
    }
}
