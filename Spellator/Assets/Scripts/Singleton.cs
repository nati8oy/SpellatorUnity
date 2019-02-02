using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour {

		private static T instance;

		public static T Instance{
			get {

				//checks to see if the game object is null. If so, set it to this file.
				if(instance==null){
					instance = FindObjectOfType<T>();
				}
				//if there is already an instance of GameManager running then destroy any additional ones that are trying to be created
				else if (instance != FindObjectOfType<T>())
					Destroy(FindObjectOfType<T>());

				DontDestroyOnLoad(FindObjectOfType<T>());
				return instance;
			}


		}


}
