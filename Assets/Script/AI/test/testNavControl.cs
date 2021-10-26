using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

public class testNavControl : MonoBehaviour
{
    public GameObject inst;
    public Input Button;
    public NavMeshAgent hiro;
    public BoxCollider bounse;
    [Button]
    void BoxLenght()
    {
        print(bounse.bounds.center);
        print(bounse.bounds.min);
        print(bounse.bounds.max);
     
    }
    GameObject instGame;
   
    [Button]
    void Range()
    {
        Vector3 vectRendom = new Vector3(Random.Range(bounse.bounds.min.x, bounse.bounds.max.x), transform.position.y, Random.Range(bounse.bounds.min.z, bounse.bounds.max.z));
        if (instGame)
        {
            Destroy(instGame);
        }
        instGame= Instantiate(inst, vectRendom, Quaternion.identity);
    }
    [Button]
    void SetNavPos(Vector3 setPos)
    {
        hiro.SetDestination(instGame.transform.position);
    }
}
