using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text conteo;
    public Text win;
    private int punto;

    bool salto = true;
    // Start is called before the first frame update
    void Start()
    {
        punto = 0;
        SetCountText();
        win.text = "";
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
            punto = punto + 1;
            SetCountText();
        }

       if (collision.gameObject.CompareTag("agua"))
        {
            salto = false;
        }
    }

    void SetCountText()
    {
        conteo.text = "Puntos: " + punto.ToString();
        if(punto >= 5)
        {
            win.text = "GANASTE";
        }
    }

}
