using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineRenderPooling : MonoBehaviour {

	public int pooledAmount = 0;

	public static LineRenderPooling current;

	public GameObject renderPrefab;

	public List<GameObject> pooledObjects =  new List<GameObject>();


	void Awake()
	{
		current = this;
	}

	void Start()
	{
		for (int i = 0; i < pooledAmount; ++i)
		{
			GameObject obj = (GameObject)Instantiate(renderPrefab);
			pooledObjects [i].GetComponent<LineRender>().UnUsed();
			pooledObjects.Add(obj);
		}
	}


	public GameObject GetPooledObject()
	{

		for (int i = 0; i < pooledObjects.Count; ++i) {
			if (!pooledObjects [i].GetComponent<LineRender> ().isUsed) {
				pooledObjects [i].GetComponent<LineRender>().isUsed = true;
				return pooledObjects [i];
			}
		}
		//Khi het doi tuong trong p
		GameObject obj = (GameObject)Instantiate (renderPrefab);
		obj.GetComponent<LineRender>().isUsed = true;
		pooledObjects.Add (obj);
		return obj;
	}

	public void UnUsedAllPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; ++i)
		{
			pooledObjects[i].GetComponent<LineRender>().UnUsed();
		}
	}
}
