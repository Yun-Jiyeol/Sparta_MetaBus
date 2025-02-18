using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    private bool istrigger = false;
    private bool isClear = false; //�̴ϰ����� �����ߴ°�

    public GameObject minigame; //����� ����� �̴ϰ���

    public GameObject manual; //Ʈ���Ű� �ߵ��� �� �÷��̾�� �Ŵ����� ���δ�

    [SerializeField] private List<GameObject> deleteifSuccess; //�̴ϰ��� ������ ������ ��

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && istrigger)
        {
            Instantiate(minigame);
        }
    }

    public void IsSuccess() //�̴ϰ��� ������ �ҷ��´�
    {
        foreach (GameObject i in deleteifSuccess) //���� �� ����
        {
            Destroy(i);
        }
        isClear = true;
        istrigger = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6 && !isClear) //�÷��̾��� ��
        {
            istrigger = true;
            manual.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && !isClear) //�÷��̾��� ��
        {
            istrigger = false;
            manual.SetActive(false);
        }
    }
}
