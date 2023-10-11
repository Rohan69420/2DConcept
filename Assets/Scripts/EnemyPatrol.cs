using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private float currentPoint;
    public float speed;
    private bool rightSpeed = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform.position.x;
        //anim.SetBool("isRunning",true);
    }

    // Update is called once per frame
    void Update()
    {
       // currentPoint = transform.position.x;
        if(currentPoint == pointB.transform.position.x){
            rb.velocity = new Vector2(speed, 0);
            rightSpeed = true;
        }
        else
        {
            rb.velocity = new Vector2(-speed,0);
            rightSpeed = false;
        }


        if(Mathf.Abs(currentPoint - transform.position.x) < 0.5f && currentPoint == pointB.transform.position.x)
        {
            currentPoint = pointA.transform.position.x;
        }

          if(Mathf.Abs(currentPoint - transform.position.x) < 0.5f && currentPoint == pointA.transform.position.x)
        {
            currentPoint = pointB.transform.position.x;
        }
    }
    void FixedUpdate(){
        Vector3 localScale = transform.localScale;
    if((rightSpeed && localScale.x>0.0) || (!rightSpeed && localScale.x<0.0)){
        localScale.x *=-1;
        transform.localScale = localScale;
        }

    }
}
