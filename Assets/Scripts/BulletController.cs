using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        //Vector3.up => new Vector3(0f,1f,0f)
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Alien" || collision.tag == "LeaderBullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}