using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBrickState : iState
{
    // Start is called before the first frame update
    float timer;
    float randomeTime;
    Vector3 TargetBrick;
    public void OnEnter(Enemy enemy)
    {
        //int numOfBrick = Random.Range(1, 5);
        enemy.Move();
        enemy.numOfBrick = Random.Range(5, 9);
;   }
    public void OnExecute(Enemy enemy)
    {
        //Debug.Log(Vector3.Distance(enemy.transform.position, enemy.targetPos));

        enemy.FindBrick();
        if (enemy.BrickStack.Count == enemy.numOfBrick)
        {
           // enemy.agent.speed = 0;
            

            enemy.ChangeState(new GoStairState());
        }

    }
    public void OnExit(Enemy enemy)
    {
        enemy.numOfBrick = 0;
    }
}
