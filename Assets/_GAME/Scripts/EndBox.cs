using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("endboxx");
        if (other.GetComponent<Player>() != null)
        {
            Debug.Log("va chan endboxx");
            //UiManager.Instance.btn_Next.gameObject.SetActive(true);
            UiManager.Instance.Victory.gameObject.SetActive(true);
            LvManager.Instance.EndGame();
            other.GetComponent<Player>().ClearStack();

        }
        else if (other.GetComponent<Enemy>() != null)
        {
            UiManager.Instance.Lose.gameObject.SetActive(true);
            LvManager.Instance.EndGame();
            other.GetComponent<Enemy>().ClearStack();
        }
    }
}
