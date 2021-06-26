using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendrerFollowMouse : MonoBehaviour
{
    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lineRenderer.enabled)
        {
            lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        }

    }
}
