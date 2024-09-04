using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{   
    public float maxPower;
    public float changeAngleSpeed;
    public float lineLength;

    private LineRenderer line;
    private Rigidbody ball;
    private float angle;

    void Awake()
    {
        ball = GetComponent<Rigidbody>();
        ball.maxAngularVelocity = 1000;
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)){
            changeAngle(-1);
        }
        if (Input.GetKey(KeyCode.D)){
            changeAngle(1);
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            
        }
        updateLinePositions();
    }

    private void changeAngle(int direction){
        angle += changeAngleSpeed * Time.deltaTime * direction;
    }

    private void updateLinePositions(){
        line.SetPosition(0,transform.position);
        line.SetPosition(1,transform.position + Quaternion.Euler(0,angle,0) * Vector3.forward * lineLength);
    }

}
