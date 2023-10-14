using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
  public float rotationSpeed = 90f; 
	public GameObject collectPart;

  private void Update()
  {
    transform.Rotate(0f,0f, rotationSpeed * Time.deltaTime);
  }

	public void PickUpCoin()
  {
    GameObject collectParticle = Instantiate(collectPart, transform.position, transform.rotation);
    Destroy(collectParticle,1f);
    Destroy(gameObject);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player") {
			PickUpCoin();
		}
  }
}
