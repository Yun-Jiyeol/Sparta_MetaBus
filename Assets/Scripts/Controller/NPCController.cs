using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : BaseController
{
    [SerializeField] List<Rect> spawnAreas;
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, 0.3f);

    [SerializeField] Vector2 randomPosition = new Vector2(4.5f, 36.5f); //�ʱⰪ
    Vector2 nextRocation;
    Vector2 nextVector;

    [SerializeField] bool isMove = true;
    [SerializeField] bool isRandomPosition = false;

    protected override void Start()
    {
        GoToRandomPosition(); //������ ���� ��ǥ�� ������ �ǰ�
    }
    protected override void Update()
    {
        base.Update();

        float x = transform.position.x - randomPosition.x;
        float y = transform.position.y - randomPosition.y;

        if (Mathf.Sqrt(x*x + y*y) <= 0.1f) //����� ��
        {
            isMove = false;
            if (isRandomPosition)
            {
                Movement(new Vector2(0, 0));
                isRandomPosition = false; //�Ҵ��� ������
                Invoke("GoToRandomPosition", Random.Range(2,4));
            }
        }
        else
        {
            isMove = true;
        }
    }
    protected override void FixedUpdate()
    {
        if (isMove) //�����δ�
        {
            Movement(nextVector);
        }
    }

    public void GoToRandomPosition()
    {
        isRandomPosition = true; //������������ �Ҵ����

        if (spawnAreas.Count == 0)
        {
            Debug.LogWarning("Spawn Areas�� �������� �ʾҽ��ϴ�.");
            return;
        }

        Rect randomArea = spawnAreas[Random.Range(0, spawnAreas.Count)];
        randomPosition = new Vector2(Random.Range(randomArea.xMin, randomArea.xMax), Random.Range(randomArea.yMin, randomArea.yMax));
        //���� ��ǥ�� ������!
        //1. �̰� �븻�����̼�? �Ѵ�
        //2. �� vector2���� �־ �����̰� �Ѵ�
        //3. �� ���� ��������� ���� �� �ð������� �ٽ� ���� ��ǥ�� ������

        nextRocation = new Vector2(randomPosition.x - transform.position.x, randomPosition.y - transform.position.y);
        nextVector = nextRocation.normalized; //���� ��ǥ������ vector��
    }

    private void OnDrawGizmosSelected()
    {
        if (spawnAreas == null) return;

        Gizmos.color = gizmoColor;
        foreach (var area in spawnAreas)
        {
            Vector3 center = new Vector3(area.x + area.width / 2, area.y + area.height / 2);
            Vector3 size = new Vector3(area.width, area.height);

            Gizmos.DrawCube(center, size);
        }
    }
}
