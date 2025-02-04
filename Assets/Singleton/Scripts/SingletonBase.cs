using System;
using UnityEditor.SearchService;

public class SingletonBase<T> where T : SingletonBase<T> // 泛型T必须为这个类本身或者它的子类
{
	// 构造方法私有化，防止外部new对象
	protected SingletonBase() { }

	// 线程锁，当多线程访问时同一时刻仅允许一个线程访问
	private static object locker = new object();


	// 提供一个属性给外部访问，这个属性就相当于是单例对象
	// 当多个线程对它进行修改时，可以确保这个字段在任何时刻呈现的都是最新的值
	private volatile static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				lock (locker)
				{
                    if (instance == null)
                    {
						// 使用反射，调用无参构造方法创建对象
						instance = Activator.CreateInstance(typeof(T), true) as T;
					}
                    
				}
			}

			return instance;
		}
	}
}
