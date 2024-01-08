using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  [SerializeField] GameObject[] ObjectsToSpawn;
  public GameObject bomb;
  [SerializeField] Transform[] spawnPlaces;
  public float minWait = 0.5f;
  public float maxWait = 1.5f;
  public float minForce = 9;
  public float maxForce = 15;
    void Start()
    {
    StartCoroutine(SpawnFruit());
    }

  private IEnumerator SpawnFruit()
  {
    while(true)
    {
      yield return new WaitForSeconds(Random.Range(minWait, maxWait));

      Transform t = spawnPlaces[Random.Range(0,spawnPlaces.Length)];
      GameObject go = null;
      float p = Random.Range(0, 100);
      if (p < 10)
      {
        go = bomb;
      }
      else
      {
        go = ObjectsToSpawn[Random.Range(0, ObjectsToSpawn.Length)];
      }

      GameObject fruit = Instantiate(go, t.position, t.rotation);
      fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce,maxForce), ForceMode2D.Impulse);
      
      Destroy(fruit,5f);
      //Debug.Log("Fruits Spawend!!");
    }
    
  }

}
