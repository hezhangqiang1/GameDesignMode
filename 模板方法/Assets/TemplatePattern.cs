/* 学习设计模式--模板模式
 * 
 * 冲泡咖啡和冲泡茶的例子
 * 加工流程：
 * 咖啡冲泡法：1.把水煮沸、2.用沸水冲泡咖啡、3.把咖啡倒进杯子、4.加糖和牛奶
 * 茶冲泡法：  1.把水煮沸、2.用沸水冲泡茶叶、3.把  茶 倒进杯子、4.加蜂蜜
 * 
 * 
 * */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplatePattern : MonoBehaviour {

	
	void Start () {
        //实例化泡茶方法
        Drink drink = new Tea() ;
        drink.MakeDrink();
	}
    /// <summary>
    /// 创建一个喝饮料的抽象类
    /// </summary>
	public abstract class Drink
    {
        //制作饮料的方法
        public void MakeDrink()
        {
            Water();
            Bubble();
            Pour();
            Add();
        }
        //把水煮沸方法
        private void Water()
        {
            Debug.Log("把水煮沸");
        }
        //冲泡
        
        protected  virtual void   Bubble()
        
        {
          
           

        }
        //倒进杯子
        protected virtual void Pour()
        {
          
        }
        //加东西
        protected virtual void Add()
        {
           
        }
    }//Drinkclass_end

    /// <summary>
    /// 创建咖啡类继承饮料类
    /// </summary>
    public class Coffee:Drink 
    {
        //重写冲泡方法
        protected override void Bubble()
        {
            Debug.Log("用沸水冲泡咖啡");
        }
        //重写倒进杯子方法
        protected override void Pour()
        {
            Debug.Log("把咖啡倒进杯子");
        }
        //重写加东西方法
        protected override void Add()
        {
            Debug.Log("加糖和牛奶");
        }

       
    }//CoffeeClass_end

    /// <summary>
    /// 创建茶类继承饮料类
    /// </summary>
    public class Tea : Drink
    {
        //重写冲泡方法
        protected override void Bubble()
        {
            Debug.Log("用沸水冲泡茶叶");
        }
        //重写倒进杯子方法
        protected override void Pour()
        {
            Debug.Log("把茶倒进杯子");
        }
        //重写加东西方法
        protected override void Add()
        {
            Debug.Log("加蜂蜜");
        }
    }

}
