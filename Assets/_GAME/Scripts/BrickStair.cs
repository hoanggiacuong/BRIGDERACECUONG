using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStair : MonoBehaviour
{

    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    public ColorType color;

    //private bool isActive=false;
    [SerializeField] private Player player;

    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        meshRenderer.material = colorData.GetMat(colorType);
    }


    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        // Debug.Log(other.tag+"  "+ player.color+"  "+this.color);

        if (other.CompareTag("Player") && (player.color != this.color) && player.BrickStack.Count > 0)
        {
            // Debug.Log("va cham player");
            //gameObject.SetActive(true);
            ChangeColor(ColorType.Brown);
            player.RemoveStack();


        }
        if (other.CompareTag("Player") && (player.color == this.color) && player.BrickStack.Count == 0)
        {
            player.isSameColor = true;
        }
        else if (other.CompareTag("Player") && (player.color != this.color) && player.BrickStack.Count == 0)
        {
            player.isSameColor = false;
        }

        if (other.GetComponent<Enemy>() != null)
        {
            if (other.GetComponent<Enemy>().color != color && other.GetComponent<Enemy>().BrickStack.Count > 0)
            {
                ChangeColor(other.GetComponent<Enemy>().color);
                other.GetComponent<Enemy>().RemoveStack();
            }
        }

    }


}
