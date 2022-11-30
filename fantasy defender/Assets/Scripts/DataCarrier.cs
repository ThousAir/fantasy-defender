using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataCarrier : MonoBehaviour
{
    public int life=100;
    public int money=100;
   
    public static DataCarrier Data;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Data == null)
        {
            Data = this;
        }
    }

   
}
