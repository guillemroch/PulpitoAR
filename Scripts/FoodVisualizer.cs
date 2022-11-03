using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public class FoodVisualizer : MonoBehaviour
{

    [SerializeField] List<GameObject> food;

    private System.Diagnostics.Stopwatch sw;

    int current = 0;

    private void Awake() {
        sw = new Stopwatch();
    }

    private void OnEnable() {

        sw.Start();
        
        for (int i = 0; i < food.Count ; i++)
            food[i].SetActive(false);

        food[current].SetActive(true);
    }

    private void OnDisable() {
        
    }
    
    public void nextFood(){
        double time = sw.Elapsed.TotalMilliseconds/1000;

        if(time > 0.5){
        if (current == food.Count - 1)
            current = 0;
        else
        current++;    

        for (int i = 0; i < food.Count ; i++)
            food[i].SetActive(false);

        //food[current].transform.GetComponent<Animation>().Stop();
        food[current].SetActive(true);
        sw.Restart();
        }
    }

    public void previousFood(){
        double time = sw.Elapsed.TotalMilliseconds/1000;

        if(time > 0.5){
        if (current == 0)
            current = food.Count - 1;
        else
            current--;

        for (int i = 0; i < food.Count ; i++)
            food[i].SetActive(false);

        //food[current].transform.GetComponent<Animation>().Stop();
        //food[current].transform.GetComponent<Animation>().Rewind(); 
        food[current].SetActive(true);
        sw.Restart();
        }
    }
}
