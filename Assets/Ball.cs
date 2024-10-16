using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    struct level
    {
        public float radius;
        public Color color;
     
        public level(float radius, Color color)
        {
            this.radius = radius;
            this.color = color;
        }
    }

    private List<level> levels = new List<level>()
    {
        new level(0.5f, Color.red),
        new level(1.0f, Color.green),
        new level(1.5f, Color.blue),
        new level(2.0f, Color.cyan),
        new level(2.5f, Color.magenta),
        new level(3.0f, Color.yellow),
        new level(3.5f, Color.white),
        new level(4.0f, Color.black),
        new level(4.5f, new Color(100, 200, 100)),
        new level(5.0f, new Color(255, 0, 100))
    };

    private level currentLevel;
    private int levelIndicator = -1;

    private void UpLevel()
    {
        if(levelIndicator < levels.Count) levelIndicator++;
        currentLevel = levels[levelIndicator];
    }
    
    // Start is called before the first frame update
    void Start()
    {
        UpLevel();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(currentLevel.radius, currentLevel.radius, 1);
        gameObject.GetComponent<SpriteRenderer>().color = currentLevel.color;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.TryGetComponent(out Ball otherBall)) return;
        
        if (otherBall.levelIndicator == this.levelIndicator)
        {
            UpLevel();
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (!other.gameObject.TryGetComponent(out Ball otherBall)) return;
        
        if (otherBall.levelIndicator == this.levelIndicator)
        {
            UpLevel();
            Destroy(other.gameObject);
        }
    }
}
