using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public  TMP_InputField NameIF;
    
    public static string nameplayer;
    
    private SceneManager sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NamePlayer()
    {
        if (NameIF.text != "")
        {
            nameplayer = NameIF.text;
          
            SceneManager.LoadScene("level1");
        }
        else
        {
            NameIF.text = "Please enter name";
        }
    }


}
