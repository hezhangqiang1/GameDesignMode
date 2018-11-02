/*                 设计模式学习--状态模式
 * 优点：在面向对象软件设计时，常常碰到某一个对象由于状态的不同而有不同的行为。
 *       如果用if else或是switch case等方法处理，对象操作及对象的状态就耦合在一起，
 *       碰到复杂的情况就会造成代码结构的混乱。在这种情况下，就可以使用状态模式来解决问题。
 * 定义：状态模式允许一个对象在其内部状态改变时改变它的行为，使对象看起来似乎修改了它的类。
 *       游戏开发时常常碰到设置主角状态的问题，通常解决办法可以用unity自带的动画状态机也
 *       自己写一个有限状态机FSM等方法来解决。
 * 实例: 这里假设主角有3种状态：Idle（闲置） run（跑）attack（攻击）
 *      
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStudy : MonoBehaviour
{
    

    void Start()
    {
        Player playerIdle = new Player(new Idle());
        Player playerRun = new Player(new Run());
        Player playerAttack = new Player(new Attack());

        playerIdle.UseState();
        playerRun.UseState();
        playerAttack.UseState();
    }
    

}//StateStudyclass_end
/// <summary>
/// 主角类，定义当前的状态
/// </summary>
public class Player
{
    private IState mState;
    /// <summary>
    /// 定义Player的初始状态
    /// </summary>
    /// <param name="mState"></param>
    public Player(IState mState)
    {
        this.mState = mState;
    }
    public void UseState()
    {
        mState.SetState();
    }
}
/// <summary>  
/// 抽象状态类，定义一个接口以封装与IState的一个特定状态相关的行为  
/// </summary>
public abstract  class IState
{
    public abstract void SetState();
}
/// <summary>
/// Istate的子类，用来设置Idle的状态
/// </summary>
public class Idle : IState
{
    public override void SetState()
    {
       Debug.Log("主角闲置");
    }
}
/// <summary>
/// Istate的子类，用来设置Run的状态
/// </summary>
public class Run : IState
{
    public override void SetState()
    { 
        Debug.Log("主角奔跑");
    }
}
/// <summary>
/// Istate的子类，用来设置 Attack 的状态
/// </summary>
public class Attack : IState
{
    public override void SetState()
    {
       Debug.Log("主角攻击");
    }
}
