using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public Text counter;

	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(horizontal, 0.0f, vertical);
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        counter.text = "hi";
    }
}
