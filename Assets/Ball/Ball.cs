using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static List<GameObject> allBalls = new List<GameObject>();
    public List<Sprite> ballSprites = new List<Sprite>();

    public struct level
    {
        public float radius;
        public Color color;

        public level(float radius, Color color)
        {
            this.radius = radius;
            this.color = color;
        }
    }

    public static List<level> levels = new List<level>()
    {
        new level(0.5f, Color.red),
        new level(0.8f, Color.green),
        new level(1.2f, Color.blue),
        new level(1.5f, Color.cyan),
        new level(1.9f, Color.magenta),
        new level(3.0f, Color.yellow),
        new level(3.5f, Color.white),
        new level(4.0f, Color.black),
        new level(4.5f, new Color(100, 200, 100)),
        new level(5.0f, new Color(255, 0, 100)),
        new level(7.0f, new Color(255, 100, 150))
    };

    public level currentLevel = levels[0];
    public int levelIndicator = 0;
    public bool dropped = false;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void UpLevel()
    {
        if (levelIndicator < levels.Count) levelIndicator++;
        currentLevel = levels[levelIndicator];
    }

    public void SetLevelAttributes()
    {
        currentLevel = levels[levelIndicator];
        transform.localScale = new Vector3(currentLevel.radius, currentLevel.radius, 1);
        gameObject.GetComponent<SpriteRenderer>().sprite = ballSprites[levelIndicator];
        //gameObject.GetComponent<SpriteRenderer>().color = currentLevel.color;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.TryGetComponent(out Ball otherBall)) return;

        /* && rb.simulated && otherBall.rb.simulated) //improved by the doctor*/

        if (otherBall.levelIndicator == this.levelIndicator)
        {
            UpLevel();
            SetLevelAttributes();
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (!other.gameObject.TryGetComponent(out Ball otherBall)) return;

        if (otherBall.levelIndicator == this.levelIndicator)
        {
            UpLevel();
            SetLevelAttributes();
            Destroy(other.gameObject);
        }
    }
}
