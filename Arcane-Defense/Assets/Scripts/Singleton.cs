using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Object
{
	public static T I { get; private set; }

	protected void Awake()
	{
		if (I == null)
		{
			Debug.Log($"{gameObject.name} with type {typeof(T)} says I is null");
			I = FindObjectOfType<T>();
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Debug.Log($"{gameObject.name} with type {typeof(T)} says I is not null");
			Debug.LogWarning($"{gameObject.name} destroyed.", this);
			Destroy(gameObject);
		}
	}
}