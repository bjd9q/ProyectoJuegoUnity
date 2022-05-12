using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour
{
    public Transform target;
    public float SSpeed;
    public Vector3 PCamera;

    private void FixedUpdate(){

        Vector3 Dposition = target.position + PCamera;
        Vector3 Sposition = Vector3.Lerp( transform.position, Dposition , SSpeed * Time.deltaTime);
        transform.position = Sposition;
    }

}
