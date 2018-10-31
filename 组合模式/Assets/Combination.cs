/* 组合模式:将对象组合成树形结构以表示“部分-整体”的层次结构，组合模式使得用户
 *          对单个对象和组合对象的使用具有一致性。掌握组合模式的重点是要理解清
 *          楚 “部分/整体” 还有 ”单个对象“ 与 "组合对象" 的含义。组合模式可
 *          以让客户端像修改配置文件一样简单的完成本来需要流程控制语句来完成的功能。
 * 经典案例:系统目录结构，网站导航结构等。 
 * 例子：unity中游戏物体的节点表示，创建了一个空的游戏物体当作根节点，下面有3个子节点
 *       第一个子节点下又有2个子节点
 * 
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{


    void Start()
    {
        Composite root = new Composite("Root");
        Composite node1 = new Composite("Node1");
        Leaf node2 = new Leaf("Node2");
        Leaf node3 = new Leaf("Node3");

        root.AddChild(node1);
        root.AddChild(node2);
        root.AddChild(node3);

        Leaf child1 = new Leaf("Child1");
        Leaf child2 = new Leaf("Child2");

        node1.AddChild(child1);
        node1.AddChild(child2);

        ReadRoot(root);


    }
    //读取节点名字的方法(深度遍历)
    private void ReadRoot(Root root)
    {
        Debug.Log(root.name );
        List<Root> Children = root.Children;
        //Debug.Log(Children.Count);
        if (Children == null && Children.Count <= 0) return;
        foreach(Root child in Children)
        {
            ReadRoot(child);
        }
    }


}
/// <summary>
/// 抽象类 根节点
/// </summary>
public abstract class Root
{
    protected string mName;
    public string name
    {
        get { return mName; }
    }
    public Root(string name)
    {
        mName = name;
        mChildren = new List<Root>();
    }
    protected List<Root> mChildren;
    //构造方法得到Root索引
    public List<Root> Children { get { return mChildren; } }
    //抽象方法：添加子节点  
    public abstract void AddChild(Root R);
    //抽象方法：移除子节点
    public abstract void RemoveChild(Root R);
    //抽象方法：得到子节点
    public abstract Root GetChild(int Num);

}
/// <summary>
/// 叶子类，下面没有子节点的
/// </summary>
public class Leaf:Root
{
    public Leaf (string name):base(name) { }
    //叶子节点不能添加，得到，移除孩子
    public override void AddChild(Root R)
    {
        return;
    }

    public override Root GetChild(int Num)
    {
        return null ;
    }

    public override void RemoveChild(Root R)
    {
        return;
    }
}
/// <summary>
/// 有孩子的子节点
/// </summary>
public class Composite : Root
{
    public Composite(string name):base(name){ }

    public override void AddChild(Root R)
    {
        mChildren.Add(R);
    }

    public override Root GetChild(int Num)
    {
        return mChildren[Num];
    }

    public override void RemoveChild(Root R)
    {
        mChildren.Remove(R);
    }
}

