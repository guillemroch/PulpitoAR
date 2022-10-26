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
        Vector3 position = new Vector3(x, -2.45f, 7.08f);
        player.transform.position = position;
    }
}
