using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : ScriptableObject
{

    
    public GameObject prefab;

    public float moveSpeed;

    public abstract void OnDamaged();

    public abstract void OnAttack();

    public abstract void OnIdle();

    public abstract void DecideWhatToDo(EnemyBehaviour behaviour);

    public abstract void Move(EnemyBehaviour behaviour);

    public abstract void CollisionEnter2D(EnemyBehaviour behaviour, Collision2D other);

    public abstract void CollisionExit2D(EnemyBehaviour behaviour, Collision2D other);

}
