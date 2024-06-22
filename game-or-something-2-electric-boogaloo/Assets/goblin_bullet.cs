
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class goblin_bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bullet_speed;
    public int bullet_damage;

    [SerializeField] private GameObject player;



    private Health_system Health;


    private player_movement Movement;

    private Vector2 direction;

    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        rb = gameObject.GetComponent<Rigidbody2D>();

        Health = player.GetComponent<Health_system>();

        Movement = player.GetComponent<player_movement>();

    }
     void Start()
    {
        direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void FixedUpdate()
    {
        rb.transform.Translate(Vector2.right * Time.deltaTime * bullet_speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((Movement.isDashing && collision.collider.tag == "Player") || collision.collider.tag == "Player Bullets" || collision.collider.tag == "Enemy" || collision.collider.tag == "Enemy Attacks")
        {
            //Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
            return;
        }

        if (collision.collider.tag == "Player")
        {
            Health = collision.collider.GetComponent<Health_system>();
            Health.TakeDamagePlayer(bullet_damage);


        }




        Destroy(gameObject);


    }






}