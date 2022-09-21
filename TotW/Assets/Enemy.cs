using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Gamer gameManager;
    public GameObject game;
    public GameObject targetPrefab;

    public Vector3 target;

    private GameObject[] targets = new GameObject[20];
    private int targetCount = 0;

    private void Start()
    {
        gameManager = game.GetComponent<Gamer>();
    }

    public void makePlan()
    {
        spawnTargetAt(target);
        spawnTargetAt(new Vector3(target.x, target.y + 1));
        spawnTargetAt(new Vector3(target.x, target.y - 1));
        spawnTargetAt(new Vector3(target.x + 1, target.y));
        spawnTargetAt(new Vector3(target.x - 1, target.y));
    }

    public void resolveAction(){
        clearTargets();
    }

    public void spawnTargetAt(Vector3 posn)
    {
        if (gameManager.checkSpace((int)posn.x, (int)posn.y * -1)){
            GameObject newEnemy = Instantiate(targetPrefab, posn, Quaternion.identity);
            targets[targetCount] = newEnemy;
            targetCount++;
        }
    }

    public void clearTargets(){
        int count = 0;
        while (count < targetCount){
            GameObject.Destroy(targets[count]);
            targets[count] = null;
            count++;
        }
        targetCount = 0;
    }

    
}
