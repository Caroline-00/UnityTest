using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARShootBall : MonoBehaviour
{
    // 申请变量
    // 设置给小球向前的力的大小
    public float FwdForce = 200f;
    // 设置夹角的参照数值
    public Vector3 StanTra = new Vector3(0, 1f, 0);

    //判断手指是否碰触到了精灵球的位置
    private bool blTouched = false;
    // 判断精灵球是否发射
    private bool blShooted = false;
    // 手指滑动的起始点
    private Vector3 startPositon;
    // 手指滑动的终点
    private Vector3 endPosition;
    // 记录手指滑动的距离
    private float disFick;
    // 记录手指滑动的偏移向量
    private Vector3 offset;
    // 用帧数来记录手指滑动的时间，使用帧数来记录，所以使用int类型
    private int timeFlick;
    // 记录滑动的速度
    private float speedFlick;
    //记录主摄像机
    private Camera camera;

    // Use this for initialization
    void Start()
    {
        // 赋值为主摄像机
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (blTouched) //如果按在小球上 允许计算手指滑动
        {
            slip();
        }
    }

    // 因为小球发射完了还需要新的，因此需要重置参数
    private void resetVari()
    {
        // 起始位置设置为手指按下的位置
        startPositon = Input.mousePosition;
        // 终止位置设置为手指按下的位置
        endPosition = Input.mousePosition;
    }

    // 手指（鼠标）按下的位置是否是精灵球的位置（即是否碰触到脚本挂载物体）
    void OnMouseDown()
    {
        if (blShooted == false)   // 精灵球尚未发射
        {
            blTouched = true;   // 允许检测手指滑动，在Update函数中进行
        }
    }

    //计算手指的滑动
    private void slip()
    {

        timeFlick += 25;  // 时间每帧增加25，为了得到速度的参数        
        if (Input.GetMouseButtonDown(0))  //当手指按下的时候，应该重置所有参数
        {
            resetVari(); //重置参数
        }
        if (Input.GetMouseButton(0)) // 当手指一直按在屏幕上的时候
        {
            endPosition = Input.mousePosition;  // 把手指的终点位置变量赋值刷新为当前手指所处的位置，因为手指滑动是屏幕向量，但是精灵球发射是世界向量
            offset = camera.transform.rotation * (endPosition - startPositon);  // 获取手指在世界坐标上的偏移向量            
            disFick = Vector3.Distance(startPositon, endPosition);  // 计算手指滑动的距离            
        }
        if (Input.GetMouseButtonUp(0))
        {
            speedFlick = disFick / timeFlick;
            //计算滑动的速度
            blTouched = false;
            //手指是否碰触到精灵球 设置为否
            timeFlick = 0;
            //时间记录归零
            if (disFick > 20 && endPosition.y - startPositon.y > 0)  //如果手指移动距离大于20且在方向是向上滑动
            {
                shootBall();  // 发射精灵球                
            }
        }
    }

    //发射精灵球
    private void shootBall()
    {
        // 给精灵球增加刚体组件
        transform.gameObject.AddComponent<Rigidbody>();
        // 用局部变量获取刚体组件
        Rigidbody _rigBall = transform.GetComponent<Rigidbody>();
        // 给精灵球一个初始速度  这个速度等于方向（单位向量）乘以速度
        // 精灵球滑动的距离只和初速度有关，和滑动的距离无关，使用的方法和生成随机坐标时候的单位向量一样，只获取方向，不需要大小
        _rigBall.velocity = offset.normalized * speedFlick;
        // 给精灵球一个向着屏幕前方的力
        _rigBall.AddForce(camera.transform.forward * FwdForce);
        // 让精灵球旋转起来
        _rigBall.AddTorque(transform.right);
        // 设置精灵球的阻力
        _rigBall.drag = 0.5f;
        // 这个精灵球已经发射出去了
        blShooted = true;
        // 让这个发射出去的精灵球脱离父级物体
        transform.parent = null;
        // 发射后减少精灵球的数量
        StaticData.BallNum--;
        //更新精灵球数量在UI中的显示
        ARUI_Mgr.Instance.UpdateUIBallNum();        
        // 调用延迟函数
        StartCoroutine(LateInsBall());
    }
    //延迟生成精灵球的函数
    IEnumerator LateInsBall()
    {
        //延迟0.2秒向下执行
        yield return new WaitForSeconds(0.2f);
        ARBallCtrl.Instance.InsNewBall();
    }
}
