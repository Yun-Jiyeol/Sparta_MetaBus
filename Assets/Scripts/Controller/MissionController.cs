using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    private bool istrigger = false;

    public GameObject minigame; //����� ����� �̴ϰ���

    public GameObject manual; //Ʈ���Ű� �ߵ��� �� �÷��̾�� �Ŵ����� ���δ�

    [SerializeField] private List<GameObject> deleteifSuccess; //�̴ϰ��� ������ ������ ��

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && istrigger)
        {
            Debug.Log("Ʈ���� �ȿ� ����: ");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6) //�÷��̾��� ��
        {
            istrigger = true;
            manual.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //�÷��̾��� ��
        {
            istrigger = false;
            manual.SetActive(false);
        }
    }
}
