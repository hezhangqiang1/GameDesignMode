/*  目的：学习设计模式的桥接模式
 *  描述：图片和修图软件的关系，一张图片修改方法写完以后，如果再增加需求3张图片就要写一些重复代码
 *        如果需求再次变更，新增加了几款修图软件，每次都要重新写方法，修改大量代码。
 *  使用桥接模式新建一个图片接口 和一个修图软件接口重构代码
 *  优点;更改需求的时候不需要修改太多代码 
 *  将抽象部分与它的实现部分分离，使它们都可以独立地变化。
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{


    void Start()
    { 
        //实例化一种修图软件 
        IChangepicture ICP = new AI();
        //实例化风景照
        Scenery scenery = new Scenery(ICP);
        //调用风景照的change（）方法
        scenery.Change();
        People people = new People(ICP);
        people.Change();
        Food food = new Food(ICP);
        food.Change();
    }
    /// <summary>
    /// 风景照类继承自图片接口
    /// </summary>
    public class Scenery : IPicture
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="IC">修图软件类型</param>
        public Scenery(IChangepicture IC) : base(IC)
        {
            name = "风景照";
        }   
    }
    public class People : IPicture
    {
        public People(IChangepicture IC) : base(IC)
        {
            name = "人物照";
        }
    }
    public class Food : IPicture
    {
        public Food(IChangepicture IC):base(IC)
        {
            name = "食物照";
        }
    }
    public class PS : IChangepicture
    {
        /// <summary>
        /// 重写父类的方法
        /// </summary>
        /// <param name="name"></param>
        public override  void Change(string name)
        {
            Debug.Log(name + "已经用PS修过了");
        }
    }
    public class AI : IChangepicture
    {
        public override  void Change(string name)
        {
            Debug.Log(name + "已经用AI修过了");
        }
    }
    /// <summary>
    /// 图片接口
    /// </summary>
    public class IPicture
    {
        public string name;
        public IChangepicture ichangepicture;
        public void Change()
        {
            ichangepicture.Change(name);
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ichangepicture">修图软件的类型</param>
        public IPicture(IChangepicture ichangepicture)
        {
            this.ichangepicture = ichangepicture;
        }
    }
    /// <summary>
    /// 修图软件接口
    /// </summary>
    public abstract class IChangepicture
    {
        public virtual void Change(string name)
        {

        }
    }
}
