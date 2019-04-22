using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class PlayerInventory : MonoBehaviour {

    public Text[] platformText = new Text[7];
    public Image[] selectionImages = new Image[7];
    public int[] platformsCount = {10, 0, 0, 0, 0, 0, 5};

    public int currentSelection = 0 ;
	// Use this for initialization
	void Start () {
        ChangeSelection();
        for(int i = 0; i < platformText.Length; i++)
        {
            platformText[i].text = platformsCount[i].ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
        UpdateSelection();
        ChangeSelection();
    }

    void UpdateSelection()
    {
        if (Input.GetKeyDown("1"))
        {
            selectionImages[currentSelection].GetComponent<Outline>().effectColor = Color.white;
            currentSelection = 0;
        }
        else if (Input.GetKeyDown("2"))
        {
            selectionImages[currentSelection].GetComponent<Outline>().effectColor = Color.white;
            currentSelection = 1;
        }
        else if (Input.GetKeyDown("3"))
        {
            selectionImages[currentSelection].GetComponent<Outline>().effectColor = Color.white; 
            currentSelection = 2;
        }
        else if (Input.GetKeyDown("4"))
        {
            selectionImages[currentSelection].GetComponent<Outline>().effectColor = Color.white;
            currentSelection = 3;
        }
        else if (Input.GetKeyDown("5"))
        {
            selectionImages[currentSelection].GetComponent<Outline>().effectColor = Color.white;
            currentSelection = 4;
        }
        else if (Input.GetKeyDown("6"))
        {
            selectionImages[currentSelection].GetComponent<Outline>().effectColor = Color.white;
            currentSelection = 5;
        }
        else if (Input.GetKeyDown("7"))
        {
            selectionImages[currentSelection].GetComponent<Outline>().effectColor = Color.white;
            currentSelection = 6;
        }
    }

    void ChangeSelection()
    {
        selectionImages[currentSelection].GetComponent<Outline>().effectColor = Color.red;

    }

    public void AddItem(int type, int countInc)
    {
            platformsCount[type] += 5;
            int count = 0;
            string countText = platformText[0].text;
            Int32.TryParse(countText, out count);
            count += countInc;
            platformText[type].text = count.ToString();
            platformsCount[type] = count;
    }

    public bool EmptySelection()
    {
        if (platformsCount[currentSelection] == 0)
            return true;
        return false;
    }
    public void RemoveItem(int amount)
    {
        int count = 0;
        string countText = platformText[currentSelection].text;
        Int32.TryParse(countText, out count);
        count -= amount;
        platformText[currentSelection].text = count.ToString();
        platformsCount[currentSelection] = count;
    }
}
