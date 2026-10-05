using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 5;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI velocityText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI positionText;
    private Vector3 oldPosition;
    private float velocity;
    private float magnitude;
    private Vector3 positionChange;

    void OnMove ( InputValue value ) {
        moveValue = value.Get<Vector2>();
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);

        positionChange = transform.position - oldPosition;
        magnitude = MathF.Sqrt(positionChange.x * positionChange.x + positionChange.y * positionChange.y + positionChange.z * positionChange.z);
        velocity = magnitude / Time.deltaTime;

        oldPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
        oldPosition = transform.position;
    }

    private void Update()
    {



        velocityText.text = "Velocity: " + velocity.ToString();
        positionText.text = "Position: " + transform.position.ToString();



    }

    private void SetCountText() {
        scoreText.text = "Score: " + count.ToString();
        if(count >= numPickups)
        {
            winText.text = "You win!";
        }
    }
}
