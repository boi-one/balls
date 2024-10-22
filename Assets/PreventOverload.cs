using UnityEngine;

public class PreventOverload : MonoBehaviour
{
    private Rigidbody2D rb;
    private float time;
    public CountDown countDown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

        if(hit)
        {
            Debug.DrawRay(transform.position, transform.right * 12, Color.green);
            time += Time.deltaTime;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.right * 12, Color.red);
            time = 0;
        }
    }

    private void Update()
    {
        Debug.Log(time);

        if (time > 1.1f)
        {
            countDown.startCountdown = true;
        }
        else if(countDown.time > 0)
        {
            countDown.startCountdown = false;
        }

    }
}
