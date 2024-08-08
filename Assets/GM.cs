using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GM : MonoBehaviour
{
    public GameObject go;
    public GameObject timeGO;
    public GameObject coinGO;
    public GameObject Nameplayer;
    public static float verVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    //public float waitToLoad = 0;
    public float zScenePos = 58;
    public static string lvlCompStatus = "";
    public Transform bbNoPit;
    public Transform bbPitMid;
    public Transform coinObj;
    public Transform obstObj;
    public Transform capsuleObj;
    public static bool gameover;
    public GameObject gameoverpanel;
    public int randNum;
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        Instantiate(bbNoPit, new Vector3(0, 0, 0), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 4), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 8), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 10), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 14), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 18), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 22), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 26), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 30), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 34), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 38), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 42), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 46), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 50), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 0, 54), bbNoPit.rotation);


    }

    // Update is called once per frame
    void Update()
    {
        if (zScenePos < float.MaxValue)
        {
            randNum = Random.Range(0, 10);
            if (randNum < 3)
            {
                Instantiate(coinObj, new Vector3(-1, 1, zScenePos), coinObj.rotation);
            }
            if (randNum > 7)
            {
                Instantiate(coinObj, new Vector3(1, 1, zScenePos), coinObj.rotation);
            }
            if (randNum == 4)
            {
                Instantiate(obstObj, new Vector3(1, 1, zScenePos), obstObj.rotation);
            }
            if (randNum == 5)
            {
                Instantiate(obstObj, new Vector3(0, 1, zScenePos), obstObj.rotation);
            }
            if (randNum == 6)
            {
                Instantiate(capsuleObj, new Vector3(0, 1, zScenePos), capsuleObj.rotation);
            }
            Instantiate(bbNoPit, new Vector3(0, 0, zScenePos), bbNoPit.rotation);
            zScenePos += 4;
        }


        timeTotal += Time.deltaTime;
        if (gameover)
        {
            Time.timeScale = 0;
            gameoverpanel.SetActive(true);
            go.SetActive(true);
            timeGO.SetActive(true);
            coinGO.SetActive(true);
            //Nameplayer.SetActive(true);
            
        }
    }
}