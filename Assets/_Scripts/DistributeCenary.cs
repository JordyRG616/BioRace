using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class DistributeCenary : MonoBehaviour
{
    public GameObject obstacle;
    public PathCreator pc;
    public float distanceBetween = 20;
    public float randomDistribuition;
    public int numberObstacles = 10;
    public Vector2 horizontalOffset;
    public float verticalOffset;

    private void Start()
    {
        for (int i = 1; i <= numberObstacles; i++)
        {
            var rdmDist = Random.Range(0, randomDistribuition);
            distanceBetween += rdmDist;

            var dist = i * distanceBetween;
            var pos = pc.path.GetPointAtDistance(dist);
            var rot = pc.path.GetRotationAtDistance(dist);
            var nor = pc.path.GetNormalAtDistance(dist);

            var rdm = Random.Range(horizontalOffset.x, horizontalOffset.y);
            var sign = Mathf.Sign(Random.Range(-1f, 1f));
            rdm *= sign;

            var obj = Instantiate(obstacle, pos + nor * rdm, Quaternion.identity);
            obj.transform.LookAt(pos);
            obj.transform.SetParent(transform);
            var perp = Vector3.Cross(obj.transform.forward, pc.path.GetDirectionAtDistance(dist));
            obj.transform.position += perp * verticalOffset * sign;
            if(pos.y + obj.transform.position.y < pos.y)
            {
                var scaleY = -obj.transform.localScale.y;
                obj.transform.localScale = new Vector3(obj.transform.localScale.x, scaleY, obj.transform.localScale.z);
            }
        }
    }


    void Update()
    {

    }
}
