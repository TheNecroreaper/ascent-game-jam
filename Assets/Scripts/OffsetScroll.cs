using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScroll : MonoBehaviour {

    private Renderer quadRenderer;
    float stopWatch;
    public static float scrollSpeed = 0.1f;
    Vector3 player1Position, player2Position;
    public Vector2 textureOffset;
    GameObject player1, player2;


    void Start()
    {
        quadRenderer = gameObject.GetComponent<Renderer>();
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    void Update()
    {
        if (!Pause_Menu.gameIsPaused)
        {
            scrollSpeed = ((getYDistanceBetweenPlayers() / 2) + 1) * 0.001f;
            textureOffset = new Vector2(0, quadRenderer.material.mainTextureOffset.y + scrollSpeed);
            quadRenderer.material.mainTextureOffset = textureOffset;
        }
    }
    private void FixedUpdate()
    {
        scrollSpeed = (((getYDistanceBetweenPlayers() / 2) + 1) * 0.001f);
        float newXCoordinate = quadRenderer.material.mainTextureOffset.y + scrollSpeed;
        textureOffset = new Vector2(0, newXCoordinate);
        quadRenderer.material.mainTextureOffset = textureOffset;
    }

    float getYDistanceBetweenPlayers()
    {
        float player1YPosition = player1.transform.position.y;
        float player2YPosition = player2.transform.position.y;

        return Mathf.Abs(player1YPosition - player2YPosition);
    }
}
