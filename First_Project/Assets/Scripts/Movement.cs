using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public float speed;
    public Text counter;
    public Text win;
    public float time;
    public GameObject[] cubes;
    private int count = 0;
    Rigidbody rb;

    void Start()
    {
        counter.text = "Count: " + count;
        rb = GetComponent<Rigidbody>();
        time = Time.time;
        cubes = GameObject.FindGameObjectsWithTag("Cubes");
        win.text = "";
    }

    // Update is called once per frame
    void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rb.AddForce(movement * speed);
        if (count == 12)
        {
            win.text = "You Win!";
        }
        if (Time.time - time > 12)
        {
            time = Time.time;
            count = 0;
            counter.text = "Count: " + count;
            for (int i = 0; i < cubes.Length; i++)
            {
                cubes[i].SetActive(true);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        count++;
        counter.text = "Count: " + count;
    }
}
