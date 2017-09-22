using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public Text counter;
    public int count = 0;

    private void Start()
    {
        counter.text = "Count: " + count;
    }

    // Update is called once per frame
    void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(horizontal, 0.0f, vertical);
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        count++;
        counter.text = "Count: " + count;
    }
}
