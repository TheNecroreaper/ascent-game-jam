using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Threading;

public class CreatePowerUp : MonoBehaviour {

    // Use this for initialization

    public Vector2 size;
    public GameObject BlockSmall;
    public GameObject BlockMedium;
    public GameObject BlockLarge;
    public GameObject LaserSmall;
    public GameObject LaserMedium;
    public GameObject LaserLarge;
    public GameObject EraserPickUp;
    public GameObject Jump;
    public GameObject Up;

    public float interval;
    public System.Random rand;

    public CreatePowerUp()
    {
        

    }


	void Start () {
        /*System.Timers.Timer aTimer;
        aTimer = new System.Timers.Timer(2000);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;*/
        rand = new System.Random();
        interval = 5;
        //var t = new Timer();
       
        /*t.Tick += TimerEventProcessor;
        t.Interval = 300;
        t.Start();*/
        

    }


    public void TimerEventProcessor(Object source, ElapsedEventArgs e)
    {
        
        //aTimer.Interval = Random.Range(10000, 15000);
    }
	
	// Update is called once per frame
	void Update () {


        if (interval > 0)
        {
            interval -= Time.deltaTime;
        }
        else
        {
            Vector2 pos = new Vector2(rand.Next(-4, 5), rand.Next(-6, 5));
            switch (rand.Next(1, 9))
            {
                default:
                    break;
                case 1:
                    Instantiate(Up, pos, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Jump, pos, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(BlockSmall, pos, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(BlockMedium, pos, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(BlockLarge, pos, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(LaserSmall, pos, Quaternion.identity);
                    break;
                case 7:
                    Instantiate(LaserMedium, pos, Quaternion.identity);
                    break;
                case 8:
                    Instantiate(LaserLarge, pos, Quaternion.identity);
                    break;
                case 9:
                    Instantiate(EraserPickUp, pos, Quaternion.identity);
                    break;

            }
            interval = rand.Next(4,5);

        }

    }
}
