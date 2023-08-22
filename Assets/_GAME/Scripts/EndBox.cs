using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>()!=null)
        {
            //UiManager.Instance.btn_Next.gameObject.SetActive(true);
            //UiManager.Instance.btn_Retry.gameObject.SetActive(true);
            LvManager.Instance.EndGame();

        }else if(other.GetComponent<Enemy>() != null)
        {
            //UiManager.Instance.btn_Retry.gameObject.SetActive(true);
            LvManager.Instance.EndGame();
        }
    }
}
