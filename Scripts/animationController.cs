using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{

    Animator pulpito;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        pulpito = gameObject.GetComponent<Animator>();
    }

    public void setPetting(){
        pulpito.SetTrigger("petting");
    }

    public void setEating(){
        pulpito.SetTrigger("eat");
    }
}
