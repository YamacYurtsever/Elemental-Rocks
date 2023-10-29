using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float player2Speed = 3f;
    public float rockSpeed = 10f;
    public float shotCooldown = 1f;
    public GameObject player2Rock;
    public Animator player2Animator;

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
        move.x = Input.GetAxis("LeftJoystickHorizontal2") * player2Speed;
        move.y = -Input.GetAxis("LeftJoystickVertical2") * player2Speed;
        rb.velocity = move;
    }

    private void Rotate()
    {
        if (Input.GetAxis("RightJoystickVertical2") > 0.1)
        {
            transform.localScale = new Vector3(1, startYScale, 1);
            rotationZ = Input.GetAxis("RightJoystickHorizontal2") * 90f;
        }
        else if (Input.GetAxis("RightJoystickVertical2") < -0.1)
        {
            transform.localScale = new Vector3(1, -startYScale, 1);
            rotationZ = Input.GetAxis("RightJoystickHorizontal2") * -90f;
        }
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    private void Shoot()
    {
        shoot1 = Input.GetAxisRaw("LT2");
        shoot2 = Input.GetAxisRaw("RT2");
        if (shoot1 < 0 || shoot2 > 0)
        {
            if (Time.time > shotTimer + shotCooldown)
            {
                Vector2 direction = new Vector2(Input.GetAxis("RightJoystickHorizontal2"), -Input.GetAxis("RightJoystickVertical2"));

                if (direction.magnitude >= -0.1 && direction.magnitude <= 0.1)
                {
                    sideChecker = Physics2D.OverlapPoint(new Vector2(transform.position.x, transform.position.y - 1));
                    if (!sideChecker)
                    {
                        GameObject rock = Instantiate(player2Rock, new Vector2(transform.position.x, transform.position.y - transform.localScale.y), gameObject.transform.rotation);
                        rock.GetComponent<Rigidbody2D>().velocity = new Vector2(0, rockSpeed * -transform.localScale.y);
                        player2Animator.SetTrigger("Shoot");
                        shotTimer = Time.time;
                    }
                }
                else
                {
                    sideChecker = Physics2D.OverlapPoint(new Vector2(transform.position.x + direction.normalized.x, transform.position.y + direction.normalized.y));
                    if(!sideChecker)
                    {
                        GameObject rock = Instantiate(player2Rock, new Vector2(transform.position.x + direction.normalized.x, transform.position.y + direction.normalized.y), gameObject.transform.rotation);
                        rock.GetComponent<Rigidbody2D>().velocity = new Vector2(rockSpeed * direction.normalized.x, rockSpeed * direction.normalized.y);
                        player2Animator.SetTrigger("Shoot");
                        shotTimer = Time.time;
                    }
                }
            }
        }
    }
}