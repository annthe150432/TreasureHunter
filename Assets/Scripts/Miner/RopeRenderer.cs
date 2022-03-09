using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{

    private LineRenderer lineRenderer;

    [SerializeField]
    private Transform startPosition;

    private float lineWidth = 0.05f;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void RenderLine(Vector3 endLinePos, bool enabledRenderer)
    {
        if (enabledRenderer)
        {
            if (!lineRenderer.enabled)
            {
                // enable line renderer
                lineRenderer.enabled = true;
            }

            lineRenderer.positionCount = 2;

        }
        else
        {
            lineRenderer.positionCount = 0;
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }

        }

        if(lineRenderer.enabled)
        {
            Vector3 temp = startPosition.position;
            temp.z = 0f;

            startPosition.position = temp;
            temp = endLinePos;
            temp.z = 1f;

            endLinePos = temp;
            lineRenderer.SetPosition(0, startPosition.position);
            lineRenderer.SetPosition(1, endLinePos);

        }
    }
}
