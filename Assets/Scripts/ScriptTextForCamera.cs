using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTextForCamera : MonoBehaviour
{
    private Transform textMesh;

    private void Awake()
    {
        textMesh = GetComponent<Transform>();
    }
    void Update()
    {
        textMesh.transform.LookAt(Camera.main.transform);
    }
}
