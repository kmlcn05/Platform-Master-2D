using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class EnemyBehaviour : MonoBehaviour
{
    
    public Enemy enemy;
    
    public bool grounded;

    private List<Transform> path;
    public List<Transform> Path { get { return path; } }

    public Transform pathTransform;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rgdbody2D;
    private Health health;

    public virtual void Start() 
    {
    
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rgdbody2D = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();


        if(path == null || path.Count == 0)
        {

            path = new List<Transform>();


            path.AddRange(pathTransform.GetComponentsInChildren<Transform>());
            path.Remove(pathTransform);
        
        }

    }

    public virtual void Update()
    {

        enemy.DecideWhatToDo(this);

    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        enemy.CollisionEnter2D(this, other);
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        enemy.CollisionExit2D(this, other);
    }





    public void Damaged()
    {

        enemy.OnDamaged();

    }

    public void Attack()
    {
        enemy.OnAttack();
    }

    public void Idle()
    {
        enemy.OnIdle();
    }

    public virtual void StaticMe()
    {
        rgdbody2D.bodyType = RigidbodyType2D.Static;
        Destroy(GetComponent<Collider2D>());
        gameObject.tag = "Untagged";
    }

    public virtual void DestroyMe()
    {

        Destroy(gameObject);

    }

}
