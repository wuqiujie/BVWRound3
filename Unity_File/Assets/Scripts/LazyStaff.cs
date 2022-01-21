using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyStaff : MonoBehaviour
{
    int playerLayer;
	Lazy_Num num;
	private void Start()
	{

		playerLayer = LayerMask.NameToLayer("Player");
		num = GetComponent<Lazy_Num>();
	}
	//find the lazy staff
	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.gameObject.layer == playerLayer)
		{
			gameObject.SetActive(false);
			num.Increase_num();
			//AudioManager.PlayOrbAudio();
		}
	}
}
