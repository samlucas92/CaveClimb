using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateScript : MonoBehaviour {
	public GameObject[] availableRooms;
	
	public List<GameObject> currentRooms;

	public GameObject[] availableObjects;    
	public List<GameObject> objects;

	public float objectsMinDistance = 5.0f;    
	public float objectsMaxDistance = 10.0f;
	

	
	private float screenWidthInPoints;

	// Use this for initialization
	void Start () {
		float height = Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AddRoom(float farhtestRoomEndY)
	{
		//1
		int randomRoomIndex = Random.Range(0, availableRooms.Length);
		
		//2
		GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);

		//3
		float roomHeight = room.transform.FindChild("guide").localScale.y;
		
		//4
		float roomCenter = farhtestRoomEndY + roomHeight * 0.5f;
		
		//5
		room.transform.position = new Vector3(0,roomCenter, 0);
		
		//6
		currentRooms.Add(room);  

	}

	void GenerateRoomIfRequired()
	{
		//1
		List<GameObject> roomsToRemove = new List<GameObject>();
		
		//2
		bool addRooms = true;        
		
		//3
		float playerY = transform.position.y;
		
		//4
		float removeRoomY = playerY - screenWidthInPoints;        
		
		//5
		float addRoomY = playerY + screenWidthInPoints;
		
		//6
		float farthestRoomEndY = 0;
		
		foreach(var room in currentRooms)
		{
			//7
			float roomHeight = room.transform.FindChild("guide").localScale.y;
			float roomStartY = room.transform.position.y - (roomHeight * 0.31f);    
			float roomEndY = roomStartY + roomHeight;                            
			
			//8
			if (roomStartY > addRoomY)
				addRooms = false;
			
			//9

			
			//10
			farthestRoomEndY = Mathf.Max(farthestRoomEndY, roomEndY);
		}
		

		
		//12
		if (addRooms)
			AddRoom(farthestRoomEndY);
	}

	void AddObject(float lastObjectY)
	{
		//1
		int randomIndex = Random.Range(0, availableObjects.Length);
		
		//2
		GameObject obj = (GameObject)Instantiate(availableObjects[randomIndex]);
		
		//3
		float objectPositionY = lastObjectY + Random.Range(objectsMinDistance, objectsMaxDistance);

		obj.transform.position = new Vector3(-3,objectPositionY + 3 ,0); 

		//5
		objects.Add(obj);            
	}

	void GenerateObjectsIfRequired()
	{
		//1
		float playerY = transform.position.y;        
		float removeObjectsY = playerY - screenWidthInPoints;
		float addObjectY = playerY + screenWidthInPoints;
		float farthestObjectY = 0;

		
		foreach (var obj in objects)
		{
			//3
			float objY = obj.transform.position.y;
			
			//4
			farthestObjectY = Mathf.Max(farthestObjectY, objY);
			

		}
		

		
		//7
		if (farthestObjectY < addObjectY)
			AddObject(farthestObjectY);
	}

	void FixedUpdate () 
	{    
		GenerateRoomIfRequired();
		GenerateObjectsIfRequired();
	}
}
