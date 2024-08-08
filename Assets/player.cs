using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float MoveSpeed = 1.0f;
    public float JumpSpeed = 3.0f;
    public float Standing = -1.5f;
    public float Gravity = -9.8f;
    public float YSpeed = -1.5f;
    public float MinSpeed = -10.0f;
    public float horizVel = 0;
    public float zDir = 4;
    public AudioSource BGaudio;
    public Transform boomObj;
    public AudioSource coinAudio;
    public AudioSource GOAudio;
    public AudioSource PowerAudio;
    CharacterController CharController;
    Animator animator;
    public GameObject timer;
    public Slider s;
    // Start is called before the first frame update
    void Start()
    {
        BGaudio.Play();
        CharController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float Move_X = Input.GetAxis("Horizontal");
        Vector3 Movement = new Vector3(Move_X, 0, zDir);
        
        float Velocity = Movement.magnitude;
        if (CharController.isGrounded)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                YSpeed = JumpSpeed;
                animator.SetBool("Jump", true);
            }
            else
            {
                YSpeed = Standing;
                animator.SetBool("Jump", false);
            }
        }
        else
        {
            YSpeed += Gravity * 5 * Time.deltaTime;
            if (YSpeed < MinSpeed)
            {
                YSpeed = MinSpeed;
            }
        }
        Movement *= MoveSpeed;
        Movement.y = YSpeed;
        Movement *= Time.deltaTime;
        CharController.Move(Movement);
        s.value -= 0.001f;
        if (s.value == 0 && zDir == 8)
        {
            zDir = 4;
            timer.SetActive(false);
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "lethal")
        {
            Destroy(gameObject);
   
            GOAudio.Play();
            //Instantiate(boomObj, transform.position, boomObj.rotation);
            GM.lvlCompStatus = "Game Over";
        }

    }*/
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "lethal")
        {
            GM.gameover = true;
            GOAudio.Play();
            BGaudio.Stop();
            GM.lvlCompStatus = "Game Over";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "coin(Clone)")
        {
            Destroy(other.gameObject);
            coinAudio.Play();
            GM.coinTotal += 1;
        }
        //PowerUp
        if (other.gameObject.name == "Capsule(Clone)")
        {
            timer.SetActive(true);
            s.value = 100;
            Destroy(other.gameObject);
            PowerAudio.Play();
            zDir = 8;
        }

    }

}
