using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ap1;
    public GameObject ap2;
    public GameObject ap3;
    public GameObject score;

   


    // Start is called before the first frame update
    void Start()
    {
       
        
       
    }
    void Update()
    {
        
        Score scorePoint = score.GetComponent<Score>();
        if(scorePoint.number > 2000)
        {
            Ap1();
        }
        if(scorePoint.number > 4000)
        {
            Ap2();
        }
   
    }


    void Ap1()
    {
        

        ap1.SetActive(false);
        ap2.SetActive(true);
    }  


    void Ap2()
    {
        ap2.SetActive(false);
        ap3.SetActive(true);
    }
  

  

    public void CharaDestroy()
    {
        Debug.Log("Destroyed");
       
        Invoke("ToGameOver", 2);
    }
    void ToGameOver()
    {
        Debug.Log("toGameOver");
        SceneManager.LoadScene("GameOver");
    }
   
}
