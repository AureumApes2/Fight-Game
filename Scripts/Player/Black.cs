using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black : MonoBehaviour
{
    public bool grounded;
    public LayerMask groundLayer;
    public Collider2D footCollider;
    public Transform spawn;
    public Transform enemySpawn;
    
    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal Black"), 0, 0);
        transform.Translate(move * Time.deltaTime * 9f);
        Jump();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        grounded = true;
        if (other.collider.CompareTag("Player"))
        {
            if (other.transform.position.y > transform.position.y)
            {
                other.collider.GetComponent<Player.Player>().points += 1;
                transform.position = spawn.position;
                other.collider.transform.position = enemySpawn.position;
            }
            else if (other.transform.position.y.Equals(transform.position.y))
            {
                
            }
            else
            {
                GetComponent<Player.Player>().points += 1;
                transform.position = spawn.position;
                other.collider.transform.position = enemySpawn.position;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
    }

    void Jump()
    {
        grounded = footCollider.IsTouchingLayers(groundLayer);
        if(grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2 * Input.GetAxis("Black Jump"), ForceMode2D.Impulse);
        }
    }
}
