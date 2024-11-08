using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Heart playerHealth;
    public Image hp_totalbr;
    public Image hp_currentbr;
    // Start is called before the first frame update
    void Start()
    {
        hp_totalbr.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        hp_currentbr.fillAmount = playerHealth.currentHealth / 10;
    }
}
