using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public AudioSource coinAudioSource;
    public float walkSpeed = 8f;
    public float jumpSpeed = 7f;

    Rigidbody rg;
    Collider coll;
    bool pressedjump = false;
  

    // Start is called before the first frame update
    void Start()
    {

        rg = GetComponent<Rigidbody>();

        coll = GetComponent<Collider>();


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

        bool isGrounded = CheckGrounded();

        if(jAxis > 0f)
        {

            if(!pressedjump && isGrounded)
            {

                pressedjump = true;

                Vector3 jumpVector = new Vector3(0f, jumpSpeed, 0f);
                rg.velocity = rg.velocity + jumpVector;

            }
            else
            {


                pressedjump = false;

            }


        }

       
    }

    bool CheckGrounded()
    {

        float sizeX = coll.bounds.size.x;
        float sizeZ = coll.bounds.size.z;
        float sizeY = coll.bounds.size.y;

        Vector3 corner1 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner2 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner3 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);
        Vector3 corner4 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);

        bool grounded1 = Physics.Raycast(corner1, new Vector3(0, -1, 0), 0.01f);
        bool grounded2 = Physics.Raycast(corner2, new Vector3(0, -1, 0), 0.01f);
        bool grounded3 = Physics.Raycast(corner3, new Vector3(0, -1, 0), 0.01f);
        bool grounded4 = Physics.Raycast(corner4, new Vector3(0, -1, 0), 0.01f);

        return (grounded1 || grounded2 || grounded3 || grounded4);

    }

    void OnTriggerEnter(Collider collider)
    {

        if(collider.gameObject.tag == "Coin")
        {

            coinAudioSource.Play();
            Destroy(collider.gameObject);

        }

    }

}
