/*                                 游戏设计模式--访问者模式
 *  定义：表示一个作用于某对象结构中的各元素的操作。它使你可以在不改变各元素类的前提下定义作用于这些元素的新操作。
 *  涉及角色：
 *  1.Visitor 抽象访问者角色，为该对象结构中具体元素角色声明一个访问操作接口。该操作接口的名字和参数标识了发送访
 *            问请求给具体访问者的具体元素角色，这样访问者就可以通过该元素角色的特定接口直接访问它。
 *  2.ConcreteVisitor.具体访问者角色，实现Visitor声明的接口。
 *  3.Element 定义一个接受访问操作(accept())，它以一个访问者(Visitor)作为参数。
 *  4.ConcreteElement 具体元素，实现了抽象元素(Element)所定义的接受操作接口。
 *  5.ObjectStructure 结构对象角色，这是使用访问者模式必备的角色。它具备以下特性：能枚举它的元素；可以提供一个高
 *           层接口以允许访问者访问它的元素；如有需要，可以设计成一个复合对象或者一个聚集（如一个列表或无序集合）。
 *  优点：单一职责原则，拓展性好
 *  实例：假设游戏开发中，BOSS有很多种，击杀BOSS会增加主角的战斗力和增加主角的经验值。根据BOSS血量和等级的不同增加
 *        的战力或者经验也会不同。这个时候就要用到访问者模式，因为这个需求很怪！有的时候为了学习设计模式经常会想出
 *        这种没什么实际意义的需求。
 *        
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visitorpattern : MonoBehaviour {

	
	void Start () {
        BOSSList bosslist = new BOSSList();

        IBOSS pigboss0 = new PigBoss("猪猪侠",100,1);
        IBOSS pigboss1 = new PigBoss("猪八戒", 150, 2);
        IBOSS dogboss0 = new DogBoss("哮天犬", 200, 1);
        IBOSS dogboss1 = new DogBoss("牧羊犬", 100, 2);
        IBOSS dogboss2 = new DogBoss("藏獒", 300, 3);

        bosslist.AddBoss(pigboss0);
        bosslist.AddBoss(pigboss1);
        bosslist.AddBoss(dogboss0);
        bosslist.AddBoss(dogboss1);
        bosslist.AddBoss(dogboss2);

        IVisitor visitor = new PlayerExp();
        IVisitor visitor1 = new PlayerPower();

        bosslist.Accept(visitor);
        bosslist.Accept(visitor1);

    }
	
}
/// <summary>
/// 抽象元素类 boss
/// </summary>
public abstract class IBOSS
{
    //接收方法接收visitor
    public abstract void Accept(IVisitor visitor);
}
/// <summary>
/// 具体元素类 猪boss
/// </summary>
public class PigBoss:IBOSS 
{
   public string Name { get; set; }//名字
   public int Hp { get; set; }//血量
   public int Level { get; set; }//等级
    public PigBoss(string name,int hp,int level)
    {
        this.Name = name;
        this.Hp = hp;
        this.Level = level;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.PigVisit(this);
    }
}
/// <summary>
/// 具体元素类 狗boss
/// </summary>
public class DogBoss:IBOSS 
{
    public string Name { get; set; }//名字
    public int Hp { get; set; }//血量
    public int Level { get; set; }//等级
    public DogBoss(string name, int hp, int level)
    {
        this.Name = name;
        this.Hp = hp;
        this.Level = level;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.DogVisit(this);
    }
}
/// <summary>
/// 抽象访问者类
/// </summary>
public abstract class IVisitor
{
    // 声明一组重载的访问方法，用于访问不同类型的具体元素
    public abstract void PigVisit(PigBoss pig);
    public abstract void DogVisit(DogBoss dog);
}
/// <summary>
/// 具体访问者 主角的战力
/// </summary>
public class PlayerPower : IVisitor
{
    public override void DogVisit(DogBoss dog)
    {
        int power = dog.Hp * dog.Level;
        string  name = dog.Name;
        Debug.Log("击杀了" + name + "获得了" + power + "的战力加成");
    }

    public override void PigVisit(PigBoss pig)
    {
        Debug.Log("击杀"+pig.Name +"不增加战力，气不气");
    }
}
/// <summary>
/// 具体访问者 主角的经验值 
/// </summary>
public class PlayerExp : IVisitor
{
    public override void DogVisit(DogBoss dog)
    {
        Debug.Log("击杀" + dog.Name + "不增加经验，气不气");
    }

    public override void PigVisit(PigBoss pig)
    {
        int Exp = pig.Hp * pig.Level;
        string name = pig.Name;
        Debug.Log("击杀了" + name + "获得了" + Exp + "的经验加成");
    }
}
/// <summary>
/// 对象结构类
/// </summary>
public class BOSSList
{
    public List<IBOSS> bossList = new List<IBOSS>();
    public void AddBoss(IBOSS boss)
    {
        bossList.Add(boss);
    }
    public void Accept(IVisitor visitor)
    {
        foreach (var vis in bossList)
        {
            vis.Accept(visitor );
        }
    }
}

