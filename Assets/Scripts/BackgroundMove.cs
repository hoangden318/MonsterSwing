using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : HoangBehavior
{

   [SerializeField] protected float moveSpeed = 5f;
   [SerializeField] protected float moveRange = 23.01f;

   [SerializeField] protected Vector3 startPs;
   [SerializeField] protected Transform bg;
    // Start is called before the first frame update

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBackGround();
    }

    protected virtual void LoadBackGround()
    {
        if (this.bg != null) return;
        this.bg = transform.Find("BackGround");
        Debug.Log(transform.name + "Load BG", gameObject);
    }
    void Start()
    {
       this.LoadGame();
    }

    protected virtual void LoadGame()
    {
        //bg = gameObject;
        startPs = bg.transform.position;
        moveSpeed = 5;
        moveRange = 23.01f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       this.MoveBackGround();
    }

    protected virtual void MoveBackGround()
    {
        bg.transform.Translate(new Vector3(-1 * Time.fixedDeltaTime * moveSpeed, transform.position.y, 0f));

        if (Vector3.Distance(startPs, bg.transform.position) > moveRange)
        {
            bg.transform.position = startPs;
        }
    }
}
