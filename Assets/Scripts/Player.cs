using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{

    private float speed = 6f;

    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;

    private Vector3 currentMovement = Vector3.zero;
    private InputReader input;

    public void Start()
    {
        input = InputReader.Instance;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {

        Vector3 horizontalMovement = new Vector3(input.MoveInput.x, input.MoveInput.y, 0);
        
        currentMovement.x = horizontalMovement.x * speed;
        currentMovement.y = horizontalMovement.y * speed;

        transform.Translate(currentMovement * Time.deltaTime);

        // Loops the player back on screen (Default)
        /*
         * if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
        */

    }

}
