using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Characters
{
    public Slider PlayerHPBar;
    
    protected override void Start()
    {
        base.Start();
        Hp = gameManager.PlayerHP;
        MaxHp = gameManager.PlayerMaxHP;
        AttackDamage = gameManager.PlayerAttack;
    }
    private void Update()
    {
        PlayerHPBar.value = Hp / MaxHp;
        gameManager.PlayerHP = Hp;
    }
    public override void takeDamage(float attck)
    {
        base.takeDamage(attck);
    }
}
