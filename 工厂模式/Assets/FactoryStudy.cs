/*        游戏开发设计模式学习--工厂模式      
 * 实例：如前
 * 
 * */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryStudy : MonoBehaviour {


	void Start () {
        IFactory factory = new AppleFactory();
        factory.Make().MakePhone();
        
	}

}
/// <summary>
/// 定义一个接口，声明制造手机的方法
/// </summary>
public interface IPhone
{
    void   MakePhone();
}
/// <summary>
/// 苹果手机类
/// </summary>
public class Apple : IPhone
{
    public void MakePhone()
    {
        Debug.Log("苹果手机");
    }
}
/// <summary>
/// 小米手机类
/// </summary>
public class MI : IPhone
{
    public  void MakePhone()
    {
        Debug.Log("小米手机");
    }
}
/// <summary>
/// 工厂接口
/// </summary>
public interface IFactory
{
    IPhone Make();
}
/// <summary>
/// 生产苹果手机类
/// </summary>
public class AppleFactory : IFactory
{
    public virtual IPhone Make()
    {
        Debug.Log("这里是苹果手机工厂");
        return new Apple();
    }
}
/// <summary>
/// 生产小米手机类
/// </summary>
public class MIFactory : IFactory
{
    public virtual  IPhone Make()
    {
        Debug.Log("这里是小米手机工厂");
        return new MI();
    }
}