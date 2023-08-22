using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Stage : MonoBehaviour
{
    public List<BrickStage> deactiveBrickLi = new List<BrickStage>();
    public List<BrickStage> activeBrickLi = new List<BrickStage>();
    public List<BrickStage> BrickLi = new List<BrickStage>();
    public List<ColorType> colorCharacter = new List<ColorType>();
    public bool isSpawn;
    bool isAddColor;
    public BrickStage brickPre;
    //public List<BrickStage> browBrickLi = new List<BrickStage>();
    //public List<BrickStage> blueBrickLi = new List<BrickStage>();
    //public List<BrickStage> greenBrickLi = new List<BrickStage>();


    // Start is called before the first frame update
    void Start()
    {
        //InitSpawn();
        //StartCoroutine(CallFunctionEvery3Seconds());

        // StartCoroutine(CallFunctionEvery3Seconds());
    }

    //// Update is called once per frame
    void Update()
    {
        //Invoke(nameof(SpawnBrick1), 1f);
        //if (isSpawn)
        //{

        //}

      //  Debug.Log("cl cr" + colorCharacter.Count);



    }
    public IEnumerator CallFunctionEvery3Seconds()
    {
        while (true) // Vòng lặp vô hạn để thực hiện liên tục
        {
            SpawBrick(); // Gọi hàm của bạn ở đây

            yield return new WaitForSeconds(3.0f); // Chờ 3 giây
        }
    }


    //private void SpawnBrick1()
    //{
    //    activeBrickLi.Clear();
    //    //foreach (BrickStage br in BrickLi)
    //    //{
    //    //    if (br.gameObject.activeSelf == true)
    //    //    {
    //    //        activeBrickLi.Add(br);

    //    //    }
    //    //}

    //    for(int k=0; k < BrickLi.Count; k++)
    //    {
    //        if (BrickLi[k].gameObject.activeSelf == true)
    //        {
    //            activeBrickLi.Add(BrickLi[k]);
    //        }
    //    }
    //    for (int i = 0; i < colorCharacter.Count; i++)
    //    {
    //        isSpawn = true;
    //        for (int j = 0; j < activeBrickLi.Count; j++)
    //        {
    //            Debug.Log("spawbr1");
    //            Debug.Log(activeBrickLi[i].color + "" + colorCharacter[i]);
    //            if (activeBrickLi[i].color == colorCharacter[i])
    //            {
                    
    //                isSpawn = false;
    //                break;
    //            }
    //        }
    //        if (isSpawn == true)
    //        {
    //            Debug.Log("spawbr");
    //            SpawBrick(colorCharacter[i]);
    //        }

    //    }
    //}
    public void SpawBrick()
    {


        
        deactiveBrickLi.Clear();
        foreach (BrickStage br in BrickLi)
        {
            if (br.gameObject.activeSelf == false)
            {
                deactiveBrickLi.Add(br);

            }
        }

        // System.Random random = new System.Random();
        //int a = UnityEngine.Random.Range(2, 4);
        //detiveBrickLi = detiveBrickLi.OrderBy(item => random.Next()).ToList();
        //foreach (BrickStage brick in )
        //{

        //    brick.GetComponent<BrickStage>().ChangeColor(color);
        //    brick.gameObject.SetActive(true);
        //}

        if (deactiveBrickLi.Count > 0)
        {
           int numOfSpaw = UnityEngine.Random.Range(1, deactiveBrickLi.Count / 3);
           // int numOfSpaw =  deactiveBrickLi.Count / 3;
            for (int i = 0; i < numOfSpaw; i++)
            {
                
                int randomIndex = UnityEngine.Random.Range(0, deactiveBrickLi.Count-1); //
                BrickStage brickspawn = deactiveBrickLi[randomIndex];
                if (colorCharacter.Count != 0)
                {
                    ColorType color = colorCharacter[ (int)UnityEngine.Random.Range(0, colorCharacter.Count)];
                    int cout = 0;
                    foreach (BrickStage br in BrickLi)
                    {
                       
                        if (br.color==color && br.gameObject.activeSelf==true)
                        {
                           
                            cout += 1;
                        }
                        
                    }
                    if(cout<= BrickLi.Count / 3)
                    {

                        Debug.Log(color);
                        brickspawn.GetComponent<BrickStage>().ChangeColor(color);
                        brickspawn.gameObject.SetActive(true);
                    }

                }


            }
        }



    }

  public  void InitSpawn()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        for (float i = x - transform.localScale.x/2+1; i < x+transform.localScale.x / 2 - 1; i += 3f)
        {
            for (float j = z - transform.localScale.z/ 2 +1; j < z + transform.localScale.x / 2 -4; j += 2f)
            {
                BrickStage br = Instantiate(brickPre, new Vector3(i, y + 0.5f, j), Quaternion.identity, this.transform);

                int rd = UnityEngine.Random.Range(1, 4);
                if (rd == 1)
                {
                    br.ChangeColor(ColorType.Brown);

                }
                if (rd == 2)
                {
                    br.ChangeColor(ColorType.Blue);

                }
                if (rd == 3)
                {
                    br.ChangeColor(ColorType.Green);

                }


                BrickLi.Add(br);
            }
        }
        StartCoroutine(CallFunctionEvery3Seconds());


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Character>() != null)
        {
            ColorType color = other.GetComponent<Character>().color;
          //  Debug.Log(color);
            //colorCharacter.Add(color);

            //foreach (ColorType cl in colorCharacter)
            //{
            //    if(cl!=color|| colorCharacter.Count==0)
            //    {
            //        colorCharacter.Add(color);
            //    }
            //}

            if (colorCharacter.Count == 0)
            {
                colorCharacter.Add(color);
                


                foreach (BrickStage br in BrickLi)
                {
                    if (br.color == color)
                    {
                        br.gameObject.SetActive(true);
                    }
                }

            }
            else
            {
                isAddColor = true;
                for (int i = 0; i < colorCharacter.Count; i++)
                {
                   // Debug.Log(" trong vong lap");

                    if (colorCharacter[i] == color)
                    {
                        isAddColor = false;
                        break;
                    }

                }
                if (isAddColor == true)
                {
                    colorCharacter.Add(color);
                    foreach (BrickStage br in BrickLi)
                    {
                        if (br.color == color)
                        {
                            br.gameObject.SetActive(true);
                        }
                    }
                }
            }

            // Debug.Log("a");
            //SpawBrick(color);

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Character>()!= null)
        {
            ColorType color = other.GetComponent<Character>().color;
            //foreach(ColorType cl in colorCharacter)
            //{
            //    if (cl == color)
            //    {
            //        colorCharacter.Remove(cl);
            //    }
            //}

            for(int i=0; i < colorCharacter.Count; i++)
            {
                if (color == colorCharacter[i])
                {
                    colorCharacter.RemoveAt(i);
                }
            }
        }
    }
}
