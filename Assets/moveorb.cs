using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class moveorb : MonoBehaviour
{
    public KeyCode moveL;
    public KeyCode moveR;
    public float horizVel = 0;
    public int laneNum = 2;
    public float zDir = 4;

    public string controlLocked = "n";
    public Transform boomObj;
    public AudioSource coinAudio;
    public AudioSource GOAudio;
    public AudioSource PowerAudio;
    public Slider s;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GM.verVel, zDir);
        if ((Input.GetKeyDown(moveL)) && (laneNum > 1) && (controlLocked == "n"))
        {
            horizVel = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }
        if ((Input.GetKeyDown(moveR)) && (laneNum < 3) && (controlLocked == "n"))
        {
            horizVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "lethal")
        {
            Destroy(gameObject);
            
            GOAudio.Play();
            Instantiate(boomObj, transform.position, boomObj.rotation);
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
        if (other.gameObject.name == "Capsule(Clone)")
        {
            Destroy(other.gameObject);
            PowerAudio.Play();
            zDir = 8;
            
        }

    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.5f);
        horizVel = 0;
        controlLocked = "n";
    }
}
