using UnityEngine;

public partial class BallAtack : MonoBehaviour
{

    byte countShut = 0;
    public void Atack(Vector3 target,short damage,short distanse)
    {
        countShut++;
        ResetPosBall(startPoint);
        spawnBall[countShut].gameObject.SetActive(true);
        spawnBall[countShut].Shut(target, damage, distanse);
        if (countShut - 1 > ballCountSpawn)
        {
            countShut = 0;
        }
    }
    private void ResetPosBall(Transform pos)
    {
        spawnBall[countShut].transform.position = pos.position;
        spawnBall[countShut].transform.rotation = pos.rotation;
        //spawnBall[countShut].isKinematic = true;
        //spawnBall[countShut].isKinematic = false;
    }
 
}
