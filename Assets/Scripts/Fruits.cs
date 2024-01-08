using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
  [SerializeField] GameObject SlicedFruitPrefeb;
  
   public void CreateCutFruit()
  {
    GameObject inst=Instantiate(SlicedFruitPrefeb, transform.position, transform.rotation);
    //Play Slice sound here
    FindObjectOfType<GameManager>().GetRandomSliceSound();

    Rigidbody[] rbSliced=inst.transform.GetComponentsInChildren<Rigidbody>();
    foreach(Rigidbody r in rbSliced)
    {
      r.transform.rotation=Random.rotation;
      r.AddExplosionForce(Random.Range(350, 900), transform.position, 3.5f);
    }

    FindObjectOfType<GameManager>().IncreaseScore(2);
    FindObjectOfType<GameManager>().getScore();

    Destroy(inst.gameObject, 4f);
    Destroy(gameObject);
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    Blade b =collision.GetComponent<Blade>();
    if(!b) return;
    CreateCutFruit();
  }
}
