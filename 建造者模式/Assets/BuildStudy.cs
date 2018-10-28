/*                  游戏设计模式--建造者模式
 *  将一个复杂对象的构建与它的表示分离，似的同样的构建过程可以创建不同的表示的意图时，我们就需要应用建造者模式。
 *  定义一个抽象的建造者类
 *  建造具体建造者类，让具体的建造者类去继承抽象类，那就必须去重写抽象方法
 *  建造指挥者类，用它来控制建造过程，也用它来隔离用户与建造过程的关联
 * 
 *  实例：在游戏开发中创建角色有头，身体，手，脚，现在要创造3个角色，战士，法师，射手
 * */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BuildStudy : MonoBehaviour {

	
	void Start () {
        Director director = new Director();      //声明工程是实例
        Builder mage = new Mage();               //创建法师
        Role role = mage.GetRole();              //法师角色的组装

        director.BulidRole(mage);                //指挥创建法师
        role.Show();                             //法师的呈现
	}
}
/// <summary>
/// 角色类
/// </summary>
public class Role
{
    List<string> role = new List<string>() ;
    public void Add(string Path)
    {
        role.Add(Path);
    }
    /// <summary>
    /// 用来打印角色信息
    /// </summary>
    public void Show()
    {
        Debug.Log("创建角色中");
        foreach(string path in role)
        {
            Debug.Log(path);
        }
    }
}
/// <summary>
/// 角色建造者类
/// </summary>
public abstract class Builder
{
    public abstract void Head();
    public abstract void Body();
    public abstract void Hand();
    public abstract void Foot();
    public abstract Role GetRole();
    
}
/// <summary>
/// 战士类
/// </summary>
public class Warrior : Builder
{
    Role role = new Role();
    public override void Body()
    {
       role.Add ("战士的身体建造完成");
    }

    public override void Foot()
    {
        role.Add("战士的脚建造完成");
    }

    public override void Hand()
    {
        role.Add("战士的手建造完成");
    }

    public override void Head()
    {
        role.Add("战士的头建造完成");
    }
    /// <summary>
    /// 返回Role（产品）
    /// </summary>
    /// <returns></returns>
    public override Role GetRole()
    {
        return role;
    }
}
public class Mage : Builder
{
    Role role = new Role();
    public override void Body()
    {
        role.Add("法师的身体建造完成");
    }

    public override void Foot()
    {
        role.Add("法师的脚建造完成");
    }

    public override void Hand()
    {
        role.Add("法师的手建造完成");
    }

    public override void Head()
    {
        role.Add("法师的头建造完成");
    }
    public override Role GetRole()
    {
        return role;
    }
}
public class Striker : Builder
{
    Role role = new Role();
    public override void Body()
    {
        role.Add("射手的身体建造完成");
    }

    public override void Foot()
    {
        role.Add("射手的脚建造完成");
    }

  
    public override void Hand()
    {
        role.Add("射手的手建造完成");
    }

    public override void Head()
    {
        role.Add("射手的头建造完成");
    }
    public override Role GetRole()
    {
        return role;
    }

}
/// <summary>
/// 工程师类指挥角色创建
/// </summary>
public class Director
{
    public void BulidRole(Builder builder)
    {
        builder.Body();
        builder.Foot();
        builder.Hand();
        builder.Head();
    }
}
