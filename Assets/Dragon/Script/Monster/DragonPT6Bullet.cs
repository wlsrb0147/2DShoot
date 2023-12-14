using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonPT6Bullet : MonoBehaviour
{
    public float speed;
    // Update is called once per frame


    void Update()
    {
        transform.Translate(-speed*Time.deltaTime, 0, 0);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DragonPlayer"))
        {
            Destroy(gameObject);
        }
    }
}
