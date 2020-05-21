using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public float mSpeed = 5f;

	// Use this for initialization
	void Start () {
	    Debug.Log("Enemy start");
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMotion();
	}

    //moves the gameObject and calls the wander function
	private void UpdateMotion()
	{
		transform.localPosition += mSpeed * Time.smoothDeltaTime * transform.up;
	}

    //Refects over the Z-axis when the gameObject collides with a wall.
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collision");
		if (collision.gameObject.name.Contains("Wall"))
		{
			transform.up = Vector2.Reflect(transform.up, collision.GetContact(0).normal);
		}	
	}
}
