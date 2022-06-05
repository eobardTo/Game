using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 targetPos;

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
    	targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        transform.position = targetPos;
    }
}
