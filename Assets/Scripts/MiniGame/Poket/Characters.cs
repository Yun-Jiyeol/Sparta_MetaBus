using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public float Hp;
    public float MaxHp;
    public float AttackDamage;
    public bool isDead = false;

    protected Animator animater;
    protected GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.Instance;
        if (gameManager == null)
        {
            Debug.Log("Manager 없음");
        }
    }
    protected virtual void Start()
    {
        animater = GetComponentInChildren<Animator>();
        if (animater == null)
        {
            Debug.Log("animator가 없습니다.");
        }
    }

    public virtual void takeDamage(float attck)
    {
        Hp -= attck;
        if(Hp <= 0)
        {
            Hp = 0;
            isDead = true;
        }
        animater.SetTrigger("IsDamage");
    }
}
