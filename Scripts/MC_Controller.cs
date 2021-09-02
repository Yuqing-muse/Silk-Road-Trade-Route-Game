using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Controller : MonoBehaviour {

    public bool isKeyDownA = false;
    public bool isKeyDownW = false;
    public bool isKeyDownS = false; 
    public bool isKeyDownD = false;

    public animController animc;

    public float gravity = 20.0f;

    public float rollSpeed = 2.0f;//物体移动速度
    public float rotateSpeed = 2.0f;
    public CharacterController controller;//角色控制器

    private float moveHorz = 0.0f;
    private Vector3 moveDirection = Vector3.zero;//物体移动的方向
    private Vector3 rotateDirection = Vector3.zero;//旋转的速度S

    private bool grounded = false;//是否在地面上

	// Use this for initialization
	void Start () {
        controller = this.GetComponent<CharacterController>();
        animc = this.GetComponent<animController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
        {
            isKeyDownW = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            isKeyDownA = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            isKeyDownD = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            isKeyDownS = true;;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            isKeyDownW = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            isKeyDownA = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            isKeyDownD = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            isKeyDownS = false;
        }

        if(isKeyDownS|| isKeyDownW|| isKeyDownA|| isKeyDownD)
        {
            animc.state = 2;
        }

        if(!isKeyDownS && !isKeyDownW && !isKeyDownA && !isKeyDownD)
        {
            animc.state = 1;
        }
    }
    public void RunAnimatorOpen(Vector2 weizhi)
    {
       
        if (weizhi.y != 0 || weizhi.x != 0)
        {
            animc.state = 2;
        }
    

}
    public void RunAnimatorStop()
    {
        
            animc.state = 1;
        
    }
    void FixedUpdate()
    {
        if (grounded)//物体在地面上
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            moveDirection = new Vector3(h, 0, v);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= rollSpeed;

            moveHorz = Input.GetAxis("Horizontal");
            if (moveHorz > 0)
                rotateDirection = new Vector3(0, 1, 0);
            else if (moveHorz < 0)
                rotateDirection = new Vector3(0, -1, 0);
            else
                rotateDirection = new Vector3(0, 0, 0);
        }

        moveDirection.y -= gravity * Time.deltaTime;

        CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
        controller.transform.Rotate(rotateDirection * Time.deltaTime,rotateSpeed);

        grounded = ((flags & CollisionFlags.CollidedBelow) != 0);

    }
}
