using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float player1Speed = 3f;
    public float rockSpeed = 10f;
    public float shotCooldown = 1f;
    public GameObject player1Rock;
    public Animator player1Animator;

    private float shoot1, shoot2;
    private Rigidbody2D rb;
    private float rotationZ;
    private float shotTimer = 0f;
    private float startYScale;
    private Collider2D sideChecker; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startYScale = transform.localScale.y;
    }

    private void Update()
    {
        Move();

        Rotate();

        Shoot();
    }

    private void Move()
    {
        Vector2 move;
        move.x = Input.GetAxis("LeftJoystickHorizontal1") * player1Speed;
        move.y = -Input.GetAxis("LeftJoystickVertical1") * player1Speed;
        rb.velocity = move;
    }

    private void Rotate()
    {
        if (Input.GetAxis("RightJoystickVertical1") > 0)
        {
            transform.localScale = new Vector3(1, -startYScale, 1);
            rotationZ = Input.GetAxis("RightJoystickHorizontal1") * 90f;
        }
        else if (Input.GetAxis("RightJoystickVertical1") < 0)
        {
            transform.localScale = new Vector3(1, startYScale, 1);
            rotationZ = Input.GetAxis("RightJoystickHorizontal1") * -90f;
        }
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    private void Shoot()
    {
        shoot1 = Input.GetAxisRaw("LT1");
        shoot2 = Input.GetAxisRaw("RT1");
        if (shoot1 < 0 || shoot2 > 0)
        {
            if (Time.time > shotTimer + shotCooldown)
            {
                Vector2 direction = new Vector2(Input.GetAxis("RightJoystickHorizontal1"), -Input.GetAxis("RightJoystickVertical1"));

                if (direction.magnitude >= -0.1 && direction.magnitude <= 0.1)
                {
                    sideChecker = Physics2D.OverlapPoint(new Vector2(transform.position.x, transform.position.y - transform.localScale.y));
                    if (!sideChecker)
                    {
                        GameObject rock = Instantiate(player1Rock, new Vector2(transform.position.x, transform.position.y + 1), gameObject.transform.rotation);
                        rock.GetComponent<Rigidbody2D>().velocity = new Vector2(0, rockSpeed * -transform.localScale.y);
                        player1Animator.SetTrigger("Shoot");
                        shotTimer = Time.time;
                    }
                }
                else
                {
                    sideChecker = Physics2D.OverlapPoint(new Vector2(transform.position.x + direction.normalized.x, transform.position.y + direction.normalized.y));
                    if(!sideChecker)
                    {
                        GameObject rock = Instantiate(player1Rock, new Vector2(transform.position.x + direction.normalized.x, transform.position.y + direction.normalized.y), gameObject.transform.rotation);
                        rock.GetComponent<Rigidbody2D>().velocity = new Vector2(rockSpeed * direction.normalized.x, rockSpeed * direction.normalized.y);
                        player1Animator.SetTrigger("Shoot");
                        shotTimer = Time.time;
                    }
                }
            }
        }
    }
}