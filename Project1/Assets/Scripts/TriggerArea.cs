using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{

    public List<string> tags;
    public UnityEvent<Collider2D> onTriggerEnter;
    public UnityEvent<Collider2D> onTriggerStay;
    public UnityEvent<Collider2D> onTriggerExit;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (tags.Contains(collision.tag))
            onTriggerEnter.Invoke(collision);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (tags.Contains(collision.tag))
            onTriggerStay.Invoke(collision);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (tags.Contains(collision.tag))
            onTriggerExit.Invoke(collision);
    }
}
