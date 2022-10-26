using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private GameObject playerController;

    void Update()
    {
        playerController = GameObject.FindGameObjectWithTag("GameController");

        if(playerController != null && playerController.activeSelf)
        {
            player.SetActive(true);
            moveCharacter();
        }
        else{
            player.SetActive(false);
        }

    }

    void moveCharacter(){
        float x = playerController.transform.position[0];

        float offset = 0.3f;
        Debug.Log("face position" + playerController.transform.position);
        
        if(player.transform.position[0] > 2.22f)
            x = 2.22f + offset;

        if(player.transform.position[0] < 1.05f)    
            x = 1.05f + offset;
        
        player.transform.position = new Vector3(x - offset, 3.76f, 0f);
        Debug.Log("player position" + player.transform.position);
        
    }
}
