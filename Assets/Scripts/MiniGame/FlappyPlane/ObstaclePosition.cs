using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePosition : MonoBehaviour
{
     float highPosY = 0.6f;
     float lowPosY = -0.6f;

     float holeSizeMin = 1.2f;
     float holeSizeMax = 1.5f;

    public Transform topObject;
    public Transform bottomObject;

    private void Start()
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        Vector3 placePosition = new Vector3(0, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        topObject.localPosition = new Vector3(0, placePosition.y+ halfHoleSize);
        bottomObject.localPosition = new Vector3(0, placePosition.y - halfHoleSize);
    }
}
