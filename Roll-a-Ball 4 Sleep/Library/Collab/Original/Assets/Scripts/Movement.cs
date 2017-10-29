using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum CollisionType{Door, Cubes};

public class Movement : MonoBehaviour {
	public CollisionType collisionType;
    public float speed;
	public static int userMins;
    public Text counter;
	public Text timeCounter;
    public Text win;
	public Text incorrect1;
	public Text incorrect2;
	public Text incorrect3;
	public Text question;
	public Text answers;
	public Text A;
	public Text B;
	public Text C;
	public Text D;
	public bool go;
	public int respawn;
    public float time;
	public int hr;
	public int min;
	public List<CollisionType> tags;
    public GameObject[] cubes;
    private int count = 0;
    Rigidbody rb;

    void Start()
    {
        counter.text = "Count: " + count + "\nTime left: " + respawn;
        rb = GetComponent<Rigidbody>();
        time = Time.time;
        cubes = GameObject.FindGameObjectsWithTag("Cubes");
		min = (System.DateTime.Now.Hour * 60) + System.DateTime.Now.Minute;
		if (userMins == 0)
			userMins = 22 * 60;
//		incorrect1.enabled = false;
//		incorrect2.enabled = false;
//		incorrect3.enabled = false;
//		question.enabled = false;
//		answers.enabled = false;
//		A.enabled = false;
//		B.enabled = false;
//		C.enabled = false;
//		D.enabled = false;
		go = true;
    }

    // Update is called once per frame
    void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
		rb.AddForce (movement * speed);
		if (userMins - min <= 30 || System.DateTime.Now.Hour < -1) {
			respawn = 3;
			win.text = "Its past your bedtime! Go to bed";
		}
		if (rb.transform.position.ToString() != "(0.0, 0.5, 0.0)") {
			go = false;
			if (count == 12) {
				win.text = "Congrats";
				question.enabled = true;
				answers.enabled = true;
				A.enabled = true;
				B.enabled = true;
				C.enabled = true;
				D.enabled = true;
			} else if (Time.time - time > respawn) {
				time = Time.time;
				count = 0;
				for (int i = 0; i < cubes.Length; i++) {
					cubes [i].SetActive (true);
				}
			}
		} else if (go) {
			time = Time.time;
		}
		counter.text = "Count: " + count;
		if ((time - Time.time + respawn) > 0) {
			string tim2 = string.Format ("{0:0.00}", time - Time.time + respawn);
			timeCounter.text = "Time left: " + tim2;
		}
	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Cubes") {
			other.gameObject.SetActive (false);
			count++;
			counter.text = "Count: " + count;
		} else if (other.gameObject.tag == "GooDoor") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		} else if (other.gameObject.tag == "PooDoor1" && count == 12) {
			incorrect1.enabled = true;
		} else if (other.gameObject.tag == "PooDoor2" && count == 12) {
			incorrect2.enabled = true;
		} else if (other.gameObject.tag == "PooDoor3" && count == 12) {
			incorrect3.enabled = true;
		}
    }
}
