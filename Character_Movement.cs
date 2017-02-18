using UnityEngine;
using System.Collections;

public class Character_Movement : MonoBehaviour {
    const int SPEED = 100, ROTATION_SPEED = 50, JUMP = 300;
	
	// Update is called once per frame
	void Update () {
        Movement();
    }

    void Movement() {
        if (Input.GetKeyDown(KeyCode.W)) { StartCoroutine(Walk_Forwards()); }
        if (Input.GetKeyDown(KeyCode.S)) { StartCoroutine(Walk_Backwards()); }
        if (Input.GetKeyDown(KeyCode.A)) { StartCoroutine(Rotate_Left()); }
        if (Input.GetKeyDown(KeyCode.D)) { StartCoroutine(Rotate_Right()); }
        if (Input.GetKeyDown(KeyCode.Space)) { StartCoroutine(Jump()); }
    }

    IEnumerator Walk_Forwards() {
        StopCoroutine(Walk_Backwards());
        while (Input.GetKeyUp(KeyCode.W) != true)
            transform.Translate(Vector3.forward * Time.deltaTime * SPEED);
        yield return null;
    }

    IEnumerator Walk_Backwards() {
        StopCoroutine(Walk_Forwards());
        while (Input.GetKeyUp(KeyCode.S) != true)
            transform.Translate(Vector3.back * Time.deltaTime * SPEED);
        yield return null;
    }

    IEnumerator Rotate_Left() {
        StopCoroutine(Rotate_Right());
        while (Input.GetKeyUp(KeyCode.A) != true)
            transform.Rotate(Vector3.down, Time.deltaTime * ROTATION_SPEED);
        yield return null;
    }

    IEnumerator Rotate_Right() {
        StopCoroutine(Rotate_Left());
        while (Input.GetKeyUp(KeyCode.D) != true)
            transform.Rotate(Vector3.up, Time.deltaTime * ROTATION_SPEED);
        yield return null;
    }

    IEnumerator Jump() {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, JUMP, gameObject.GetComponent<Rigidbody>().velocity.z);
        yield return null;
    }
}
