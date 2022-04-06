using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [HideInInspector]
    public float speed=2f;
    public List<Transform> point;
    public int nextID=0;
    public int idChangeValue=1;
    private Rigidbody2D myBody;
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNextPoint();
    }
    void MoveToNextPoint()
    {
        Transform goalPoint = point[nextID];
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-4, 4, 4);
        else transform.localScale = new Vector3(4, 4, 4);
        transform.position = Vector2.MoveTowards(transform.position,goalPoint.position,speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            if (nextID == point.Count - 1)
                idChangeValue = -1;
            if (nextID == 0)
                idChangeValue = 1;
            nextID += idChangeValue;
        }
           
    }
}
