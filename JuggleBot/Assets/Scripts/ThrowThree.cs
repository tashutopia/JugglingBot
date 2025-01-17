﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowThree : MonoBehaviour
{
    public Vector3 ThrowingPower_left = new Vector3();
    public Vector3 ThrowingPower_right = new Vector3();
    public float time;
    public float timeBetweenThrows;
    public GameObject Ball_One;
    public GameObject Ball_Two;
    public GameObject Ball_Three;
    public GameObject Target_Left;
    public GameObject Target_Right;
    public Rigidbody rb_one;
    public Rigidbody rb_two;
    public Rigidbody rb_three;

    // Start is called before the first frame update
    void Start()
    {
 
        rb_one = Ball_One.GetComponent<Rigidbody>();
        rb_two = Ball_Two.GetComponent<Rigidbody>();
        rb_three = Ball_Three.GetComponent<Rigidbody>();

        rb_one.useGravity = false;
        rb_two.useGravity = false;
        rb_three.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("throw one");
            StartCoroutine(Throw_One());
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(Throw_Two());
        }

    }

    IEnumerator Throw_One()
    {
   
        rb_one.useGravity = true;
        rb_one.AddForce(ThrowingPower_left, ForceMode.Impulse);
        yield return new WaitForSeconds(time);
        //Throws the purple ball towards the right hand and waits for 0.5 seconds
        rb_two.useGravity = true;
        rb_two.AddForce(ThrowingPower_right, ForceMode.Impulse);
        yield return new WaitForSeconds(time*3/2);
        //Throws the green ball towards the left hand and waits for 0.75 seconds
        rb_three.useGravity = true;
        rb_three.AddForce(ThrowingPower_left, ForceMode.Impulse);
        //Throws the purple ball towards the left hand
        yield return new WaitForSeconds(timeBetweenThrows);
        StartCoroutine(Throw_Two());
        
    }

    IEnumerator Throw_Two()
    {
        rb_one.useGravity = true;
        rb_one.AddForce(ThrowingPower_right, ForceMode.Impulse);
        yield return new WaitForSeconds(time);
        //Throws the purple ball towards the right hand and waits for 0.5 seconds
        rb_two.useGravity = true;
        rb_two.AddForce(ThrowingPower_left, ForceMode.Impulse);
        yield return new WaitForSeconds(time*3/2);
        //Throws the green ball towards the left hand and waits for 0.75 seconds
        rb_three.useGravity = true;
        rb_three.AddForce(ThrowingPower_right, ForceMode.Impulse);
        //Throws the purple ball towards the left hand
        yield return new WaitForSeconds(timeBetweenThrows);
        StartCoroutine(Throw_One());
    }
}
