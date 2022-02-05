using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOnBus : MonoBehaviour
{
    [SerializeField] private int busFare = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bus") && Input.GetKeyDown("space") && GlobalValues.coins >= busFare)
        {
            GlobalValues.coins -= busFare;
        }
    }
}
