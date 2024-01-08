using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
  public float minVelo = 0.1f;
  Rigidbody2D rb;
  private Vector3 lastMousePos;
  private Vector3 mouseVelo;
  private Collider2D col;
  public void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    col = GetComponent<Collider2D>();
  }
  private void Update()
  {
    col.enabled = isMovingMouse();
    SetBladeToMouse();
  }
  public void SetBladeToMouse()
  {
    var mousePos = Input.mousePosition;
    mousePos.z = 10;
    rb.position = Camera.main.ScreenToWorldPoint(mousePos);

  }
  public bool isMovingMouse()
  {
    Vector3 curMousePos = transform.position;
    float traveled = (lastMousePos - curMousePos).magnitude;
    lastMousePos = curMousePos;
    if (traveled > minVelo)
    {
      return true;
    }
    else
    {
      return false;
    }
  }
}
