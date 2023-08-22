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
        Oninit();

        //LoadLv(0);
       // StartGame();
        UiManager.Instance.Play.gameObject.SetActive(true);
        // EndGame();

    }
    public void Oninit()
    {
        curLv = lvArrayPrefab[0];
        numOfLv = 0;
        player.OnInit();
        //foreach(Enemy e in listEnemy)
        //{
        //    int i = Random.Range(-2, 2);
        //    e.transform.position = startPoint + Vector3.right * i;
        //}

        for(int i=0; i < listEnemy.Count; i++)
        {
            listEnemy[i].Stop();
            int k = Random.Range(-2, 2);
            listEnemy[i].transform.position = startPoint + Vector3.right * k;
           // listEnemy[i].ChangeColor(listEnemy[i].color);
        }
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
        foreach (Enemy e in listEnemy)
        {
            e.Move();
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
    }
    public void NetxLv()
    {
        LoadLv(numOfLv + 1);
    }



}
