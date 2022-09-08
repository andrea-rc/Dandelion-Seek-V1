using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer inst;
    public float timer1 = 0;
    public Text textoTimer;

    //void Awake()
    //{
      //  DontDestroyOnLoad(gameObject);
    //}


        void Update()
    {
        timer1 += Time.deltaTime;
        textoTimer.text = "" + timer1.ToString("f1");
    }
}
