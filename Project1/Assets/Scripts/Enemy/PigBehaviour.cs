using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigBehaviour : EnemyBehaviour
{

    public Pig pig { get { return enemy as Pig; } set { enemy = value; } }

    private float time = 0;
    private bool cded = false;

    public override void Start()
    {
        FixPig();
        RefreshPig();

        base.Start();
    }

    public override void Update()
    {
        
        if(cded)
            time += Time.deltaTime;

        if(time >= pig.cooldown)
            RefreshPig();

        base.Update();
    }

    public void TriggerPig(Collider2D collider2D)
    {

        if(cded)
            return;

        time = 0;
        cded = true;

        Vector2 ChargePosition = new Vector2(collider2D.transform.position.x, transform.position.y);

        pig.chargePosition = ChargePosition;
        pig.charging = true;

        pig.OnChargeArrive += FixPig;

        GetComponent<Animator>().SetTrigger("Charge");

        // GetComponent<Animator>().SetBool("ChargeBool", true);

    }

    public void RefreshPig()
    {
        pig.charging = false;
        time = 0;
        cded = false;
    }

    public void FixPig()
    {
        time = 0;
        cded = true;
        GetComponent<Animator>().ResetTrigger("Charge");
        GetComponent<Animator>().Play("PigIdle");

        pig.OnChargeArrive -= FixPig;
        // pig.OnChargeArrive -= FixPig;
    }

    public override void StaticMe()
    {
        base.StaticMe();
    }

    public override void DestroyMe()
    {
        pig.charging = false;
        base.DestroyMe();
    }


}
