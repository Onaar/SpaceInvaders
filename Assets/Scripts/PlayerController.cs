using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f, fireRate = 1f;
    float timeFromLastShoot = 0f;
    public GameObject bullet;

    private void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float speedDir = x * speed * Time.deltaTime;
        transform.position += new Vector3(speedDir, 0f, 0f);
    }
    private void Shoot()
    {
        timeFromLastShoot += Time.deltaTime;
        bool isTimeSatisfied = timeFromLastShoot >= (1f / fireRate), 
            isSpacePressedDown = Input.GetKey(KeyCode.Space);
        if (isTimeSatisfied && isSpacePressedDown)
        {
            Vector3 bulletPos = transform.position + Vector3.up;
            Instantiate(bullet, bulletPos, Quaternion.identity);
            timeFromLastShoot = 0f;
        }
    }
}
