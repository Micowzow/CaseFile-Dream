using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NPCPatrol : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;

    private Rigidbody2D rb;
    private Animator anim;

    private Transform currentPoint;
    public float speed;
    public float idleSeconds;
    public SpriteRenderer sprite;

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
         
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
           
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) <0.5f && currentPoint == pointB.transform)
        {
            
            StartCoroutine(IdleNPC());
            flipTrue();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            
            StartCoroutine(IdleNPC());
            flipFalse();
            currentPoint = pointB.transform;
        }
    }

    private void flipTrue()
    {
        sprite.flipX = true;
    }

    private void flipFalse()
    {
        sprite.flipX = false;
    }

    public IEnumerator IdleNPC()
    {
        speed = 0;
        anim.SetBool("isWalking", false);
        yield return new WaitForSeconds(idleSeconds);
        speed = 2;
        anim.SetBool("isWalking", true);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
        
    }
}
