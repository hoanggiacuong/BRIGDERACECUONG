using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startPoint;
    public Transform endPoint;
    public List<Stage> listStage = new List<Stage>();
   
    //public int numOfEnemy;
    private void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        foreach(Stage stg in listStage)
        {
            stg.InitSpawn();
        }
    }
}
