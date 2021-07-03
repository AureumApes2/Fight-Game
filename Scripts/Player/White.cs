using UnityEngine;

namespace Player
{
    public class White : MonoBehaviour
    {
        public bool grounded;
            public LayerMask groundLayer;
            public Collider2D footCollider;
        
            private void Update()
            {
                Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
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
                        GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1000f);
                        other.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1000f);
                    }
                    else if (other.transform.position.y.Equals(transform.position.y))
                    {
                        
                    }
                    else
                    {
                        GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1000f);
                        other.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1000f);
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
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2 * Input.GetAxis("White Jump"), ForceMode2D.Impulse);
                }
            }
    }
}