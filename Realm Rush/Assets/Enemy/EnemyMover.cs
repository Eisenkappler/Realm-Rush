using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

     [SerializeField] List<Waypoint> path = new List<Waypoint>();
     [SerializeField] [Range(0f,10f)]float speed  = 1;
    
    Enemy enemy;

    private void Start() {
        enemy = GetComponent<Enemy>();
    }
    private void OnEnable() 
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());    
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
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
        //we are now at the end of the Path (at the Bank)
        gameObject.SetActive(false);
        enemy.StealGold();

    }

}
