using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    public Camera cam = null;
    public LineRenderer lineRenderer = null;
    private Vector3 mousePos;
    private Vector3 Pos;
    private Vector3 previousPos;
    public List<Vector3> linePositions = new List<Vector3>();
    public float minimumDistance = 0.05f;
    private float distance = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FollowPathManager.instance.ResetAll();
            linePositions.Clear();
            mousePos = Input.mousePosition;
            mousePos.z = 10;
            Pos = cam.ScreenToWorldPoint(mousePos);
            previousPos = Pos;
            linePositions.Add(Pos);
        }
       else
          if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 10;
            Pos = cam.ScreenToWorldPoint(mousePos);
            distance = Vector3.Distance(Pos, previousPos);
            if (distance >= minimumDistance)
            {
                previousPos = Pos;
                linePositions.Add(Pos);
                lineRenderer.positionCount = linePositions.Count;
                lineRenderer.SetPositions(linePositions.ToArray());
            }
        }
        else
            if (Input.GetMouseButtonUp(0))
        {
            FollowPathManager.instance.makePlayersFollowPath(linePositions);
        }
    }
}
