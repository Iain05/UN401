using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    public GameObject projectilePrefab;
    public GameObject explosionPrefab;
    public GameObject healthUI;

    public Animator animator;

    public float speed = 5.0f;
    public float limitX = 8.2f;
    public float limitY = 4.2f;

    public float multishotTime = 5.0f;
    public bool hasMultishot = false;

    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthUI.GetComponent<TextMeshProUGUI>().text="Health: " + health;
        
        Move();

        Shoot();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag =="Enemy") {
            health = health - 1;
            Destroy(coll.gameObject);
            if (health <= 0) {
                Destroy(gameObject);
                Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
            }
        } else if (coll.gameObject.tag == "Pow_HP") {
            if (health < 5) {
                health = health + 1;
            }
            Destroy(coll.gameObject);
        } else if (coll.gameObject.tag == "Pow_MS") {
            Destroy(coll.gameObject);
            hasMultishot = true;
            Invoke("StopMultishot", multishotTime);
        }
    }

    void Move() {
        if (Input.GetKey(KeyCode.W) && transform.position.y < limitY) {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -limitX) { 
            transform.Translate(Vector2.left * speed * Time.deltaTime); 
            animator.SetBool("moveLeft", true);
        } else {
            animator.SetBool("moveLeft", false);
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > -limitY) { 
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < limitX) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetBool("moveRight", true);
        } else {
            animator.SetBool("moveRight", false);
        }
    }

    void Shoot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(projectilePrefab, transform.position + (Vector3.up/2), Quaternion.identity);
            if (hasMultishot == true) {
                Instantiate(projectilePrefab, transform.position + (Vector3.left/2) + (Vector3.down/2), Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + (Vector3.right/2) + (Vector3.down/2), Quaternion.identity);
            }
        }
    }

    void StopMultishot() {
        hasMultishot = false;
    }
}
