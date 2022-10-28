using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Diagnostics;

public class InteractionSystem : MonoBehaviour
{
    
    [SerializeField] private Camera mainCamera;

    [SerializeField] private Camera secondCamera;

    private Animator playerAnimation;

    private Inputs inputs;

    private System.Diagnostics.Stopwatch sw;

    private void Awake() {
        inputs = new Inputs();
        sw = new Stopwatch();
    }

    private void OnEnable() {
        inputs.Enable();
        sw.Start();
    }

    private void OnDisable() {
        inputs.Disable();
    }

    private void DetectObject() {
        Ray ray = mainCamera.ScreenPointToRay(inputs.Interaction.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            if (hit.collider != null) {
                
                Vector2 pet = inputs.Interaction.Pet.ReadValue<Vector2>();
                if(pet[0] > 0 || pet[1] > 0){
                    UnityEngine.Debug.Log("Petting");
                    //if(playerAnimation.GetBool("isPoked") == false)
                    playerAnimation.SetTrigger("IsPet");
                    sw.Restart();
                }
                else{
                    UnityEngine.Debug.Log(hit.collider);
                    playerAnimation.SetTrigger("IsPoked");
                    sw.Restart();
                }    
            }
        }
    }

    private void Update() {
        if(inputs.Interaction.Poke.ReadValue<float>() > 0f){
            DetectObject();
        }
        double time = sw.Elapsed.TotalMilliseconds/1000;
        UnityEngine.Debug.Log($"Tiempo: {time} ms");

        if(time >= 10){
            sleep();
        }
    }

    public void setAnimator(){
        playerAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void sleep(){
        playerAnimation.SetTrigger("Sleep");
    }

}
