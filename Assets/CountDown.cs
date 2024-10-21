using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    public static bool startCountdown = false;

    float time = 1;
    float currentTime = 1;

    [HideInInspector] public TextMeshPro countUI; 
    int count = 5;

    private void Awake()
    {
        countUI = GetComponent<TextMeshPro>();
        countUI.text = count.ToString();
    }

    void Update()
    {
        countUI.gameObject.SetActive(false);

        if (!startCountdown && count > 0) return;

        countUI.gameObject.SetActive(true);

        if(Time.time > currentTime)
        {
            count--;
            countUI.text = count.ToString();

            currentTime = Time.time + time; 
        }
    }
}
