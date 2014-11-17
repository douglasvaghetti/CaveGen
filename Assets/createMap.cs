using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class createMap : MonoBehaviour {
	public int size=40;
	public float blockSize=0.25f;
	private bool[,] array;
	public Object empty;
	public Object wall;
	private List<Object> cubes;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C)){
			createRandomArray();
			createCubes();
		}

		if(Input.GetKeyDown(KeyCode.D)){
			deleteCubes();
		}

		if(Input.GetKeyDown(KeyCode.F)){
			deleteCubes();
			Stopwatch sw = new Stopwatch();
			sw.Start();
			filterArray();
			sw.Stop();
			UnityEngine.Debug.Log("time to filter the array: "+sw.ElapsedMilliseconds);
			Stopwatch sw2 = new Stopwatch();
			sw2.Start();
			createCubes();
			sw2.Stop();
			UnityEngine.Debug.Log("time to create the cubes: "+sw2.ElapsedMilliseconds);
		}

	}

	private void createRandomArray(){
		array = new bool[size,size];
		cubes=new List<Object>();
		for (int x=0; x<size; x++) {
			for(int y=0;y<size;y++){
				if(Random.value<0.45f || y==0 ||x==0|| y==size-1||x==size-1 ){
					array[x,y]=false;
				}else{
					array[x,y]=true;
				}
			}
		}
	}

	private void createCubes(){
		for (int x=0; x<size; x++) {
			for(int y=0;y<size;y++){
				if(array[x,y]){
					//cubes.Add(
					//	Object.Instantiate(empty,new Vector3(x*blockSize,y*blockSize,0),Quaternion.identity));
				}else{
					cubes.Add(
						Object.Instantiate(wall,new Vector3(x*blockSize,y*blockSize,0),Quaternion.identity));
				}
			}
		}
	}

	private void filterArray(){
		for(int x=1;x<size-1;x++){
			for(int y=1;y<size-1;y++){
				filterCube(x,y);
			}
		}
	}

	private void filterCube(int x,int y){
		int cont =0;
		for(int xit=-1;xit<=1;xit++){
			for(int yit=-1;yit<=1;yit++){
				if(!array[x+xit,y+yit]){
					cont++;
				}
			}
		}
		if(cont>=5){
			array[x,y]=false;
		}else{
			array[x,y]=true;
		}
	}

	private void deleteCubes(){
		for(int x=0;x<cubes.Count;x++){
			Object.Destroy(cubes[x]);
		}
	}

}
