using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

     [SerializeField] List<Waypoint> path = new List<Waypoint>();
     [SerializeField] [Range(0f,10f)]float speed  = 1;

    void Start()
    {
        StartCoroutine(FollowPath());    
    }

    
    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition =  this.transform.position;
            Vector3 endPosition   =  waypoint.transform.position;
            float travelPercent   = 0f;
            transform.LookAt(endPosition);
            while(travelPercent < 1 )
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition,endPosition,travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

    }

}
