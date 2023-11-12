using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solid : MonoBehaviour
{
    // 입체구조의 속성을 정의한다.
    public float mass = 1f; // 질량
    public float gravity = 9.8f; // 중력
    public float elasticity = 0.5f; // 탄성계수
    public float height = 10f; // 높이
    public float angle = 0f; // 각도
    public float speed = 0f; // 속도
    public float momentum = 0f; // 운동량
    public float impact = 0f; // 충격
    public float collisionTime = 0f; // 충돌 시간

    // 충돌 전후의 시간을 저장할 변수를 선언한다.
    private float beforeTime = 0f;
    private float afterTime = 0f;

    // 바닥과 충돌 여부를 판단할 변수를 선언한다.
    private bool isCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        // 입체구조의 물리 엔진을 활성화한다.
        GetComponent<Rigidbody>().useGravity = true;
        // 입체구조의 질량, 중력, 탄성계수를 설정한다.
        GetComponent<Rigidbody>().mass = mass;
        Physics.gravity = new Vector3(0, -gravity, 0);
        GetComponent<Collider>().material.bounciness = elasticity;
        // 입체구조의 높이와 각도를 설정한다.
        transform.position = new Vector3(0, height, 0);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {
        // 입체구조의 속도와 운동량을 계산한다.
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        momentum = mass * speed;
        // 입체구조가 바닥과 충돌하면 충돌 시간과 충격을 계산한다.
        if (isCollided)
        {
            collisionTime = afterTime - beforeTime;
            impact = Mathf.Abs(momentum - mass * GetComponent<Rigidbody>().velocity.magnitude);
            // 충돌 시간과 충격을 콘솔에 출력한다.
            Debug.Log("Collision Time: " + collisionTime + " s");
            Debug.Log("Impact: " + impact + " Ns");
        }
    }

    // 입체구조가 바닥과 충돌하기 직전의 시간을 기록한다.
    private void OnCollisionEnter(Collision collision)
    {
        beforeTime = Time.time;
        isCollided = true;
    }

    // 입체구조가 바닥과 충돌한 후의 시간을 기록한다.
    private void OnCollisionExit(Collision collision)
    {
        afterTime = Time.time;
    }

    //끝?? 끝????
}
