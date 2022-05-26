using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileBehaviour : MonoBehaviour
{

    public Projectile projectile;

    public Vector2 startPoint;
    public Vector2 moveDirection;

    private Rigidbody2D rgdb2D;
    public void Init()
    {


    }
    
    void Start()
    {
        
        rgdb2D = GetComponent<Rigidbody2D>();

        startPoint = (Vector2)transform.position;


    }

    
    void Update()
    {
        
        if(Vector2.Distance(startPoint, (Vector2)transform.position) < projectile.range)
        {

            rgdb2D.velocity = moveDirection * projectile.speed;

        }
        else
        {

            Boom();

        }
        

    }

    public void Boom()
    {

        Destroy(gameObject);

    }

}
