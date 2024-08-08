using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class states : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
       
         //   Debug.Log(Name.nameplayer);
            textMeshPro.text = Name.nameplayer;
        
    }

        // Update is called once per frame
        void Update()
    {
        if (gameObject.name == "coinstxt")
        {
            GetComponent<TextMeshPro>().text = "Coins : " + GM.coinTotal;
        }
        if (gameObject.name == "timetxt")
        {
            GetComponent<TextMeshPro>().text = "Score : " + Mathf.RoundToInt(GM.timeTotal);
        }
        if (gameObject.name == "runstatus")
        {
            GetComponent<TextMeshPro>().text = GM.lvlCompStatus;
        }
        /*if (gameObject.name == "Name")
        {
            GetComponent<TextMeshPro>().text = Name.nameplayer;
        }*/
     
    }
     
     
    
}