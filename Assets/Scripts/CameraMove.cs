using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float MoveSpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            velocity.y = MoveSpeed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            velocity.y = MoveSpeed * Time.deltaTime * -1;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            velocity.x = MoveSpeed * Time.deltaTime * -1;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            velocity.x = MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.PageUp)) {
            velocity.z = MoveSpeed * Time.deltaTime * 0.75f;
        } else if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.PageDown)) {
            velocity.z = MoveSpeed * Time.deltaTime * -0.75f;
        }

        transform.position = transform.position + velocity;
    }
}
