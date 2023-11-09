using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform CurrentPoint;
    public float speed;
    private float FlipDelay = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        CurrentPoint = point2.transform;
        anim.SetBool("IsRunning", true);
        StartCoroutine(MoveBetweenPoints());
    }

    // Update is called once per frame
    private IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            Vector2 direction = (CurrentPoint.position - transform.position).normalized;

            if (CurrentPoint == point2.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }

            if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == point2.transform)
            {

                flip();
                anim.SetBool("IsIdle", true);
                anim.SetBool("IsRunning", false);
                yield return new WaitForSeconds(FlipDelay);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsRunning", true);
                CurrentPoint = point1.transform;
            }
            if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == point1.transform)
            {
                flip();
                anim.SetBool("IsIdle", true);
                anim.SetBool("IsRunning", false);
                yield return new WaitForSeconds(FlipDelay);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsRunning", true);
                CurrentPoint = point2.transform;
            }

            yield return null;
        }

        void flip()
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }


    }

}