using UnityEngine;
using System.Collections;

public class AtoZ : MonoBehaviour {
       void start(){
       	    printAtoZ ("",3);
       }

       void update(){}

       void printAtoZ(string s, int size){
       	    if (size==0){
	       Debug.Log(s);
	       return;
	    }
	    for (char ch='a';ch<='z';ch++)
	    	printAtoZ((string)(s+ch),size-1);
       }
}