using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyCtrl : MonoBehaviour
{
    // 申请两个变量，一个用于存储动画控制器，另一个储存角色的移动类
    // 储存动画控制器
    private Animator ator;
    // 储存角色的移动类 为了获取角色的移动状态
    // 角色的移动类是在Avatar->Inspector->MoveAvatar脚本中已经定义好的
    private MoveAvatar moveAvatar;

    // Use this for initialization
    void Start()
    {
        ator = gameObject.GetComponent<Animator>();
        //获取角色的动画控制器组件

        moveAvatar = transform.parent.GetComponent<MoveAvatar>();
        //获取父物体（角色控制器）上的角色移动类
    }

    // Update is called once per frame
    // Update函数在游戏运行的每一帧都会被调用，所以将控制逻辑放在这里，保证能够试试切换角色状态
    void Update()
    {
        if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Idle)
        //如果角色控制器中的角色动画状态 是定义的待机状态 则
        {
            if (!ator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            //如果动画控制器当前播放的不是待机动画则
            {
                ator.SetTrigger("Idle");
            }

            //触发动画控制器中的待机动画
        }
        else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Walk)
        {
            if (!ator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                ator.SetTrigger("Walk");
            }
        }
        else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Run)
        {
            if (!ator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                ator.SetTrigger("Run");
            }

        }
    }
}
