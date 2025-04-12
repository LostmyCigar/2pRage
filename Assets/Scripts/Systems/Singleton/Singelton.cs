using UnityEngine;

namespace Leo
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T instance;
		public static T Instance => GetInstance();

		public static T GetInstance()
		{
			if (instance == null)
			{
				instance = FindObjectOfType<T>();

				if (instance == null)
				{
					// If the instance is still null, create a new GameObject and add the component
					GameObject singletonObject = new GameObject(typeof(T).Name);
					instance = singletonObject.AddComponent<T>();
					Debug.Log("Creating Instance of " + typeof(T).Name);
				}
			}
			else if (instance != FindObjectOfType<T>())
			{
				// If there is another instance already existing, destroy the new one
				Destroy(FindObjectOfType<T>());
			}

			return instance;
		}

		private static T FindInScene() => FindFirstObjectByType<T>();
		public static Tderived InstanceAs<Tderived>() where Tderived : T
		{
			instance ??= FindInScene();
			instance ??= GenerateSingletonDerived<Tderived>();
			return instance as Tderived;
		}
		private static T GenerateSingleton()
		{
			GameObject singletonObject = new GameObject(typeof(T).Name);
			return singletonObject.AddComponent<T>();
		}

		private static Tderived GenerateSingletonDerived<Tderived>() where Tderived : T
		{
			GameObject singletonObject = new GameObject(typeof(Tderived).Name);
			return singletonObject.AddComponent<Tderived>();
		}
		public static bool Exists()
		{
			return instance != null;
		}
	}
}
