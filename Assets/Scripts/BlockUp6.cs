﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockUp6 : MonoBehaviour {

    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Destroy(gameObject);
            if (collision.gameObject.name.Equals("Player1"))
            {
                GameObject.Find("Player1").GetComponent<PlayerInventory>().AddItem(5, 1);
            }


        }

    }

    void Pickup()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
