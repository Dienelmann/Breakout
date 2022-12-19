
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;
    public int ybrick = 1;
    public int xbrick = 1;
    public float cDistanc = 0.5f;
    public float spacing;
    private List<GameObject> bricks = new List<GameObject>();

    private void Start()
    {
        
        RefillSpawn();
        
    }


    /*public void Spawn()
    {
        for (int j = 0; j < ybrick; j++)
        {
            transform.position += Vector3.up;
            for (int i = 0; i < xbrick; i++)
            {
                Instantiate(brickPrefab, transform.position, Quaternion.identity);
                transform.position += Vector3.right;
                
            
            }

            transform.position += Vector3.left * xbrick;
            transform.position += Vector3.up * cDistanc;
        }

       
    }*/

    public void RefillSpawn()
    {
        foreach (GameObject brick in bricks)
        {
            Destroy(brick);
        }
        bricks.Clear();
        for (int i = 0; i < xbrick; i++)
        {
            for (int j = 0; j < ybrick; j++)
            {
                Vector2 spawnPos = (Vector2)transform.position + new Vector2(i * (brickPrefab.transform.localScale.x + cDistanc),
                    -j * (brickPrefab.transform.localScale.y + cDistanc));
                GameObject brick = Instantiate(brickPrefab, spawnPos, Quaternion.identity);
                bricks.Add((brickPrefab));
            } 
        }
    }
    public void RemoveBrick(Brick brick)
    {
        bricks.Remove(brick.gameObject);
        if (bricks.Count == 0)
        {
            RefillSpawn();
        }
    }

   
}
