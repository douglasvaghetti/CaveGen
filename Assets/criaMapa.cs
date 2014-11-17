using UnityEngine;
using System.Collections;

public class criaMapa : MonoBehaviour {
	public int size=40;
	public float blockSize=0.25f;
	private bool[,] array;
	public Object vazio;
	public Object parede;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			createCave();
		}
	}

	private void createCave(){
		array = new bool[size,size];
		for (int x=0; x<size; x++) {
			for(int y=0;y<size;y++){
				if(Random.value>0.45f){
					array[x,y]=false;
				}else{
					array[x,y]=true;
				}
			}
		}

		for (int y=0; y<size; y++) {
			for(int x=0;x<size;x++){
				if(array[x,y]){
					Object.Instantiate(parede,new Vector3(x*blockSize,y*blockSize,0),Quaternion.identity);
				}else{
					Object.Instantiate(vazio,new Vector3(x*blockSize,y*blockSize,0),Quaternion.identity);
				}
			}
		}
	}

}
