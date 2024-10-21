using UnityEngine;

public class PreventOverload : MonoBehaviour
{
    Rigidbody2D rb;
    float time;

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
        if (time < 1.1f)
        {
            CountDown.startCountdown = true;
        }
        else
            CountDown.startCountdown = false;

    }
}
