using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float screenWidth;
    private float prev_speed;
    private float add_speed;
    private int goalCoin;
    private static int max_coin;

    public static float speed = 8f;
    public int coinGet;

    // Start is called before the first frame update
    void Start() {

        screenWidth = Screen.width;
        add_speed = 0f;

        coinGet = 0;
        goalCoin = 10;

    }

    // Update is called once per frame
    void Update()
    {
        //Computer controls
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -1.5f)
            transform.position += Vector3.left * 1f;

        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 1.5f)
            transform.position += Vector3.right * 1f;


        //Mobile controls
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).position.x < screenWidth / 2f && Input.GetTouch(i).phase == TouchPhase.Ended && transform.position.x > -1.5f)
                transform.position -= Vector3.right * 1f;
            if (Input.GetTouch(i).position.x > screenWidth / 2f && Input.GetTouch(i).phase == TouchPhase.Ended && transform.position.x < 1.5f)
                transform.position += Vector3.right * 1f;
        }
    }

    private void OnTriggerEnter(Collider other){

        if(other.GetComponentInChildren<Transform>().tag == "Obstacle"){

            Destroy(other.gameObject);

        }

    }

}
