using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDoor : MonoBehaviour
{
    private Player player;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<Player>().isUpBrigde)
        {
            other.GetComponent<Player>().isStage = true;
            // gameObject.SetActive(true);
        }


        if (other.CompareTag("Player") && other.GetComponent<Player>().isUpBrigde == true)
        {

            other.GetComponent<Player>().isStage = false;

            //gameObject.SetActive(false);
        }

    }
}
