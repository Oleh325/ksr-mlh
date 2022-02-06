using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{

    [SerializeField] private GameObject endpoint;
    [SerializeField] private float speed = 1f;

    
    {
        if ()
        {
            transform.position = Vector2.MoveTowards(transform.position, endpoint.transform.position, Time.deltaTime * speed);
        }
    }

}
