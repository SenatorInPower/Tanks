using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BallAtack : MonoBehaviour
{
    [SerializeField]
    private GameObject Ball;
    [SerializeField]
    private int ballCountSpawn=10;
    private List<BallLogic> spawnBall= new List<BallLogic>();
    void CreateListBall()
    {
        for (int i=0; i<ballCountSpawn; i++)
        {
            GameObject inst= Instantiate(Ball);
            inst.SetActive(false);
            spawnBall.Add(inst.GetComponent<BallLogic>());
        }
    }

}
