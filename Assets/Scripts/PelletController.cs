using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletController : MonoBehaviour
{

    private string color = "";
    private float size = 1;
    private float pos;
    private Rigidbody2D rb;


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        pos = transform.position.y;
        setColor(Random.Range(0,6));
        setSize(Random.Range(0.1f, 1f));

    }

    public void setColor(int colorIndex_) {

        switch (colorIndex_) {

            case 0:

                color = "Red";
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);

            break;
            case 1:

                color = "Purple";
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 1);                

            break;
            case 2:

                color = "Blue";
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);

            break;
            case 3:

                color = "Green";
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);

            break;
            case 4:

                color = "Yellow";
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);

            break;
            case 5:

                color = "Orange";
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0);

            break;

        }

    }

    public void setSize(float size_) {

        size = size_;
        transform.localScale = new Vector3(size, size, size);

    }

    void OnTriggerEnter2D(Collider2D collider_) {

        //rb.velocity = Vector2.zero;
        //transform.position = new Vector2(transform.position.x, pos);
        if (collider_.GetComponentInParent<SpinnerController>() != null) {

            collider_.GetComponentInParent<SpinnerController>().collect(color, collider_.gameObject.name, size);

        }
        //setColor(Random.Range(0,6));
        //setSize(Random.Range(0.1f, 2f));
        killOff();

    }

    void killOff() {

        Destroy(gameObject);

    }


}
