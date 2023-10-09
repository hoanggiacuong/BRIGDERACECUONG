using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    public ColorType color;
    private string currentAnimName;
    public int curStage = 1;
    [SerializeField] private GameObject holderBrick;
    [SerializeField] private GameObject BrickRender;
    [SerializeField] public float yOffset;

    private Vector3 startPos;

    [SerializeField] public Stack<GameObject> BrickStack = new Stack<GameObject>();
    private float startPosY;


    private void Awake()
    {
       // OnInit();
    }


    public virtual void OnInit()
    {
        ChangeColor(color);
    }
    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        meshRenderer.material = colorData.GetMat(colorType);
    }
    protected void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
    public void AddBrick()
    {
      //  Debug.Log(BrickStack);
        startPosY = gameObject.transform.position.y;
        startPosY += BrickStack.Count* (yOffset);
        startPos = new Vector3(holderBrick.transform.position.x, startPosY, holderBrick.transform.position.z);
        GameObject brick = Instantiate(BrickRender, startPos, Quaternion.identity, holderBrick.transform);
        brick.GetComponent<MeshRenderer>().material = colorData.GetMat(color);
        BrickStack.Push(brick);

        brick.transform.SetParent(holderBrick.transform);
        brick.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    public void RemoveStack()
    {

        if (BrickStack.Count > 0)
        {

            //startPosY -= yOffset;
            GameObject BrickPop = BrickStack.Pop();
            Destroy(BrickPop);


        }


    }
    public void ClearStack()
    {
        while (BrickStack.Count != 0)
        {
            GameObject BrickPop = BrickStack.Pop();
            Destroy(BrickPop);

        }
        
    }
}

