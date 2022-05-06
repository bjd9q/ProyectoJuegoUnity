
using System;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform objetivo;
    public float movSuave = 0.124f;

    void LateUpdate()
    {
        transform.position = objetivo.position;
    }
}
