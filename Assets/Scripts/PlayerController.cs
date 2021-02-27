using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool salto = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-250f * Time.deltaTime, 0));

        }

        if (Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(250f * Time.deltaTime, 0));

        }

        if (Input.GetKeyDown("up") && salto )
        {
            salto = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.transform.tag == "piso")
        {
            salto = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("moneda"))
        {
            collision.gameObject.SetActive(false);
        }

       if (collision.gameObject.CompareTag("agua"))
        {
            salto = false;
        }
    }

}
