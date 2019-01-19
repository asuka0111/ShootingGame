﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankMovement : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;

    private bool isLButtonDown = false;
    private bool isRButtonDown = false;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		
	}

    // Update is called once per frame
    void Update()
    {
        Move();
        Turn();

        if (Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown)&& -this.movableRange < this.transform.position.x){
            this.myRgidbody.AddForce(-this.turnForce, 0, 0);

        }else if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange)
        {
            this.myRigidbody.AddForce(this.turnForce, 0, 0);
        }
    }


		
	}
    //前進後退のメソッド
    void Move()
    {
        movementInputValue = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

    }
    //旋回のメソッド
    void Turn(){
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    //bottomの判定
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bottom"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   
        if (other.gameObject.tag == "Goal")
        {
            Invoke("GoToGameClear", 1.5f);
        }

    }

    void GoToGameClear()
    {
        SceneManager.LoadScene("GameClear");
    }


}
