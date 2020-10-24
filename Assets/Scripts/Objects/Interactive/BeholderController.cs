using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderController : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float normalDrag;
    [SerializeField]
    private float stopDrag;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponentInChildren<WakingSight>().activeMode == 1) {
            rigidbody2D.drag = normalDrag;
            Vector2 direction = (player.transform.position - this.transform.position).normalized;
            rigidbody2D.AddForce(new Vector3((direction * this.acceleration).x, (direction * this.acceleration).y));
        } else {
            rigidbody2D.drag = stopDrag;
        }
    }
}
