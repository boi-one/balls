using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    public bool startCountdown = false;

    public float time = 1;
    float currentTime = 1;

    [HideInInspector] public TMP_Text countUI; 
    int count = 5;

    private void SetTime()
    {
        countUI = GetComponent<TMP_Text>();
        countUI.text = count.ToString();
        Debug.Log("balls");
    }

    private void Awake()
    {
        SetTime();
    }

    void Update()
    {
        if (!startCountdown && count > 0) return;

        Debug.Log("lol");

        if(Time.time > currentTime)
        {
            count--;
            countUI.text = count.ToString();

            currentTime = Time.time + time; 
        }

        if(count == 0)
        {
            startCountdown = false;
        }
    }
}
