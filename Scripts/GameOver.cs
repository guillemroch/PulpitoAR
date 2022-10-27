using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent m_gameOver;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Game Over Entered");
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        Debug.Log(rb);
        if (rb != null)
            m_gameOver.Invoke();
    }
}
