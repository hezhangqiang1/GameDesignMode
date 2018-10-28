/*                                  游戏设计模式--命令模式
 *  命令模式：将一个请求封装为一个对象(即我们创建的Command对象），从而使你可用不同的请求对客户进行参数化;
 *            对请求排队或记录请求日志，以及支持可撤销的操作。
 *  Command：定义命令的接口，声明执行的方法。
 *  ConcreteCommand：命令接口实现对象，是“虚”的实现；通常会持有接收者，并调用接收者的功能来完成命令要
 *                   执行的操作。
 *  Receiver：接收者，真正执行命令的对象。任何类都可能成为一个接收者，只要它能够实现命令要求实现的相应功能。
 *  Invoker：要求命令对象执行请求，通常会持有命令对象，可以持有很多的命令对象。这个是客户端真正触发命令并
 *           要求命令执行相应操作的地方，也就是说相当于使用命令对象的入口。
 *  Client：创建具体的命令对象，并且设置命令对象的接收者。注意这个不是我们常规意义上的客户端，而是在组装
 *          命令对象和接收者，或许，把这个Client称为装配者会更好理解，因为真正使用命令的客户端是从Invoker来触发执行。
 *                                                                                       ---百度百科
 *  游戏应用实例：在游戏开发中通常用键盘按键来控制玩家或者执行某些操作，这时候可以用命令模式来
 *                执行操作，这样做也可以配合自定义按键。
 * 
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderMode : MonoBehaviour {

    //public List<KeyCode> keycode = new List<KeyCode>() ;
    public KeyCode[] button;//按键数组
	void Start () {

    }
    void Update()
    {
        
        if (Input.GetKeyDown(button [0]))
        { 
            Receiver receiver = new Receiver();
            ICommand command = new SpaceCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
        if(Input.GetKeyDown(button [1]))
        {
            Receiver receiver = new Receiver();
            ICommand command = new ExitCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }

}
/// <summary>
/// 接收者类
/// </summary>
public class Receiver
{
    /// <summary>
    /// 接收需要执行的操作
    /// </summary>
    public void Perform(string s)
    {
        Debug.Log("收到指令，正在执行"+s+"的操作");
    }

}
/// <summary>
/// 抽象命令类
/// </summary>
public abstract class ICommand
{
    public abstract void  Execute();
}
/// <summary>
/// 空格键类
/// </summary>
public class SpaceCommand : ICommand
{
    private Receiver receiver;
    //构造方法设置接收者
    public SpaceCommand(Receiver receiver)
    {
        this.receiver = receiver;
    }
    public override void Execute()
    {
        receiver.Perform("空格键");
    }
}
/// <summary>
/// 退出键类
/// </summary>
public class ExitCommand : ICommand
{
    private Receiver receiver;
    //构造方法设置接收者
    public ExitCommand(Receiver receiver)
    {
        this.receiver = receiver;
    }
    public override void Execute()
    {
        receiver.Perform("退出键");
    }
}
/// <summary>
/// 调度类，要求命令执行请求
/// </summary>
public class Invoker
{
    private ICommand command;
    //设置命令
    public void SetCommand(ICommand command)
    {
        this.command = command;
    }
    //执行命令
    public void ExecuteCommand()
    {
        command.Execute();
    }
}

