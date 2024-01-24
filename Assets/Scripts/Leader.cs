using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    float speed = 5f, borderValue = 8f;
    Vector3 target;
    Renderer rend;
    public GameObject leaderBullet;
    AlienFleetController alienFleetController;

    private void Start()
    {
        target = new Vector3(borderValue, 
            transform.position.y, 
            transform.position.z);
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        alienFleetController = GameObject.FindGameObjectWithTag("alienFleet")
            .GetComponent<AlienFleetController>();
    }
    private void Update()
    {
        if(alienFleetController.isGameRunning)
            Move();
    }
    private void Move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        if(Vector3.Distance(transform.position, target) < 0.0001f)
        {
            target = new Vector3(target.x * -1,
                transform.position.y,
                transform.position.z);
        }
    }
    private void Shoot()
    {
        Vector3 pos = transform.position - Vector3.up;
        Instantiate(leaderBullet, pos, Quaternion.identity);
    }
    private void ToggleVisible()
    {
        rend.enabled = !rend.enabled;
    }
    public void StartLeader()
    {
        Invoke("ToggleVisible", 10);
        InvokeRepeating("Shoot", 11, 4);
    }
    public void StopLeader()
    {
        CancelInvoke("Shoot");
    }
}
