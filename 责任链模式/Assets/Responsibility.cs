/*                     游戏设计模式--责任链模式
 *  定义：很多对象由每一个对象对其下家的引用而连接起来形成一条链。
 *        请求在这个链上传递，直到链上的某一个对象决定处理此请求。
 *        发出这个请求的客户端并不知道链上的哪一个对象最终处理这个请求，
 *        这使得系统可以在不影响客户端的情况下动态地重新组织和分配责任。
 * 
 *  游戏应用：游戏中的关卡系统等；其他应用：客服处理问题，请假系统等；
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responsibility : MonoBehaviour {

	
	void Start () {
        string Problem = "B问题";
        IHandle handleA = new HandleA();
        IHandle handleB= new HandleB();
        handleA.NestHandle = handleB;
        handleA.HandleDeal(Problem);

    }
	
}
/// <summary>
/// 抽象类：处理者
/// </summary>
public abstract class IHandle
{
    //下一个处理者
    protected  IHandle mNestHandle=null;
    public IHandle NestHandle
    {
        set { mNestHandle = value; }
    }
    /// <summary>
    /// 虚方法：根据条件处理问题
    /// </summary>
    /// <param name="problem">问题描述</param>
    public virtual void  HandleDeal(string problem) { }
}
public class HandleA:IHandle
{
    public override void HandleDeal(string problem)
    { 
      if(problem == "A问题")
        {
            Debug.Log("正在处理A问题");
        }
      else
        {
            if(mNestHandle!=null)
            {
                Debug.Log("不是A问题，已经移交给" + mNestHandle);
                mNestHandle.HandleDeal(problem);
            }
          
        }
    }
}
public class HandleB: IHandle
{
    public override void HandleDeal(string problem)
    {
        if (problem == "B问题")
        {
            Debug.Log("正在处理B问题");
        }
        else
        {
            if(mNestHandle !=null)
            {
                Debug.Log("不是B问题，已经移交给" + mNestHandle);
                mNestHandle.HandleDeal(problem);
            }
           
        }
    }
}