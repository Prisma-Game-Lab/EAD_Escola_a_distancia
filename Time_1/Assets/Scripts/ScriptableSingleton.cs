using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/* inspired by https://www.youtube.com/watch?v=cH-QQoNNpaI&ab_channel=FirstGearGames on 02/11/2021 */
public class ScriptableSingleton<T> : ScriptableObject where T:ScriptableObject
{
   private static T _instance;
   public static T instance
   {
       get{
           if(_instance == null){
               T[] instances = Resources.FindObjectsOfTypeAll<T>();
               Assert.IsTrue(instances.Length == 1, instances.Length.ToString() + " instance(s) of singleton object");
               _instance = instances[0];
               _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
           }
           return _instance;
       }
   }
}
