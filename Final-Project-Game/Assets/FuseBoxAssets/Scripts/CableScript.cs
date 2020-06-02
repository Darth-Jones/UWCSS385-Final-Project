using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CableScript : MonoBehaviour
{
    //Cable head properties -- to click, drag, place with mouse 
    [SerializeField] private Transform leftTilePosition;
    [SerializeField] private Transform midTilePosition;
    [SerializeField] private Transform rightTilePosition;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    private bool locked;
    private bool lineLocked;
    public int myValue;

    //Line renderer properties 
    private Vector3 startPos;
    private Vector3 endPos;
    private Camera camera;
    private LineRenderer lineRenderer;
    private SpriteRenderer spriteRenderer;
    private Color lineColor;
    Vector3 camOffset = new Vector3(0, 0, 10);
    [SerializeField] private AnimationCurve ac;

    //Boolean toggle for occupied ports 
    public static bool leftTilePort1Taken;
    public static bool leftTilePort2Taken;
    public static bool leftTilePort3Taken;

    public static bool midTilePort1Taken;
    public static bool midTilePort2Taken;
    public static bool midTilePort3Taken;

    public static bool rightTilePort1Taken;
    public static bool rightilePort2Taken;
    public static bool rightTilePort3Taken;

    //Summed totals for win conditions -- static for access in scene control 
    public static int totalTile1;
    public static int totalTile2;
    public static int totalTile3;

    public static int numberNeeded1;
    public static int numberNeeded2;
    public static int numberNeeded3;

    public int number1;
    public int number2;
    public int number3;

    private Vector3 scaleUp;
    private Vector3 scaleDown;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        initialPosition = transform.position;
        leftTilePort1Taken = leftTilePort2Taken = leftTilePort3Taken = false;
        midTilePort1Taken = midTilePort2Taken = midTilePort3Taken = false;
        rightTilePort1Taken = rightilePort2Taken = rightTilePort3Taken = false;
        scaleUp = new Vector3(10, 10, 10);
        scaleDown = new Vector3(transform.localScale.x,
            transform.localScale.y, transform.localScale.z);
        lineRenderer = GetComponent<LineRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lineColor = spriteRenderer.color;
        numberNeeded1 = number1;
        numberNeeded2 = number2;
        numberNeeded3 = number3;
    }

    void Update()
    {
        //if (totalTile1 == numberNeeded1 && totalTile2 == numberNeeded2
        //    && totalTile3 == numberNeeded3)
        //{
        //    // Do something here
        //    Debug.Log("PUZZLE SOLVED");
        //}
    }

    private void OnMouseDown()
    {
        if (!locked && !lineLocked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

            if (Input.GetMouseButtonDown(0))
            {
                if (lineRenderer == null)
                {
                    lineRenderer = gameObject.AddComponent<LineRenderer>();
                    lineRenderer.material.color = Color.white;
                    lineRenderer.material.color = lineColor;
                }
                Vector2 cablePos = new Vector2(initialPosition.x, initialPosition.y - 3);
                lineRenderer.positionCount = 2;
                startPos = cablePos;
                lineRenderer.SetPosition(0, startPos);
                lineRenderer.useWorldSpace = true;

                lineRenderer.enabled = true;

                //lr.widthCurve = ac;
                //lr.numCapVertices = 10;
            }
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }

        if (!lineLocked && Input.GetMouseButton(0))
        {
            endPos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            lineRenderer.SetPosition(1, endPos);
        }
    }

    private void OnMouseUp()
    {
        transform.localScale = scaleDown;
        if (!locked)
        {
            if (Mathf.Abs(transform.position.x - leftTilePosition.position.x) <= 5f &&
                Mathf.Abs(transform.position.y - leftTilePosition.position.y) <= 5f)
            {
                if ((leftTilePort1Taken == false) && (leftTilePort2Taken == false)
                    && (leftTilePort3Taken == false))
                {
                    transform.position = new Vector2(leftTilePosition.position.x - 2.5f, leftTilePosition.position.y - 4);
                    endPos = new Vector2(leftTilePosition.position.x - 2.5f, leftTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = leftTilePort1Taken = true;
                    totalTile1 += myValue;
                    Debug.Log(totalTile1 + ", " + totalTile2 + ", " + totalTile3);
                }
                else if ((leftTilePort1Taken == true) && (leftTilePort2Taken == false)
                    && (leftTilePort2Taken == false))
                {
                    transform.position = new Vector2(leftTilePosition.position.x, leftTilePosition.position.y - 4);
                    endPos = new Vector2(leftTilePosition.position.x, leftTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = leftTilePort2Taken = true;
                    totalTile1 += myValue;
                    Debug.Log(totalTile1 + ", " + totalTile2 + ", " + totalTile3);
                }
                else
                {
                    transform.position = new Vector2(leftTilePosition.position.x + 2.5f, leftTilePosition.position.y - 4);
                    endPos = new Vector2(leftTilePosition.position.x + 2.5f, leftTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = leftTilePort3Taken = true;
                    totalTile1 += myValue;
                    Debug.Log(totalTile1 + ", " + totalTile2 + ", " + totalTile3);
                }

            }
            else if (Mathf.Abs(transform.position.x - midTilePosition.position.x) <= 5f &&
                    Mathf.Abs(transform.position.y - midTilePosition.position.y) <= 5f)
            {
                if ((midTilePort1Taken == false) && (midTilePort2Taken == false)
                    && (midTilePort3Taken == false))
                {
                    transform.position = new Vector2(midTilePosition.position.x - 2.5f, midTilePosition.position.y - 4);
                    endPos = new Vector2(midTilePosition.position.x - 2.5f, midTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = midTilePort1Taken = true;
                    totalTile2 += myValue;
                    Debug.Log(totalTile1 + ", " + totalTile2 + ", " + totalTile3);
                }
                else if ((midTilePort1Taken == true) && (midTilePort2Taken == false)
                    && (midTilePort3Taken == false))
                {
                    transform.position = new Vector2(midTilePosition.position.x, midTilePosition.position.y - 4);
                    endPos = new Vector2(midTilePosition.position.x, midTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = midTilePort2Taken = true;
                    totalTile2 += myValue;
                    Debug.Log(totalTile1 + ", " + totalTile2 + ", " + totalTile3);
                }
                else
                {
                    transform.position = new Vector2(midTilePosition.position.x + 2.5f, midTilePosition.position.y - 4);
                    endPos = new Vector2(midTilePosition.position.x + 2.5f, midTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = midTilePort3Taken = true;
                    totalTile2 += myValue;
                    Debug.Log(totalTile1 + ", " + totalTile2 + ", " + totalTile3);
                }
            }
            else if (Mathf.Abs(transform.position.x - rightTilePosition.position.x) <= 5f &&
                Mathf.Abs(transform.position.y - rightTilePosition.position.y) <= 5f)
            {
                if ((rightTilePort1Taken == false) && (rightilePort2Taken == false)
                    && (rightTilePort3Taken == false))
                {
                    transform.position = new Vector2(rightTilePosition.position.x - 2.5f, rightTilePosition.position.y - 4);
                    endPos = new Vector2(rightTilePosition.position.x - 2.5f, rightTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = rightTilePort1Taken = true;
                    totalTile3 += myValue;
                    Debug.Log(totalTile1 + ", " + totalTile2 + ", " + totalTile3);
                }
                else if ((rightTilePort1Taken == true) && (rightilePort2Taken == false)
                    && (rightTilePort3Taken == false))
                {
                    transform.position = new Vector2(rightTilePosition.position.x, rightTilePosition.position.y - 4);
                    endPos = new Vector2(rightTilePosition.position.x, rightTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = rightilePort2Taken = true;
                    totalTile3 += myValue;
                    Debug.Log(totalTile1 + ", " + totalTile2 + ", " + totalTile3);
                }
                else
                {
                    transform.position = new Vector2(rightTilePosition.position.x + 2.5f, rightTilePosition.position.y - 4);
                    endPos = new Vector2(rightTilePosition.position.x + 2.5f, rightTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = rightTilePort3Taken = true;
                    totalTile3 += myValue;
                    Debug.Log(totalTile1 + ", " + totalTile2 + ", " + totalTile3);
                }

            }
            else
            {
                transform.position = new Vector2(initialPosition.x, initialPosition.y);
            }
        }
        if (Input.GetMouseButtonUp(0) && !locked)
        {
            lineRenderer.enabled = false;
        }
    }

    private void OnMouseOver()
    {
        if (!locked) {
            transform.localScale = scaleUp;
        }
    }

    private void OnMouseExit()
    {
        transform.localScale = scaleDown;
    }

    public static void ResetVariables() {
        Debug.Log(totalTile1 + ", " + totalTile2 + ", " + totalTile3);
        totalTile1 -= totalTile1;
        totalTile2 -= totalTile2;
        totalTile3 -= totalTile3;
    }

}
