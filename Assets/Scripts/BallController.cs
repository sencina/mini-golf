using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{   
    public float maxPower;
    public float changeAngleSpeed;
    public float lineLength;
    public Slider powerSlider;
    public TextMeshProUGUI puttCountLabel;

    private LineRenderer line;
    private Rigidbody ball;
    private float angle;
    private float powerUpTime;
    private float power;
    private int putts;

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
            putt();
        }
        if (Input.GetKey(KeyCode.Space)){
            powerUp();
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

    private void putt()
    {
        ball.AddForce(Quaternion.Euler(0,angle,0) * Vector3.forward * maxPower * power, ForceMode.Impulse);
        power = 0;
        powerSlider.value = 0;
        powerUpTime = 0;
        putts += 1;
        puttCountLabel.text = putts.ToString();
    }

    private void powerUp(){
        powerUpTime += Time.deltaTime;
        power = Mathf.PingPong(powerUpTime,1);
        powerSlider.value = power;
    }

}
