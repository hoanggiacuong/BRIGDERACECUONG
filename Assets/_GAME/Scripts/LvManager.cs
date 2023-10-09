using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvManager : MonoBehaviour
{
    public static LvManager Instance;
    public Lv[] lvArrayPrefab;
    private Lv curLv;
    public List<Enemy> listEnemy = new List<Enemy>();
    public Vector3 endPoint => curLv.endPoint.transform.position;
    public Vector3 startPoint => curLv.startPoint.transform.position;
    public Player player;
    private int numOfLv;




    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        

        
       // StartGame();
        UiManager.Instance.Play.gameObject.SetActive(true);
        // EndGame();

    }
    public void Oninit()
    {
        curLv = Instantiate(lvArrayPrefab[0]);
        numOfLv = 0;
        //player.OnInit();
        //foreach(Enemy e in listEnemy)
        //{
        //    int i = Random.Range(-2, 2);
        //    e.transform.position = startPoint + Vector3.right * i;
        //}

        //LoadLv(0);

    }
    public void LoadLv(int lv)
    {
        if (curLv != null)
        {
            Destroy(curLv.gameObject);
        }
        curLv = Instantiate(lvArrayPrefab[lv]);
        curLv.OnInit();
    }

    public void StartGame()
    {
        Oninit();
        Debug.Log("st game");
        player.OnInit();
        for (int i = 0; i < listEnemy.Count; i++)
        {
            listEnemy[i].Stop();
            int k = Random.Range(-2, 2);
            listEnemy[i].transform.position = startPoint + new Vector3(1, 0, 0) * k;
            // listEnemy[i].ChangeColor(listEnemy[i].color);
        }
        player.transform.position = startPoint;
     
        foreach (Enemy e in listEnemy)
        {
            e.Move();
            e.OnInit();
           // e.Move();
            e.ChangeState(new IdleState());
        }
        //UiManager.Instance.btn_Play.gameObject.SetActive(false);
        //UiManager.Instance.btn_Setting.gameObject.SetActive(true);
       

        UiManager.Instance.Play.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        foreach (Enemy e in listEnemy)
        {
            e.ChangeState(null);
            e.Stop();
        }
    }
    public void Retry()
    {
        LoadLv(numOfLv);
        StartGame();
       // UiManager.Instance.Play.gameObject.SetActive(true);
        UiManager.Instance.Victory.gameObject.SetActive(false);
        UiManager.Instance.Lose.gameObject.SetActive(false);
        
    }
    public void NetxLv()
    {
        LoadLv(numOfLv + 1);
        StartGame();
        //UiManager.Instance.Play.gameObject.SetActive(true);
        UiManager.Instance.Victory.gameObject.SetActive(false);
        UiManager.Instance.Lose.gameObject.SetActive(false);
    }



}
