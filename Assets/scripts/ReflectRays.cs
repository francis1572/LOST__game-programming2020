using System.Collections.Generic;
using UnityEngine;
using Fungus;


[RequireComponent(typeof(LineRenderer))]
public class ReflectRays : MonoBehaviour
{
    const int Infinity = 999;

    int maxReflections = 5;
    int currentReflections = 0;
    bool isHitting = false;
    bool broad = false;

    [SerializeField]
    Vector2 startPoint, direction;
    List<Vector3> Points;
    List<string> Tags;
    int defaultRayDistance = 1000;
    LineRenderer lr;

    // Use this for initialization
    void Start()
    {
        Points = new List<Vector3>();
        Tags = new List<string>();
        lr = transform.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        var hitData = Physics2D.Raycast(startPoint, (direction - startPoint).normalized, defaultRayDistance);

        currentReflections = 0;
        Points.Clear();
        Points.Add(startPoint);
        Tags.Clear();

        if (hitData)
        {
            ReflectFurther(startPoint, hitData);
        }
        else
        {
            Points.Add(startPoint + (direction - startPoint).normalized * Infinity);
        }

        lr.positionCount = Points.Count;
        lr.SetPositions(Points.ToArray());

        if(Tags[Tags.Count - 1] == "table")
        {
            if(broad == false)
            {
                Flowchart.BroadcastFungusMessage("enough light");
                broad = true;
            }
           
        }
    }

    private void ReflectFurther(Vector2 origin, RaycastHit2D hitData)
    {
        if (currentReflections > maxReflections) return;

        Points.Add(hitData.point);
        Tags.Add(hitData.collider.tag);
        currentReflections++;

        Vector2 inDirection = (hitData.point - origin).normalized;
        Vector2 newDirection = Vector2.Reflect(inDirection, hitData.normal);

        var newHitData = Physics2D.Raycast(hitData.point + (newDirection * 0.0001f), newDirection * 100, defaultRayDistance);
        if (newHitData)
        {
            ReflectFurther(hitData.point, newHitData);
            
        }
        else
        {
            Points.Add(hitData.point + newDirection * defaultRayDistance);
            Tags.Add(newHitData.collider.tag);
        }
    }

    
}