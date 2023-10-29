using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Rock : MonoBehaviour
{
    //Elements
    private int fire = 0;
    private int water = 0;
    private int wind = 0;
    private int earth = 0;
    private int wood = 0;

    //Self
    public int rockDamage = 10;
    public LayerMask hitLayers;

    private Collider2D col;
    private int hitCounter = 0;

    //Player 2
    private GameObject player2;
    private Player1Controller player2Controller;

    //Player 1
    private GameObject player1;
    private Collider2D player1Col;
    private Player1HealthSystem player1HealthSystem;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        player2 = GameObject.FindGameObjectWithTag("Player 2");
        player2Controller = player2.GetComponent<Player1Controller>();
        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player1Col = player1.GetComponent<Collider2D>();
        player1HealthSystem = player1.GetComponent<Player1HealthSystem>();

        ElementChecker();
    }

    private void FixedUpdate()
    {
        HitChecker();
    }

    private void HitChecker()
    {
        if (col.IsTouching(player1Col))
        {
            player1HealthSystem.TakeDamage(rockDamage);
            Destroy(gameObject);
        }

        else if (col.IsTouchingLayers(hitLayers))
        {
            hitCounter++;
            if (hitCounter > 1)
            {
                Destroy(gameObject);
            }
        }
    }

    private void ElementChecker()
    {
        //Fire
        if (fire > 0)
        {
            if (fire > 1)
            {

            }

            if (water > 0)
            {

            }

            if (wind > 0)
            {

            }

            if (earth > 0)
            {

            }

            if (wood > 0)
            {

            }
        }

        //Water

        if (water > 0)
        {
            if (water > 1)
            {

            }

            if (wind > 0)
            {

            }

            if (earth > 0)
            {

            }

            if (wood > 0)
            {

            }
        }

        //Wind

        if (wind > 0)
        {
            if (wind > 1)
            {

            }

            if (earth > 0)
            {

            }

            if (wood > 0)
            {

            }
        }

        //Earth

        if (earth > 0)
        {

            if (earth > 1)
            {

            }

            if (wood > 0)
            {

            }
        }

        //Wood

        if (wood > 0)
        {
            if (wood > 1)
            {

            }
        }
    }
}
