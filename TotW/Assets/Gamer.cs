using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : MonoBehaviour
{
    public int TILESIZE = 1;
    public int[,] grid = new int[16, 10];
    public GameObject player;
    public GameObject[] enemies;

    private void Start()
    {
        //Initialize the Grid
        int x = 0;
        int y = 0;
        while (y < 10)
        {
            x = 0;
            while (x < 16)
            {
                grid[x, y] = 0;
                x++;
            }
            y++;
        }

        // Filling in Walls
        x = 0;
        y = 0;
        while (x < 16)
        {
            grid[x, 0] = 1;
            x++;
        }

        x = 0;
        y = 0;
        while (x < 16)
        {
            grid[x, 9] = 1;
            x++;
        }

        x = 0;
        y = 0;
        while (y < 9)
        {
            grid[0, y] = 1;
            y++;
        }

        x = 0;
        y = 0;
        while (y < 10)
        {
            grid[15, y] = 1;
            y++;
        }

        player.transform.position = new Vector3(5, -5, 0);
        planPhase();
    }

    // Game Functions

    public void planPhase()
    {
        int i = 0;
        while (i < enemies.Length)
        {
            enemies[i].GetComponent<Enemy>().makePlan();
            i++;
        }
        actPhase();
    }

    public void actPhase()
    {
        player.GetComponent<Player>().startPhase();
    }

    public void resolvePhase()
    {
        int i = 0;
        while (i < enemies.Length)
        {
            enemies[i].GetComponent<Enemy>().resolveAction();
            i++;
        }
        planPhase();
    }

    public bool checkSpace(int x, int y)
    {
        if (grid[x,y] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public void printGrid()
    {
        int x = 0;
        int y = 0;

        while (y < 9)
        {
            x = 0;
            while (x < 16)
            {
                Debug.Log(grid[x, y]);
                x++;
            }
            y++;
        }
    }
}
