using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackcooldown;
    public Transform firepoint;
    public GameObject[] fireballs;

    private Animator anim;
    private PlayerMovement PlayerMovement;
    private float cooldowntimer = Mathf.Infinity;
    void Start()
    {
        anim.GetComponent<Animator>();
        PlayerMovement.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
