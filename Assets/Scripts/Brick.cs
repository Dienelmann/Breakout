
using UnityEngine;

public class Brick : MonoBehaviour
{
    private static int instanceCount;

    private void Awake()
    {
        instanceCount++;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        instanceCount--;

        if (instanceCount <= 0)
        {
            print(message: "Level Completed!");
        }

        Destroy(gameObject);
        FindObjectOfType<BrickSpawner>().RemoveBrick(this);
    }
}
