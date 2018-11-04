/*                    游戏设计模式--备忘录模式
 *  备忘录模式（Memento Pattern）又叫做快照模式（Snapshot Pattern）或Token模式，是GoF的23种设计模式之一，属于行为模式。
 *  定义：在不破坏封闭的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。这样以后就可将该对象恢复到原先保存的状态。
 *  涉及角色：
 *  1.Originator(发起人)：负责创建一个备忘录Memento，用以记录当前时刻自身的内部状态，并可使用备忘录恢复内部状态。
 *                        Originator可以根据需要决定Memento存储自己的哪些内部状态。
 *  2.Memento(备忘录)：负责存储Originator对象的内部状态，并可以防止Originator以外的其他对象访问备忘录。
 *                     备忘录有两个接口：Caretaker只能看到备忘录的窄接口，他只能将备忘录传递给其他对象。
 *                     Originator却可看到备忘录的宽接口，允许它访问返回到先前状态所需要的所有数据。
 *  3.Caretaker(管理者):负责备忘录Memento，不能对Memento的内容进行访问或者操作。                  
 *                                                                                ---百度百科
 *   应用：游戏进度的保存，版本的回滚等；
 *   实例：存储游戏状态。游戏关卡的记录。
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoMode : MonoBehaviour {

	
	void Start () {
        //originator originator = new originator();
        //originator.setcheckpoint("第一关");
        //originator.showcheckpoint();

        //memento memento = originator.creatememento();
        //originator.setcheckpoint("第二关");
        //originator.showcheckpoint();

        //originator.setmemento(memento);
        //originator.showcheckpoint();
        Caretaker caretaker = new Caretaker();
        Originator originator = new Originator();

        originator.SetCheckpoint("第1关");
        originator.ShowCheckpoint();

        caretaker.AddDicMemento("第一次游戏", originator.CreateMemento());

        originator.SetCheckpoint("第2关");
        originator.ShowCheckpoint();

        caretaker.AddDicMemento("第二次游戏", originator.CreateMemento());

        originator.SetCheckpoint("第3关");
        originator.ShowCheckpoint();
        caretaker.AddDicMemento("第三次游戏", originator.CreateMemento());

        originator.SetMemento(caretaker.GetDicMement("第一次游戏"));
        originator.ShowCheckpoint();

    }

}
/// <summary>
/// 发起人
/// </summary>
public class Originator
{
    private string mCheckpoint;//关卡
    /// <summary>
    /// 设置游戏当前关卡
    /// </summary>
    /// <param name="checkpoint">关卡名称</param>
    public void SetCheckpoint(string checkpoint)
    {
        mCheckpoint = checkpoint;
    }
    /// <summary>
    /// 显示游戏当前关卡
    /// </summary>
    public void ShowCheckpoint()
    {
        Debug.Log("当前游戏正在" + mCheckpoint);
    }
    /// <summary>
    /// 创建一个备忘录
    /// </summary>
    /// <returns></returns>
    public Memento  CreateMemento()
    {
        Memento memento = new Memento();
        memento.SetCheckpoint(mCheckpoint);
        return memento;
    }
    /// <summary>
    /// 设置备忘录
    /// </summary>
    /// <param name="memento">备忘录</param>
    public void SetMemento(Memento memento)
    {
        SetCheckpoint(memento.GetCheckpoint());
    }
}
/// <summary>
/// 备忘录(一系列的存档操作，最好保存到本地或者服务器)
/// </summary>
public class Memento
{
    private string mCheckpoint;
    /// <summary>
    /// 设置备忘关卡
    /// </summary>
    /// <param name="checkpoint"></param>
    public void SetCheckpoint(string checkpoint)
    {
        mCheckpoint = checkpoint;
    }
    /// <summary>
    /// 得到关卡
    /// </summary>
    /// <returns></returns>
    public string GetCheckpoint()
    {
        return mCheckpoint;
    }
}
/// <summary>
/// 管理者
/// </summary>
public class Caretaker
{
    //数据字典，存储备忘录，version版本号，memento备忘录
    Dictionary<string, Memento> DicMemento = new Dictionary<string, Memento>();
    /// <summary>
    /// 添加备忘录到数据字典
    /// </summary>
    /// <param name="version"></param>
    /// <param name="memento"></param>
    public void AddDicMemento(string version ,Memento memento)
    {
        DicMemento.Add(version, memento);
    }
    /// <summary>
    /// 通过版本号得到备忘录
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public Memento  GetDicMement(string version )
    {
        return DicMemento[version];
    }
}
