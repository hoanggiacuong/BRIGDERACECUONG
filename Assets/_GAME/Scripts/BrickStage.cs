using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStage : MonoBehaviour
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    public ColorType color;
   

    //private bool isActive=false;
    private Player player;
    public Stage stage;


    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        meshRenderer.material = colorData.GetMat(colorType);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if ( other.GetComponent<Character>().color==this.color)
        {
            other.GetComponent<Character>().AddBrick();
            gameObject.SetActive(false);
            //if (other.GetComponent<Player>().curStage == 1)
            //{
            //    stage = StageManager.stageManager.listStage[0];
                
            //}
            //else if(other.GetComponent<Player>().curStage == 2)
            //{
            //    stage = StageManager.stageManager.listStage[1];
               
            //}
            
        }
    }
}
