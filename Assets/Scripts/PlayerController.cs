using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 8f;
    public float jumpSpeed = 7f;

    Rigidbody rg;


    // Start is called before the first frame update
    void Start()
    {

        rg = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        WalkHandler();
        JumpHandler();

    }

    void WalkHandler()
    {

        rg.velocity = new Vector3(0, rg.velocity.y, 0);

        float distance = walkSpeed * Time.deltaTime;

        /* x */
        float hAxis = Input.GetAxis("Horizontal");

        /* y */
        float vAxis = Input.GetAxis("Vertical");

        /* movimento */
        Vector3 movement = new Vector3(hAxis * distance, 0f, vAxis * distance);

        /* posicao atual */
        Vector3 currPosition = transform.position;

        /* nova posição */
        Vector3 newPosition = currPosition + movement;

        rg.MovePosition(newPosition);

    }

    void JumpHandler()
    {

        float jAxis = Input.GetAxis("Jump");

        if(jAxis > 0f)
        {

            Vector3 jumpVector = new Vector3(0f, jumpSpeed, 0f);
            rg.velocity = rg.velocity + jumpVector;

        }

    }

}
