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
            Debug.Log("Manager ����");
        }
    }
    protected virtual void Start()
    {
        animater = GetComponentInChildren<Animator>();
        if (animater == null)
        {
            Debug.Log("animator�� �����ϴ�.");
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
