using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Health : MonoBehaviour
{
    
    [SerializeField]
    private int _health;
    public int health { get { return _health; } }

    private Animator animator;

    public event Damaged OnDie;
    public event Damaged OnDamaged;
    public delegate void Damaged();

    
    private void Start()
    {

        animator = GetComponent<Animator>();

    }

    public void Heal(int amount)
    {
        _health += amount;
    }

    public void Damage(int amount)
    {

        _health -= amount;

        if(_health <= 0)
        {
            
            animator.SetTrigger("Die");
            OnDie?.Invoke();

        }
        else
        {

            animator.SetTrigger("Damaged");
            OnDamaged?.Invoke();

        }

    }

}
