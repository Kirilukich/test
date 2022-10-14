using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Vector3 mousePos;
    Vector3 mouseDir;
    Camera cam;
    LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0;
        mouseDir = mouseDir.normalized;

        if(Input.GetMouseButtonDown(0))
        {
            line.enabled = true;
        }

        if(Input.GetMouseButton(0))
        {
            startPos = gameObject.transform.position;
            startPos.z = 0;
            line.SetPosition(0, startPos);
            endPos = mousePos;
            endPos.z = 0;
            line.SetPosition(1, endPos);
        }

        if(Input.GetMouseButtonUp(0))
        {
            StartCoroutine(DelayLine());
        }
    }

    IEnumerator DelayLine()
    {
        yield return new WaitForSeconds(1);
        line.enabled = false;
    }
}
