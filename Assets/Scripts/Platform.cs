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

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
    }
}
