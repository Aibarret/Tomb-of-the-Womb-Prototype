using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Gamer gameManager;
    public GameObject game;

    private bool acting = false;

    private void Start()
    {
        gameManager = game.GetComponent<Gamer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (acting)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

                if (gameManager.checkSpace((int)transform.position.x, ((int)transform.position.y + 1) * -1))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1);
                    endPhase();
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (gameManager.checkSpace((int)transform.position.x, ((int)transform.position.y - 1) * -1))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 1);
                    endPhase();
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (gameManager.checkSpace((int)transform.position.x - 1, ((int)transform.position.y) * -1))
                {
                    transform.position = new Vector3(transform.position.x - 1, transform.position.y);
                    endPhase();
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (gameManager.checkSpace((int)transform.position.x + 1, ((int)transform.position.y) * -1))
                {
                    transform.position = new Vector3(transform.position.x + 1, transform.position.y);
                    endPhase();
                }
            }
        }
    }

    public void startPhase()
    {
        acting = true;
    }

    public void endPhase()
    {
        acting = false;
        gameManager.resolvePhase();
    }
}
