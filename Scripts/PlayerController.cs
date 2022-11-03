using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Rigidbody2D playerRigid;

    [SerializeField]
    private GameObject gameCamera;

    private GameObject playerController;
    

    void Update()
    {
        playerController = GameObject.FindGameObjectWithTag("GameController");

        if(playerController != null && playerController.activeSelf)
        {
            player.SetActive(true);
            gameCamera.SetActive(true);
            moveCharacter();
        }
        else{
            player.SetActive(false);
            gameCamera.SetActive(true);
        }

    }

    void moveCharacter(){
        float x = playerController.transform.position[0];

        float offset = 0.3f;
        //Debug.Log("face position" + playerController.transform.position);
        
        
        /*
        if(player.transform.position[0] > 2.98f)
            x = 0.25f + offset;
        //    x = 2.22f + offset;
            

        if(player.transform.position[0] < 0.25f)   
            x = 2.98f + offset;
        //    x = 1.05f + offset;
        */
        
        
        playerRigid.MovePosition(new Vector2(x-offset, playerRigid.position[1]));

        Debug.Log("player position" + player.transform.position);
        
    }
}
