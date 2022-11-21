using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float hInput, vInput, mouseX, mouseY;

    [SerializeField]
    GameObject thirdPersonCamera, cameraX, cameraY, hitbox1, hitbox2, panel;

    [SerializeField]
    float movementSpeed, rotationSpeed;

    Animator myAnimator;
    float attackTimeStamp;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 5;
        rotationSpeed = 500;
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        thirdPersonCamera.transform.position = transform.position + new Vector3(0, 1, 0);

        if(!myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack01") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack02"))
        {
            transform.Translate(Vector3.forward * vInput * movementSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * hInput * movementSpeed * Time.deltaTime);
            if (vInput > 0)
            {
                myAnimator.SetBool("walking", true);
            }
            else
            {
                myAnimator.SetBool("walking", false);
            }
        }

        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);
        cameraX.transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);

        if(Input.GetMouseButtonDown(0) && Time.time > attackTimeStamp + 0.65)
        {
            myAnimator.Play("Attack01", 0, 1);
            attackTimeStamp = Time.time;
            hitbox1.SetActive(true);
            hitbox1.SendMessage("Active");
        }
        else if (Input.GetMouseButtonDown(1) && Time.time > attackTimeStamp + 0.65)
        {
            myAnimator.Play("Attack02", 0, 1);
            attackTimeStamp = Time.time;
            hitbox2.SetActive(true);
            hitbox2.SendMessage("Active");
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
