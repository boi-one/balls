using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject ball;
    public Transform dropCursor;
    public Transform leftWall;
    public Transform rightWall;
    private GameObject currentBall;

    public float cooldown = 1.0f;
    private float cooldownCurrentTime = 0.0f;

    public static int[] ballQueueLevel = new int[2];

    GameObject CreateBall()
    {
        Ball.allBalls.Add(Instantiate(ball));
        Ball.allBalls[Ball.allBalls.Count - 1].transform.position = dropCursor.position;
        GameObject lastBall = Ball.allBalls[Ball.allBalls.Count - 1];
        lastBall.GetComponent<Ball>().levelIndicator = ballQueueLevel[0];
        lastBall.GetComponent<Ball>().SetLevelAttributes();
        lastBall.GetComponent<Rigidbody2D>().simulated = false;
        return Ball.allBalls[Ball.allBalls.Count - 1];
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
        ballQueueLevel[ballQueueLevel.Length - 1] = Random.Range(0, 5);
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > cooldownCurrentTime)
        {
            cooldownCurrentTime = Time.time + cooldown;
            GameObject lastBall = Ball.allBalls[Ball.allBalls.Count - 1];
            lastBall.GetComponent<Rigidbody2D>().simulated = true;
            lastBall.GetComponent<Ball>().dropped = true;
            ForwardQueue();
            currentBall = CreateBall();
        }
    }
}
