using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PoketManager : MonoBehaviour
{
    public TextMeshProUGUI InfoText;

    private float MonsterHP = 40;
    private bool canClick = true;

    public Characters Player;
    public Characters Monster;

    MiniGameManager miniGameManager;

    private void Awake()
    {
        miniGameManager = FindObjectOfType<MiniGameManager>();
        if (miniGameManager == null)
        {
            Debug.Log("miniGameManager�� �����ϴ�.");
        }
    }

    private void Start()
    {
        InfoText.text = ""; //�ʱ�ȭ
    }

    public void ClickAttack()
    {
        if (canClick)
        {
            canClick = false;
            PlayerAttack();
            Invoke("CanClick", 6f);
        }
    }
    public void ClickNull()
    {
        if (canClick)
        {
            InfoText.text = "Not Able";
        }
    }
    public void ClickInfo()
    {
        if (canClick)
        {
            WriteInfo();
        }
    }
    public void ClickRun()
    {
        if (canClick)
        {
            canClick = false;
            InfoText.text = "You Run From Fight!";
            Invoke("RunFromFight", 3f);
        }
    }

    void PlayerAttack()
    {
        InfoText.text = $"Player attack Monster!\nGive {Player.AttackDamage} Damage!";
        Monster.takeDamage(Player.AttackDamage);
        if (Monster.isDead)//���� ��� ��
        {
            Invoke("KillMonster", 3f);
        }
        else
        {
            Invoke("MonsterAttack", 3f);
        }
    }
    void KillMonster()
    {
        InfoText.text = $"Player killed Monster!";
        miniGameManager.Success(); //������ ������ ��ü�� ����
        Invoke("RunFromFight", 3f);
    }
    void MonsterAttack()
    {
        InfoText.text = $"Monster attack Player!\nGive {Monster.AttackDamage} Damage!";
        Player.takeDamage(Monster.AttackDamage);
        if (Player.isDead)
        {
            Invoke("PlayerDead", 3f);
        }
    }
    void PlayerDead()
    {
        InfoText.text = "I give you Chance!";
        Player.takeDamage(-1*(Player.MaxHp)); //��Ȱ
        Player.isDead = false;
    }
    void CanClick()
    {
        canClick = true;
    }
    void WriteInfo()
    {
        InfoText.text = "It is Just Skeleton";
    }
    void RunFromFight()
    {
        miniGameManager.EscapeGame();
    }
}
