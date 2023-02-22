using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerController : MonoBehaviour
{

    public AudioSource woosh;
    public AudioSource hit;
    public AudioSource miss;
    public AudioSource pass;

    private float lerpSpeed = 0.1f;
    private float[,] rewards = {
        {1,0,-1,-2,-1,0},
        {0,1,0,-1,-2,-1},
        {-1,0,1,0,-1,-2},
        {-2,-1,0,1,0,-1},
        {-1,-2,-1,0,1,0},
        {0,-1,-2,-1,0,1},
    }; 

    private int targetRotation = 0;
    private Rigidbody2D rb;


    public void turnRight() {

        rotate(-60);

    }

    public void turnLeft() {

        rotate(60);

    }

    void rotate(int rotationAmount_) {

        targetRotation += rotationAmount_;
        targetRotation %= 360;
        if (targetRotation < 0) {

            targetRotation += 360;

        }
        woosh.Play();

    }

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, lerpSpeed));

    }

    public void collect(string pelletColor_, string sideColor_, float size_) {

        float score = 0;
        score = rewards[getColorindex(pelletColor_), getColorindex(sideColor_)] * size_;
        if (score < 0) {

            miss.Play();
            Camera.main.GetComponent<GameController>().registerMiss();

        }
        else if (score > 0) {

            hit.Play();
            Camera.main.GetComponent<GameController>().registerHit();

        }
        else {

            pass.Play();

        }

    }

    private int getColorindex(string color_) {

        switch(color_){

            case "Red":

                return 0;

            break;
            case "Purple":

                return 1;

            break;
            case "Blue":

                return 2;

            break;
            case "Green":

                return 3;

            break;
            case "Yellow":

                return 4;

            break;
            case "Orange":

                return 5;

            break;
            default:

                return -1;

            break;
            

        }

    }

}
