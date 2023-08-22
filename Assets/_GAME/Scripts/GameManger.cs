using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;
  // [SerializeField] public  Transform endPoint;
    private GameState gameState;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        
      
    }

    public void ChangeSate(GameState gameState)
    {
        this.gameState = gameState;
    }
    public bool  isState(GameState gameState)
    {
        return gameState == this.gameState;
    }



}
public enum GameState { Start, Play, Pause }
