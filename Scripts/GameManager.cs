using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject platforms;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private GameObject tutorial;

    [SerializeField]
    private LevelGenerator lg;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject gameCamera;

    [SerializeField]
    private GameObject dummyPlatform;

    private int currentState = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentState = 0;
        Tutorial();
    }
    
    public void Tutorial(){
        tutorial.SetActive(true);
        player.GetComponent<Rigidbody2D>().simulated = false;
    }

    public void StartGame(){
        currentState = 1;
        dummyPlatform.SetActive(false);
        tutorial.SetActive(false);
        gameOver.SetActive(false);
        player.GetComponent<Rigidbody2D>().simulated = true;
        player.transform.position = new Vector3(1.6789f, 2.9822f, 2.3871f);
        gameCamera.transform.position = new Vector3(1.693189f, 3.667591f, 3.58f);        
        lg.generateLevel();
        player.SetActive(true);
        
    }

    // Update is called once per frame
    public void GameOver(){
        if(currentState == 1){
            currentState = 2;
            
            int num = platforms.transform.childCount;
            for(int i = num - 1; i >= 0; i--)
            {
                GameObject.Destroy(platforms.transform.GetChild(i).gameObject);
            }
            gameOver.SetActive(true);
        }
    }

    public void exit(){
        SceneManager.LoadScene (sceneBuildIndex:0);
    }
}
