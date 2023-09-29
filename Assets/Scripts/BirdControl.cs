using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    //[SerializeField] protected Vector3 direction;
     GameObject obj;
    //[SerializeField] protected float speedFly = 7f;
    [SerializeField] protected float FlyPower = 6.4f;
    [SerializeField] protected GameController gameController;
    [SerializeField] protected AudioClip Fly;
    [SerializeField] protected AudioClip Die;
    [SerializeField] protected AudioClip Point;
    private AudioSource audioSource;
    private Animator anim;
    protected Rigidbody2D rb;
  
    void Start()
    {
        this.InitBird();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void InitBird()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = Fly;

        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower", 0);
    }
    // Update is called once per frame
    void Update()
    {
       this.FlyBird();
    }

    protected virtual void FlyBird()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    if (!gameController.GetComponent<GameController>().IsEndgame)
        //        audioSource.Play();
        //    obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, transform.position.y * FlyPower));
        //    obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, transform.position.y * speedFly);
        //    Debug.Log(transform.name + "fly", gameObject);

        //}
        if(Input.GetMouseButton(0))
        {
            if(!gameController.GetComponent<GameController>().IsEndgame)
            {
                audioSource.Play();
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FlyPower));
            }

        }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y * FlyPower );
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().GetPoint();
    }
    protected virtual void EndGame()
    {
        audioSource.clip = Die;
        audioSource.Play();
       gameController.GetComponent<GameController>().EndGame();
       
    }
}
