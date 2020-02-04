using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMonster : MonoBehaviour {



    public float speed = 3f;
    private Rigidbody _rigidbody;
    public TextboxManager t_m;

    public bool canMove;

    

    void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        t_m = FindObjectOfType<TextboxManager>();
        canMove = false;
    }


	
	// Update is called once per frame
	void Update ()
    {
        if(t_m.makeStuffHappen)
            canMove = true;

        if(canMove)
            Movement();
    }

    void Movement()
    {

            Vector3 moveDirection = Vector3.zero;

            moveDirection += Vector3.back;

            _rigidbody.MovePosition(this.transform.position + (moveDirection * Time.deltaTime * speed));
    }

    void OnTriggerEnter(Collider other)
    {
        if(t_m.makeStuffHappen && other.CompareTag("Player"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
