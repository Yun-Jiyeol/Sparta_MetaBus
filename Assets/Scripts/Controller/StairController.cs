using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class StairController : MonoBehaviour
{
    private bool istrigger = false;

    public GameObject SceneChanger;
    public GameObject manual;
    public GameObject OpenMap; //���� ��
    public GameObject CloseMap; //���� ��
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && istrigger)
        {
            //ȭ�鰡���� �¿���
            //1���Ĵ����� ������ �̹��� ����
            Instantiate(SceneChanger,this.transform);
            Invoke("ChangeMap", 1f);
        }
    }

    void ChangeMap()
    {
        OpenMap.SetActive(true);
        Destroy(CloseMap);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //�÷��̾��� ��
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
