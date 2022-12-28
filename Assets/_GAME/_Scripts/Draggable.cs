using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    [SerializeField] private Vector3 leftOffset;
    [SerializeField] private Vector3 rightOffset;
    [SerializeField] private Vector3 backOffset;
    [SerializeField] private Vector3 frontOffset;

    [SerializeField] private GameObject rightBox;
    [SerializeField] private GameObject leftBox;

    [SerializeField] private GameObject frontBox;

    [SerializeField] private GameObject backBox;
    
    private float mZCoord;
    private Vector3 mOffset;
    private void Start()
    {
        leftOffset = leftBox.transform.position;
        rightOffset = rightBox.transform.position;
        backOffset = backBox.transform.position;
        frontOffset = frontBox.transform.position;
    }
    void OnMouseDown()
    {
        if (this.enabled)
        {

            mZCoord = Camera.main.WorldToScreenPoint(
           gameObject.transform.position).z;
            // Store offset = gameobject world pos - mouse world pos
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.position.z, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (this.enabled)
        {

            // Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, transform.position.z, screenPoint.z);
            // Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            // transform.position = curPosition;
            // if (curPosition.x < leftOffset.x)
            // {
            //     transform.position = new Vector3(leftOffset.x, transform.position.y, transform.position.z);
            // }
            // else if (curPosition.x > rightOffset.x)
            // {
            //     transform.position = new Vector3(rightOffset.x, transform.position.y, transform.position.z);
            // }
            // else
            //     transform.position = curPosition;
            Vector3 curPosition = new Vector3(GetMouseAsWorldPoint().x + mOffset.x, transform.position.y, GetMouseAsWorldPoint().z + mOffset.z + 0.05f);
            transform.position = curPosition;
            if (curPosition.x < leftOffset.x)
            {
                transform.position = new Vector3(leftOffset.x, transform.position.y, curPosition.z);
            }
            else if (curPosition.x > rightOffset.x)
            {
                transform.position = new Vector3(rightOffset.x, transform.position.y, curPosition.z);
            }
            else if (curPosition.z > backOffset.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, backOffset.z);
            }

            else if (curPosition.z < frontOffset.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, leftOffset.z);
            }
            else
                transform.position = curPosition;

        }
    }
    private Vector3 GetMouseAsWorldPoint()

    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }
}
