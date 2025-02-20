using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Characters
{
    protected override void Start()
    {
        base.Start();
        Hp = 30;
        MaxHp = 30;
        AttackDamage = 10;
    }
    public override void takeDamage(float attck)
    {
        base.takeDamage(attck);
        if (isDead)
        {
            animater.SetBool("IsDead", true);
        }
    }
}
