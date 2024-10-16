using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Controls : MonoBehaviour
{
    public GameObject ball;
    public GameObject ballSpawn;
    public Transform leftWall;
    public Transform rightWall;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x > leftWall.position.x + leftWall.transform.localScale.x && 
            mousePosition.x < rightWall.position.x - leftWall.transform.localScale.x)
        {
            ballSpawn.transform.position = new Vector3(mousePosition.x, ballSpawn.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject ballInstance = Instantiate(ball);
            ballInstance.transform.position = new Vector3(ballSpawn.transform.position.x, ballSpawn.transform.position.y, ballInstance.transform.position.z);
        }
    }
}
