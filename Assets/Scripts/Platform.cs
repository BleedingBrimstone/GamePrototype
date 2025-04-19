using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public float speed;
    private Transform target;


    void Start()
    {
        target = pos2;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == pos2) ? pos1 : pos2;
        }
    }
}
