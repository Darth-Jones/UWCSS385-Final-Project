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
    public Color lineColor;
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

    public int numberNeeded1;
    public int numberNeeded2;
    public int numberNeeded3;

    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        initialPosition = transform.position;
        leftTilePort1Taken = leftTilePort2Taken = leftTilePort3Taken = false;
        midTilePort1Taken = midTilePort2Taken = midTilePort3Taken = false;
        rightTilePort1Taken = rightilePort2Taken = rightTilePort3Taken = false;
    }

    /// <summary>
    /// This method 
    /// </summary>
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
                }
                else if ((leftTilePort1Taken == true) && (leftTilePort2Taken == false)
                    && (leftTilePort2Taken == false))
                {
                    transform.position = new Vector2(leftTilePosition.position.x, leftTilePosition.position.y - 4);
                    endPos = new Vector2(leftTilePosition.position.x, leftTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = leftTilePort2Taken = true;
                    totalTile1 += myValue;
                }
                else
                {
                    transform.position = new Vector2(leftTilePosition.position.x + 2.5f, leftTilePosition.position.y - 4);
                    endPos = new Vector2(leftTilePosition.position.x + 2.5f, leftTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = leftTilePort3Taken = true;
                    totalTile1 += myValue;
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
                    totalTile3 += myValue;
                }
                else if ((midTilePort1Taken == true) && (midTilePort2Taken == false)
                    && (midTilePort3Taken == false))
                {
                    transform.position = new Vector2(midTilePosition.position.x, midTilePosition.position.y - 4);
                    endPos = new Vector2(midTilePosition.position.x, midTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = midTilePort2Taken = true;
                    totalTile3 += myValue;

                }
                else
                {
                    transform.position = new Vector2(midTilePosition.position.x + 2.5f, midTilePosition.position.y - 4);
                    endPos = new Vector2(midTilePosition.position.x + 2.5f, midTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = midTilePort3Taken = true;
                    totalTile3 += myValue;

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
                    totalTile2 += myValue;

                }
                else if ((rightTilePort1Taken == true) && (rightilePort2Taken == false)
                    && (rightTilePort3Taken == false))
                {
                    transform.position = new Vector2(rightTilePosition.position.x, rightTilePosition.position.y - 4);
                    endPos = new Vector2(rightTilePosition.position.x, rightTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = rightilePort2Taken = true;
                    totalTile2 += myValue;

                }
                else
                {
                    transform.position = new Vector2(rightTilePosition.position.x + 2.5f, rightTilePosition.position.y - 4);
                    endPos = new Vector2(rightTilePosition.position.x + 2.5f, rightTilePosition.position.y - 4);
                    lineRenderer.SetPosition(1, endPos);
                    locked = lineLocked = rightTilePort3Taken = true;
                    totalTile2 += myValue;
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

    public static void ResetVariables() {
        totalTile1 -= totalTile1;
        totalTile2 -= totalTile2;
        totalTile3 -= totalTile3;
    }

    //public int GetTotalTile1()
    //{
    //    return this.totalTile1;
    //}

    //public int GetTotalTile2()
    //{
    //    return this.totalTile2;
    //}

    //public int GetTotalTile3()
    //{
    //    return this.totalTile3;
    //}

    //public void SetTotalTile1(int total)
    //{
    //    this.totalTile1 = total;
    //}

    //public void SetTotalTile2(int total)
    //{
    //    this.totalTile2 = total;
    //}

    //public void SetTotalTile3(int total)
    //{
    //    totalTile3 = total;
    //}



}
