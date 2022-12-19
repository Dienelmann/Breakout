using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    /*public float speed = 1f;
    public float yspeed = 1f;
    public float speedMultiplier = 1.5f;
    public float yspeedMultiplier = 1.5f;
    private float startSpeed = 0f;
    
    void Start()
    {
        startSpeed = speed;

    }
    */
    public float speed = 10f;

    private BoxCollider2D myCollider2D;
    
    
    


    private void Awake()
    {
        myCollider2D = GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        
       /* float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float vectorLength = new Vector3(horizontal, vertical, 0).magnitude;

        bool sprint = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * speedMultiplier;
            yspeed = yspeed * yspeedMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = startSpeed;
            yspeed = startSpeed;
        }
        
        if (vectorLength > 1)
        {
            transform.position += new Vector3(horizontal * speed, vertical * yspeed, 0)* Time.deltaTime / vectorLength;
        }
        else
        {
            transform.position += new Vector3(horizontal * speed, vertical * yspeed, 0)* Time.deltaTime;
        }*/
       float horizontal = Input.GetAxisRaw("Horizontal");
        
       transform.position += Vector3.right * (speed * Time.deltaTime * horizontal);

       Vector3 preFrame = Vector3.right * (speed * Time.deltaTime * horizontal);
       
       
       Vector2 colliderSize = new Vector2( transform.localScale.x * myCollider2D.size.x,
           transform.localScale.y * myCollider2D.size.y);

       Vector2 colliderPoint = new Vector2(transform.localScale.x * myCollider2D.offset.x + transform.position.x,
           transform.localScale.y * myCollider2D.offset.y + transform.position.y);


       Collider2D[] colliders = Physics2D.OverlapBoxAll( colliderPoint + (Vector2)preFrame,colliderSize, 0);
        
       foreach (Collider2D othercollider in colliders)
       {
           if (othercollider == myCollider2D) continue;

           Vector3 myboundscenter = myCollider2D.bounds.center;
           Vector3 myboundsmin = myCollider2D.bounds.min;
           Vector3 myboundsmax = myCollider2D.bounds.max;
           Vector3 myboundextents = myCollider2D.bounds.extents;


           float overlapDistanz = (  myboundscenter.x + myboundextents.x - othercollider.bounds.center.x + othercollider.bounds.extents.x);
           
           transform.position += Vector3.right * overlapDistanz;
           /*if (newX > myboundextents - othercollider.bounds.extents)
           {
               newX = myboundextents - othercollider.bounds.extents;
                othercollider.bounds.extents = newX - myboundextents;
           }

           transform.position += Vector3.right * ;*/
           
           print(myboundextents.x);
           print(myboundscenter.x);
           print(othercollider.bounds.extents.x);
           print(othercollider.bounds.center.x);
           print(overlapDistanz);


           print(othercollider);
       }




    }

    
}





