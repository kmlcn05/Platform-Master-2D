using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bluebird", menuName = "Enemies/Bluebird")]
public class Bluebird : Enemy
{
    public GameObject projectile;
    private float time;
    public float attacktime;
    public override void DecideWhatToDo(EnemyBehaviour behaviour)
    {
        if (behaviour.Path.Count > 0)
            behaviour.enemy.Move(behaviour);

        time += Time.deltaTime;
        if (time >= attacktime)
        {
            OnAttack(behaviour);
            time = 0;
        }

    }

    public override void Move(EnemyBehaviour behaviour)
    {

        if (Vector3.Distance(behaviour.transform.position, behaviour.Path[0].position) > 0.1f)
        {
            bool moveDirection = behaviour.transform.position.x >= behaviour.Path[0].position.x;

            behaviour.gameObject.GetComponent<SpriteRenderer>().flipX = !moveDirection;

            behaviour.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2)((behaviour.Path[0].position - behaviour.transform.position).normalized * moveSpeed);


        }
        else
        {

            Transform current = behaviour.Path[0];

            behaviour.Path.Reverse();
            behaviour.Path.RemoveAt(behaviour.Path.Count - 1);
            behaviour.Path.Reverse();

            behaviour.Path.Add(current);

        }
    }

    public override void OnAttack()
    {
        throw new System.NotImplementedException();
    }


    public void OnAttack(EnemyBehaviour thisBehaviour)
    {
        GameObject pj = Instantiate(projectile);
        pj.transform.position = thisBehaviour.transform.position;



        ProjectileBehaviour pjBehaviour = pj.GetComponent<ProjectileBehaviour>();
        pjBehaviour.startPoint = thisBehaviour.transform.position;
        pjBehaviour.moveDirection = new Vector2(0, -1);

    }
    
    public override void CollisionEnter2D(EnemyBehaviour behaviour, Collision2D other)
    {

        if (other.gameObject.tag == "Ground")
            behaviour.grounded = true;

    }

    public override void CollisionExit2D(EnemyBehaviour behaviour, Collision2D other)
    {

        if (other.gameObject.tag == "Ground")
            behaviour.grounded = false;

    }

    public override void OnDamaged()
    {
        throw new System.NotImplementedException();
    }

    public override void OnIdle()
    {
        throw new System.NotImplementedException();
    }
}
