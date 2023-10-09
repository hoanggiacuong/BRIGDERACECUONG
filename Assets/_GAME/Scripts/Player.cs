using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player : Character
{
    [SerializeField] private LayerMask groudLayer;
    [SerializeField] protected Joystick joystick;
    [SerializeField] private VariableJoystick joyButton;
    [SerializeField] private float speed;
   // [SerializeField] private float yOffset;
    // public Transform player;
    private Vector3 movement;
    public NavMeshAgent agent;
    public Transform startPoint;
    //[SerializeField] private GameObject holderBrick;
    //[SerializeField] private GameObject BrickRender;

    //public Stack<GameObject> BrickStack = new Stack<GameObject>();
   // private Vector3 startPos;
    

    public bool isStage = true;
    public bool isNewStage = true;
    public bool isSameColor=false;
    [SerializeField] public bool isUpBrigde = false;



    // Start is called before the first frame update
    void Start()
    {
        isStage = true;
        //OnInit();
        // agent = GetComponent<NavMeshAgent>();
        //ChangeColor(ColorType.Brown);
        //color = ColorType.Brown;

    }
    public override void OnInit()
    {
        ChangeColor(ColorType.Brown);
        color = ColorType.Brown;
        //transform.position = startPoint.position;
        agent.speed = speed;
        ChangeAnim("idle");
        if (BrickStack.Count != 0)
        {
            ClearStack();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //isStage = CheckGrounded();

        if (transform.forward.z > 0)
        {
            isUpBrigde = true;
        }
        else if (transform.forward.z < 0)
        {
            isUpBrigde = false;

        }

        if (isStage)
        {
            agent.speed = 5f;
            Move();
        }
        else
        {
            if ( isUpBrigde == true && BrickStack.Count == 0 && isSameColor == false)
            {
                agent.speed = 0;
                Move();
                
              //hangeAnim("idle");
            }
            //di len co gach
            else if ( isUpBrigde == true && BrickStack.Count > 0)
            {
                agent.speed = 6f;
                Move();
            }
            // DI XUONG

            else
            {
                agent.speed = 6f;
                Move();
            }
        }
        // di len het gach











    }
    private void Move()
    {

        //Debug.Log(joystick.Horizontal + "" + joystick.Vertical);
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        movement.Set(horizontalInput, 0f, verticalInput);
        // Quaternion a = Quaternion.LookRotation(movement);
        if (movement.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), 30f);
            agent.Move(movement * Time.fixedDeltaTime * agent.speed);
        }


        if (movement == new Vector3(0, 0, 0))
        {
            ChangeAnim("idle");
        }
        else
        {
            ChangeAnim("run");
        }
        
        

        // agent.SetDestination(transform.position + movement);

    }




    //public void AddBrick()
    //{
    //    startPosY += yOffset;
    //    startPos = new Vector3(holderBrick.transform.position.x, startPosY, holderBrick.transform.position.z);
    //    GameObject brick = Instantiate(BrickRender, startPos, Quaternion.identity, holderBrick.transform);
    //    BrickStack.Push(brick);

    //    brick.transform.SetParent(holderBrick.transform);
    //    brick.transform.localRotation = Quaternion.Euler(0, 0, 0);
    //}
    //public void RemoveStack()
    //{

    //    if (BrickStack.Count > 0)
    //    {

    //        startPosY -= yOffset;
    //        GameObject BrickPop = BrickStack.Pop();
    //        Destroy(BrickPop);


    //    }


   // }
    private bool CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groudLayer);

        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.green);
        return hit.collider != null;
    }


}


