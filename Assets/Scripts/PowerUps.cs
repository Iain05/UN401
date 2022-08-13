using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, 0, 80.0f) * Time.deltaTime;
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < -8.0f) {
            Destroy(gameObject);
        }
    }
}
