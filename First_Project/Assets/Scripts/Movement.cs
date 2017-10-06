using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public float speed;
    public Text counter;
    public float time;
    public GameObject cubes; //fix
    private int count = 0;
    Rigidbody rb;

    void Start()
    {
        counter.text = "Count: " + count;
        rb = GetComponent<Rigidbody>();
        time = Time.time; //fix
    }

    // Update is called once per frame
    void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rb.AddForce(movement * speed);
        cubes.SetActive(true); //fix
	}

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        other.gameObject.SetActive(false); //fix
        count++;
        counter.text = "Count: " + count;
    }
}
