using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.forward = -player.transform.forward;
    }
}
