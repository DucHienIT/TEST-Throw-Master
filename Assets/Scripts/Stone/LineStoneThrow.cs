using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineStoneThrow : DucHienMonoBehaviour
{
    [SerializeField] protected float throwForce = 10f;
    [SerializeField] protected LineRenderer lineRenderer;
    [SerializeField] protected int maxPoints = 100;
    [SerializeField] protected float pointSpacing = 0.1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        lineRenderer = GetComponent<LineRenderer>();
    }

    protected virtual void Update()
    {
        if (Input.GetMouseButton(0))
        {
            DrawTrajectory();
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
    }

    protected void DrawTrajectory()
    {
        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

        if (hit.collider != null)
        {
            DrawStraightTrajectory(hit.point);
        }
        else
        {
            DrawBouncingTrajectory(direction);
        }
    }

    protected void DrawStraightTrajectory(Vector3 endPosition)
    {
        int numPoints = Mathf.CeilToInt(Vector3.Distance(transform.position, endPosition) / pointSpacing) + 1;
        numPoints = Mathf.Min(numPoints, maxPoints);

        lineRenderer.startWidth = 0.1f; // Đặt độ rộng tại điểm đầu của line
        lineRenderer.endWidth = 0.1f; // Đặt độ rộng tại điểm cuối của line

        lineRenderer.positionCount = numPoints;

        for (int i = 0; i < numPoints; i++)
        {
            float t = (float)i / (numPoints - 1);
            Vector3 point = Vector3.Lerp(transform.position, endPosition, t);
            lineRenderer.SetPosition(i, point);
        }
    }

    protected void DrawBouncingTrajectory(Vector3 direction)
    {
        Vector3 currentPosition = transform.position;
        List<Vector3> points = new List<Vector3>();
        points.Add(currentPosition);

        while (points.Count < maxPoints)
        {
            Vector3 nextPosition = currentPosition + direction * throwForce * Time.fixedDeltaTime;
            RaycastHit2D hit = Physics2D.Raycast(currentPosition, direction, throwForce * Time.fixedDeltaTime);

            if (hit.collider != null)
            {
                Vector3 reflection = Vector3.Reflect(direction, hit.normal);
                direction = reflection.normalized;
                currentPosition = hit.point;
            }
            else
            {
                currentPosition = nextPosition;
            }

            points.Add(currentPosition);

            if (hit.collider != null && hit.collider.CompareTag("Pocket"))
            {
                break;
            }
        }

        lineRenderer.startWidth = 0.1f; // Đặt độ rộng tại điểm đầu của line
        lineRenderer.endWidth = 0.1f; // Đặt độ rộng tại điểm cuối của line

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}
