using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroBehavior : MonoBehaviour {

    public bool mouseControl = false;
    private float mHeroSpeed = 20f;
    private const float kHeroRotateSpeed = 22f;
    private Rigidbody2D rb2d;
    public int touched = 0;
    public GameObject emailControl;

    public GameObject uiCounter;
    private bool touchedA = false;
    bool B = false;
    bool A = false;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
	
    // Update is called once per frame
    void Update () {
        UpdateMotion();
        ChangeSpeed();
        TurnDirection();
    }


    //Determines if the motion of the hero is based on mouse postion or by
    //mHeroSpeed
    private void UpdateMotion() {

        Vector3 mousePos;

        if (Input.GetKeyDown(KeyCode.M))
        {
            uiCounter.GetComponent<UITracking>().ModeChange();
            mouseControl = !mouseControl;
        }

        if (mouseControl) {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            rb2d.MovePosition(mousePos);
        }
        else
            rb2d.MovePosition(rb2d.position + (Vector2)(transform.TransformDirection(Vector3.up) * mHeroSpeed) * Time.deltaTime);
    }

    //Checks angle of attack and peforms a check on location to create bounce
    //effect
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision");
        if (col.gameObject.name.Contains("Wall"))
        {
            transform.up = Vector2.Reflect(transform.up, col.GetContact(0).normal);
        }
        if (col.gameObject.name.Contains("nemy"))
        {
            uiCounter.GetComponent<UITracking>().newTouch();
            Destroy(col.gameObject);
        }
        if (col.gameObject.name.Contains("A_Walk"))
        {
            if (!touchedA)
            {
                //   Debug.Log("touched A");
                emailControl.GetComponent<EmailListControl>().CreateEmail(3);
            }
            touchedA = true;
        }
        if (col.gameObject.name.Contains("B_Walk"))
        {
            if (touchedA && !B)
            {
                emailControl.GetComponent<EmailListControl>().CreateEmail(4);
                B = true;
            }
        }
        /*
        if (col.gameObject.name.Contains("D_Walk"))
        {
            flashingText.GetComponent<EventLog>().newEvent(1);
        }
        if (col.gameObject.name.Contains("B_Walk"))
        {
            flashingText.GetComponent<EventLog>().newEvent(2);
        }
        if (col.gameObject.name.Contains("C_Walk"))
        {
            flashingText.GetComponent<EventLog>().newEvent(3);
        }
        */
    }





    //Allows the player to hit the W,S, and P keys to change velocity
    private void ChangeSpeed()
    {
        mHeroSpeed += Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.P))
            mHeroSpeed = 0;
    }

    //Allows the player to hit the A and D keys to change direction 
    private void TurnDirection()
    {
        if (Input.GetKey(KeyCode.A))      
            rb2d.MoveRotation(rb2d.rotation + kHeroRotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D)) 
            rb2d.MoveRotation(rb2d.rotation - kHeroRotateSpeed * Time.deltaTime);
    }
}
