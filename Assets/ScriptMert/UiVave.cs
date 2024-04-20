using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiVave : MonoBehaviour
{
    public float moveDistance = 3f; // Hareket mesafesi, varsayýlan olarak 3 birim
    public float moveDuration = 0.5f; // Hareket süresi, varsayýlan olarak 0.5 saniye

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.DOMoveX(transform.position.x + moveDistance, moveDuration);
        }

        
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.DOMoveX(transform.position.x - moveDistance, moveDuration);
        }
    }
}