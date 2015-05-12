﻿using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateQuad : ScriptableWizard {
	
	//Name of Quad Asset
	public string MeshName = "Quad";
	
	//Game Object Name
	public string GameObjectName = "Plane_Object";
	
	//Name of asset folder to contain quad asset when created
	public string AssetFolder = "Assets";
	
	//Width of quad in wolrd units
	public float Width = 1.0f;
	
	//Height of quad in world units
	public float Height = 1.0f;
	
	public enum AnchorPoint {
		TopLeft,
		TopMiddle,
		TopRight,
		RightMiddle,
		BottomRight,
		BottomMiddle,
		BottomLeft,
		LeftMiddle,
		Center,
		Custom
	}
	
	public AnchorPoint Anchor = AnchorPoint.Center;
	
	public float AnchorX = 0.5f;
	
	public float AnchorY = 0.5f;
	
	
	[MenuItem("GameObject/Create Other/Custom Plane")]
	static void CreateWizard(){
		ScriptableWizard.DisplayWizard ("Create Plane", typeof(CreateQuad));
	}
	
	//Gets the currently selected asset in the project panel
	void GetFolderSelection()
	{
		//Check user selection in editor - check for folder selection
		if (Selection.objects != null && Selection.objects.Length == 1)
		{
			//Get path from selected asset
			AssetFolder = AssetDatabase.GetAssetPath(Selection.objects[0]);
		}
	}
	//Called when window is show
	void OnEnable()
	{
		GetFolderSelection();
	}
	//Called 10 times per second
	void OnInspectorUpdate()
	{
		switch(Anchor)
		{
			//Anchor is set to top-left
		case AnchorPoint.TopLeft:
			AnchorX = 0.0f * Width;
			AnchorY = 1.0f * Height;
			break;
			//Anchor is set to top-middle
		case AnchorPoint.TopMiddle:
			AnchorX = 0.5f * Width;
			AnchorY = 1.0f * Height;
			break;
			//Anchor is set to top-right
		case AnchorPoint.TopRight:
			AnchorX = 1.0f * Width;
			AnchorY = 1.0f * Height;
			break;
			//Anchor is set to right-middle
		case AnchorPoint.RightMiddle:
			AnchorX = 1.0f * Width;
			AnchorY = 0.5f * Height;
			break;
			//Anchor is set to Bottom-Right
		case AnchorPoint.BottomRight:
			AnchorX = 1.0f * Width;
			AnchorY = 0.0f * Height;
			break;
			//Anchor is set to Bottom-Middle
		case AnchorPoint.BottomMiddle:
			AnchorX = 0.5f * Width;
			AnchorY = 0.0f * Height;
			break;
			//Anchor is set to Bottom-Left
		case AnchorPoint.BottomLeft:
			AnchorX = 0.0f * Width;
			AnchorY = 0.0f * Height;
			break;
			//Anchor is set to Left-Middle
		case AnchorPoint.LeftMiddle:
			AnchorX = 0.0f * Width;
			AnchorY = 0.5f * Height;
			break;
			//Anchor is set to center
		case AnchorPoint.Center:
			AnchorX = 0.5f * Width;
			AnchorY = 0.5f * Height;
			break;
		case AnchorPoint.Custom:
		default:
			break;
		}
	}
	//Function to create quad mesh
	void OnWizardCreate()
	{
		//Create Vertices
		Vector3[] Vertices = new Vector3[4];
		//Create UVs
		Vector2[] UVs = new Vector2[4];
		//Two triangles of quad
		int[] Triangles = new int[6];
		//Assign vertices based on pivot
		//Bottom-left
		Vertices[0].x = -AnchorX;
		Vertices[0].y = -AnchorY;
		//Bottom-right
		Vertices[1].x = Vertices[0].x+Width;
		Vertices[1].y = Vertices[0].y;
		//Top-left
		Vertices[2].x = Vertices[0].x;
		Vertices[2].y = Vertices[0].y+Height;
		//Top-right
		Vertices[3].x = Vertices[0].x+Width;
		Vertices[3].y = Vertices[0].y+Height;
		//Assign UVs
		//Bottom-left
		UVs[0].x=0.0f;
		UVs[0].y=0.0f;
		//Bottom-right
		UVs[1].x=1.0f;
		UVs[1].y=0.0f;
		//Top-left
		UVs[2].x=0.0f;
		UVs[2].y=1.0f;
		//Top-right
		UVs[3].x=1.0f;
		UVs[3].y=1.0f;
		//Assign triangles
		Triangles[0]=3;
		Triangles[1]=1;
		Triangles[2]=2;
		Triangles[3]=2;
		Triangles[4]=1;
		Triangles[5]=0;
		//Generate mesh
		Mesh mesh = new Mesh();
		mesh.name = MeshName;
		mesh.vertices = Vertices;
		mesh.uv = UVs;
		mesh.triangles = Triangles;
		mesh.RecalculateNormals();
		//Create asset in database
		AssetDatabase.CreateAsset(mesh, AssetDatabase.GenerateUniqueAssetPath(AssetFolder + "/" +
		                                                                      MeshName) + ".asset");
		AssetDatabase.SaveAssets();
		//Create plane game object
		GameObject plane = new GameObject(GameObjectName);
		MeshFilter meshFilter = (MeshFilter)plane.AddComponent(typeof(MeshFilter));
		plane.AddComponent(typeof(MeshRenderer));
		//Assign mesh to mesh filter
		meshFilter.sharedMesh = mesh;
		mesh.RecalculateBounds();
		//Add a box collider component
		plane.AddComponent (typeof(BoxCollider));
		
	}
}
