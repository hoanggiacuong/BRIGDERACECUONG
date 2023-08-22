using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoStairState : iState
{
    // Start is called before the first frame update
    public void OnEnter(Enemy enemy)
    {
        enemy.Move();
        enemy.agent.speed = 4f;
    }
    public void OnExecute(Enemy enemy)
    {
        enemy.agent.SetDestination(LvManager.Instance.endPoint);
        if (enemy.BrickStack.Count == 0)
        {
            enemy.agent.speed = 0;
          //  enemy.Stop();
            enemy.agent.ResetPath();
          //  Debug.Log(enemy.BrickStack);
            enemy.ChangeState(new FindBrickState());  
          
        }
       

    }
    public void OnExit(Enemy enemy)
    {
        //enemy.agent.speed = 0;
       // enemy.agent.ResetPath();
    }
}
