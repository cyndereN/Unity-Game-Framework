using UnityEngine;

public class PlayerModel : SingletonBase<PlayerModel>
{
	// 构造方法私有化 
	private PlayerModel() {}

	public int money = 666;
	public int diamond = 8888;
	public void Show()
	{
		Debug.Log(money);
		Debug.Log(diamond);
	}
}

//public class PlayerModel
//{
//	// 构造方法私有化，防止外部new对象
//	private PlayerModel() { }

//	// 提供一个属性给外部访问，这个属性就相当于是单例对象
//	private static PlayerModel instance;

//	public static PlayerModel Instance
//	{
//		get 
//		{ 
//			// 保证对象唯一性
//			if (instance == null)
//			{
//				instance = new PlayerModel();
//			}

//			return instance;
//		}
//	}

//	public int money = 666;
//	public int diamond = 8888; 
//	public void Show()
//	{
//		Debug.Log(money);
//		Debug.Log(diamond);
//	}
//}
