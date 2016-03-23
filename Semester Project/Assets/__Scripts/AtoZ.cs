using UnityEngine;
using System.Collections;
 
public class AtoZ : MonoBehaviour {
        
// Use this for initialization
   void Start () {
    printAtoZ ("", 3);
   }
 
// Update is called once per frame
   void Update () {
   }
 void printAtoZ(string s,int size){
      if (size == 0) {
 	 Debug.Log (s);
 	 return;
      }
      for (char ch='a';ch<='z';ch++){
 	printAtoZ((string)(s+ch),size-1);
      }
 }
 
}

