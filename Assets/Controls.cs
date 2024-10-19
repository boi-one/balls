using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject ball;
    public Transform dropCursor;
    public Transform leftWall;
    public Transform rightWall;
    public GameObject currentBall;

    public static int[] ballQueueLevel = new int[2];

    GameObject CreateBall()
    {
        GameObject newBall = Instantiate(ball);
        newBall.GetComponent<Ball>().levelIndicator = ballQueueLevel[0];
        newBall.GetComponent<Ball>().SetLevelAttributes();
        newBall.GetComponent<Rigidbody2D>().simulated = false;
        return newBall;
    }

    void ForwardQueue()
    {
        for (int i = 1; i < ballQueueLevel.Length; i++)
        {
            if (i < ballQueueLevel.Length)
            {
                ballQueueLevel[i - 1] = ballQueueLevel[i];
            }
        }
        ballQueueLevel[ballQueueLevel.Length - 1] = Random.Range(0, 6);
    }

    void Start()
    {
        currentBall = CreateBall();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x > leftWall.position.x + leftWall.transform.localScale.x && 
            mousePosition.x < rightWall.position.x - leftWall.transform.localScale.x)
        {
            dropCursor.position = new Vector3(mousePosition.x, dropCursor.position.y);
            if (!currentBall.GetComponent<Ball>().dropped)
                currentBall.transform.position = dropCursor.position;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentBall.GetComponent<Rigidbody2D>().simulated = true;
            currentBall.GetComponent<Ball>().dropped = true;
            currentBall = CreateBall();
            ForwardQueue();
        }
    }
}
