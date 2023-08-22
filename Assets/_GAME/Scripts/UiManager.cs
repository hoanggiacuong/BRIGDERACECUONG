using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public Canvas Play;
    public Canvas Victory;
    public Canvas  Setting ;
    public Canvas Lose;


    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
