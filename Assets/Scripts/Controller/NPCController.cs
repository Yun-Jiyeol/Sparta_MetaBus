using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : BaseController
{
    [SerializeField] List<Rect> spawnAreas;
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, 0.3f);

    [SerializeField] Vector2 randomPosition = new Vector2(4.5f, 36.5f); //초기값
    Vector2 nextRocation;
    Vector2 nextVector;

    [SerializeField] bool isMove = true;
    [SerializeField] bool isRandomPosition = false;

    protected override void Start()
    {
        GoToRandomPosition(); //생성시 랜덤 좌표를 가지게 되고
    }
    protected override void Update()
    {
        base.Update();

        float x = transform.position.x - randomPosition.x;
        float y = transform.position.y - randomPosition.y;

        if (Mathf.Sqrt(x*x + y*y) <= 0.1f) //가까울 시
        {
            isMove = false;
            if (isRandomPosition)
            {
                Movement(new Vector2(0, 0));
                isRandomPosition = false; //할당을 못받음
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
        if (isMove) //움직인다
        {
            Movement(nextVector);
        }
    }

    public void GoToRandomPosition()
    {
        isRandomPosition = true; //랜덤포지션을 할당받음

        if (spawnAreas.Count == 0)
        {
            Debug.LogWarning("Spawn Areas가 설정되지 않았습니다.");
            return;
        }

        Rect randomArea = spawnAreas[Random.Range(0, spawnAreas.Count)];
        randomPosition = new Vector2(Random.Range(randomArea.xMin, randomArea.xMax), Random.Range(randomArea.yMin, randomArea.yMax));
        //랜덤 좌표를 가졌다!
        //1. 이걸 노말리제이션? 한다
        //2. 그 vector2값을 넣어서 움직이게 한다
        //3. 그 값에 가까워지면 정지 후 시간지나서 다시 랜덤 좌표를 가진다

        nextRocation = new Vector2(randomPosition.x - transform.position.x, randomPosition.y - transform.position.y);
        nextVector = nextRocation.normalized; //다음 좌표까지의 vector값
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
