using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : iState
{
    float timer;
    float randomeTime;


    // Start is called before the first frame update
    public void OnEnter(Enemy enemy) 
    {
        timer = 0;
        randomeTime = Random.Range(3f, 4f);
        enemy.Stop();
    }
    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if (timer > randomeTime)
        {
            enemy.ChangeState(new FindBrickState());
        }
    }
    public void OnExit(Enemy enemy)
    {

    }
}
