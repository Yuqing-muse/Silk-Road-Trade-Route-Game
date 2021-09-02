using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform target;//定义目标（transform位置）
    public float distance = 5.0f;
    public float height = 5.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;
    public float distanceDampingX = 0.5f;
    public float distanceDampingZ = 0.2f;
    public float camSpeed = 2.0f;//摄像机移动速度
    public bool smoothed = true;//摄像机是否平滑

    private float wantedRotationAngle;//摄像机要到达的角度
    private float wantedHeight;      //要到达的位置
    private float wantedDistanceZ;   //要到达的Z轴位置
    private float wantedDistanceX;   //要到达的X轴位置

    private float currentRotationAngle;//摄像机当前角度
    private float currentHeight;   //摄像机当前高度
    private float currentDistanceZ;
    private float currentDistanceX;

    //public GameState gameState;
    private Quaternion currentRotation;

    void Awake()
    {
        //gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

	void LateUpdate()//执行比update延迟
    {
       // if (gameState .gameRunning)
        {
            if (!target)
        {
            return;
        }

        wantedRotationAngle = target.eulerAngles.y;//取得当前摄像机要到达的角度，绕y轴旋转//输出围绕坐标轴旋转
        wantedHeight = target.position.y + height;//获得摄像机要达到的高度
        wantedDistanceZ = target.position.z - distance;//获得摄像机要达到的z轴位置
        wantedDistanceX = target.position.x - distance;

        currentRotationAngle = transform.eulerAngles.y;//当前摄像机位置
        currentHeight = transform.position.y;
        currentDistanceZ = transform.position.z;
        currentDistanceX = transform.position.x;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle,rotationDamping * Time.deltaTime);

        currentHeight = Mathf.LerpAngle(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        currentDistanceZ = Mathf.LerpAngle(currentDistanceZ, wantedDistanceZ, distanceDampingZ * Time.deltaTime);
        currentDistanceX = Mathf.LerpAngle(currentDistanceX, wantedDistanceX, distanceDampingX * Time.deltaTime);

        currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        transform.position -= currentRotation * Vector3.forward * distance;

        transform.position = new Vector3(currentDistanceX, currentHeight, currentDistanceZ);

        LookAtMe();

        }
        


    }

    void LookAtMe()
    {
        if(smoothed)
        {
            Quaternion camRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, camRotation, Time.deltaTime * camSpeed);
        }
        else
        {
            transform.LookAt(target);

        }
        
    }
    



}
