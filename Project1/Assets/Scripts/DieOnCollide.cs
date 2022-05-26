using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieOnCollide : MonoBehaviour
{


    public GameObject affectedObject;

    public List<DamageTag> dieTags;

    
    private Health health;
    private Rigidbody2D rb;
    private Animator anim;


    [System.Serializable]
    public class DamageTag
    {
        public string tag;
        public int damage;

    }


    private void Start()
    {

        if(affectedObject == null)
            affectedObject = gameObject;

        health = affectedObject.GetComponent<Health>();
        rb = affectedObject.GetComponent<Rigidbody2D>();
        anim = affectedObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dieTags.Exists( (DamageTag)=> DamageTag.tag == collision.gameObject.tag))
        {
            DamageTag damageTag = dieTags.Find((DamageTag)=> DamageTag.tag == collision.gameObject.tag);
            health.Damage(damageTag.damage);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

}
