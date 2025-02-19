using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSceneChanger : MonoBehaviour
{
    public float Time = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeleteThis", Time);
    }

    void DeleteThis()
    {
        Destroy(gameObject);    
    }
}
