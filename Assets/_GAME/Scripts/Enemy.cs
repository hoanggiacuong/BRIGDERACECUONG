using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Character
{
    
    private iState currentState;
    public UnityEngine.AI.NavMeshAgent agent;
    public Stage stage;
 public  Vector3 targetPos;
    Vector3 tfPos;
    public int numOfBrick;
    
    //[SerializeField] private GameObject holderBrick;
    //[SerializeField] private GameObject BrickRender;

    //public Stack<GameObject> BrickStack = new Stack<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        //OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null )
        {
            currentState.OnExecute(this);
           Debug.Log(currentState);
        }


    }

    public override void OnInit()
    {

        base.OnInit();
       //color = ColorType.Blue;
        ChangeColor(color);

        Debug.Log(color);
        ChangeState(null);
       targetPos = new Vector3(transform.position.x, transform.position.y -1f, transform.position.z);
       
    }
    public void Stop()
    {
        agent.speed = 0;
        ChangeAnim("idle");
        agent.enabled = false;
    }
    public void Move()
    {
        agent.speed = 6f;
        ChangeAnim("run");
        agent.enabled = true;
    }
    public void FindBrick()
    {
       
        //int numOfBrick = Random.Range(1, 5);
        //int coutBrick=0;
        agent.speed = 6f;
        ChangeAnim("run");
        //if (curStage == 1)
        //{

        //    stage = LvManager.Instance.listStage[0];


        //} else if(curStage == 2)
        //{
        //    stage = LvManager.Instance.listStage[1];
        //}
          tfPos = new Vector3(transform.position.x, transform.position.y -0.95f, transform.position.z);
      // Debug.Log(tfPos + "" + targetPos);
      //  Debug.Log(Vector3.Distance(tfPos, targetPos));
        if (Vector3.Distance(tfPos, targetPos) < 0.2f|| BrickStack.Count == 0)
        {
            foreach (BrickStage br in stage.BrickLi)
            {
                if (br.gameObject.activeSelf == true && br.color == this.color)
                {
                    //Vector3 brTarget = br.gameObject.transform.position;
                    targetPos = br.gameObject.transform.position;
                  //  Debug.Log(tfPos + "" + targetPos);
                    //coutBrick += 1;
                    break;
                }
            }
            agent.SetDestination(targetPos);
            // Debug.Log("tim gach mới");
        }

       



    }

    public void ChangeState(iState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Stage>() != null)
        {
            stage = (Stage)other.GetComponent<Stage>();
        }
    }
}
