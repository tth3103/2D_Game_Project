using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [HideInInspector]
    public float speed = 2f;
    public List<Transform> point;
    public int nextID = 0;
    public int idChangeValue = 1;
    private Rigidbody2D myBody;
    
    // Update is called once per frame
    void Update()
    {
        MovetoNextPoint();
    }
    public void MovetoNextPoint()
    {
        Transform goalPoint = point[nextID];
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            if (nextID == point.Count - 1)
                idChangeValue = -1;
            if (nextID == 0)
                idChangeValue = 1;
            nextID += idChangeValue;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(gameObject.transform, true);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
