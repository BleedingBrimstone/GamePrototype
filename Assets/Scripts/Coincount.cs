using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coincount : MonoBehaviour
{
    public static int coin = 0;
    TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        text.text = coin.ToString();
    }
}
