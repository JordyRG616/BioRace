using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class DistributeOnPath : MonoBehaviour
{
    public GameObject obstacle;
    public PathCreator pc;    
    public float distanceBetween = 20;
    public float randomDistribuition;
    public int numberObstacles = 10;
    public float horizontalOffset, verticalOffset;
    public float initialOffset;

    private void Start()
    {
        for (int i = 1; i <= numberObstacles; i++)
        {
            var rdmDist = Random.Range(0, randomDistribuition);
            distanceBetween += rdmDist * i;

            var dist = distanceBetween + initialOffset;
            var pos= pc.path.GetPointAtDistance(dist);
            var rot = pc.path.GetRotationAtDistance(dist);
            var nor = pc.path.GetNormalAtDistance(dist);
            var perp = -Vector3.Cross(nor, pc.path.GetDirectionAtDistance(dist));

            var rdm = Random.Range(-horizontalOffset, horizontalOffset);

            var obj = Instantiate(obstacle, pos + nor * rdm + perp * verticalOffset, rot);
            obj.transform.SetParent(transform);
            obj.transform.rotation = Random.rotation;
        }
    }
    void Update()
    {
        
    }
}
