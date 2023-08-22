using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDoor : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player") && other.GetComponent<Player>().isUpBrigde)
        {
            other.GetComponent<Player>().isStage = true;
         
            // gameObject.SetActive(true);
        }


        if (other.CompareTag("Player") && !other.GetComponent<Player>().isUpBrigde )
        {

            other.GetComponent<Player>().isStage = false;
            other.GetComponent<Player>().isNewStage = false;


            //gameObject.SetActive(false);
        }
        if (other.GetComponent<Character>() != null)
        {
            other.GetComponent<Character>().curStage += 1;
        }

    }
}
