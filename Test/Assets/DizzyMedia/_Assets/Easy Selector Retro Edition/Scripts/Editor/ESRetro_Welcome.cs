using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Debug = UnityEngine.Debug;

[InitializeOnLoad]
public class ESRetro_Welcome : EditorWindow {


//////////////////////////////////////
///
///     INTERNAL VALUES
///
///////////////////////////////////////

        
    private static ESRetro_Welcome window;
    private static Vector2 windowsSize = new Vector2(530, 425f);
    private static string verNumb = " v0.1.3";
    
    private const string isShowAtStartEditorPrefs = "ESRetro_WelcomeStart";
    public static bool showOnStart = true;
    private static bool isInited;
    
    private string fileDocs = "Easy Selector Retro Documentation";
    
    
//////////////////////////////////////
///
///     SHOW AT START CHECKS
///
///////////////////////////////////////

    
	static ESRetro_Welcome() {
        
		EditorApplication.update -= GetShowAtStart;
		EditorApplication.update += GetShowAtStart;
	
    }//ESRetro_Welcome
    
	private static void GetShowAtStart() {
        
		EditorApplication.update -= GetShowAtStart;
		
        if(EditorPrefs.HasKey(isShowAtStartEditorPrefs)){
        
            showOnStart = EditorPrefs.GetBool(isShowAtStartEditorPrefs);
        
        //HasKey
        } else {
        
            showOnStart = true;
            EditorPrefs.SetBool(isShowAtStartEditorPrefs, showOnStart);
            
        }//HasKey

		if(showOnStart) {
            
			EditorApplication.update -= OpenAtStartup;
			EditorApplication.update += OpenAtStartup;
		
        }//showOnStart
        
	}//GetShowAtStart

	private static void OpenAtStartup() {
        
        OpenWizard();
        EditorApplication.update -= OpenAtStartup;

	}//OpenAtStartup
    
    
//////////////////////////////////////
///
///     EDITOR WINDOW
///
///////////////////////////////////////

    [MenuItem("Dizzy Media/Easy Selector/Retro Edition/Review Asset", false , 13)]
    public static void OpenReview() {
            
        Application.OpenURL("http://u3d.as/2sNq#reviews");
        
    }//OpenReview

    [MenuItem("Dizzy Media/Easy Selector/Retro Edition/ES Retro Welcome", false , 12)]
    public static void OpenWizard() {
            
        window = GetWindow<ESRetro_Welcome>(false, "ES Retro" + verNumb, true);
        window.maxSize = window.minSize = windowsSize;
        
    }//OpenWizard

    private void OnGUI() {
            
        GUI.skin.button.alignment = TextAnchor.MiddleCenter;
            
        Texture t0 = (Texture)Resources.Load("EditorContent/ES-Logo");
        
        var style = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter};
            
        GUILayout.Box(t0, style, GUILayout.ExpandWidth(true), GUILayout.Height(200));
        
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        
        ESRetro_WelcomeScreen();
            
    }//OnGUI


//////////////////////////////////////
///
///     EDITOR DISPLAY
///
///////////////////////////////////////


    public void ESRetro_WelcomeScreen(){
    
        EditorGUILayout.HelpBox("\n" + "Hello and welcome to Easy Selector | Retro Edition! " + "\n" + "\n" + "All of ES Retro functions are ready to use right out of the box! However the demo scenes require additional assets to be imported which i cannot include in this pack due to licensing" + "\n" + "(i.e 2D + 3D demo scenes), links to these assets are included in the documentation." + "\n" + "\n" + "Have fun and don't forget to leave a review on the store page!" + "\n", MessageType.Info);
            
        EditorGUILayout.Space();

        if(GUILayout.Button("Documentation")){

            File_Find(fileDocs);

        }//Button

        GUILayout.Space(5);

        if(GUILayout.Button("Review Asset")){

            OpenReview();

        }//Button
            
        GUILayout.Space(10);

        showOnStart = EditorGUILayout.Toggle("Show On Start", showOnStart);
    
    }//ESRetro_WelcomeScreen
    
    
//////////////////////////////////////
///
///     EXTRAS
///
///////////////////////////////////////


    public void File_Find(string fileName){
        
        string[] results = new string[0];
        
        results = AssetDatabase.FindAssets(fileName);
        
        if(results.Length > 0){
            
            UnityEngine.Object[] objects = new UnityEngine.Object[results.Length];
            
            string[] paths = new string[results.Length];
            
            for(int i = 0; i < results.Length; i++) {
                
                paths[i] = AssetDatabase.GUIDToAssetPath(results[i]);
                
            }//for i results
            
            if(paths.Length > 0){
                
                for(int p = 0; p < paths.Length; p++) {
                    
                    objects[p] = AssetDatabase.LoadAssetAtPath(paths[p], typeof(UnityEngine.Object));
            
                }//for p paths
                
            }//paths.Length > 0
            
            if(objects.Length > 0){
                
                Selection.objects = objects;
                
                Debug.Log(fileName + " Found!");
            
            }//objects.Length > 0
            
        //results > 0
        } else {
        
            Debug.Log(fileName + " Not Found!");
        
        }//results > 0
        
    }//File_Find
    
    public void ESRetro_ImportPack(string packName){
        
        string[] results = new string[0];
        
        results = AssetDatabase.FindAssets(packName);
        
        if(results.Length > 0){
            
            foreach(string pack in results) {
                
                AssetDatabase.ImportPackage(AssetDatabase.GUIDToAssetPath(pack), true);
                
            }//foreach pack
            
        //results > 0
        } else {
        
            Debug.Log(packName + " Not Found!");
        
        }//results > 0
        
    }//ESRetro_ImportPack
    
	private void OnDestroy() {
        
        window = null;
		EditorPrefs.SetBool(isShowAtStartEditorPrefs, showOnStart);
	
    }//OnDestroy
    
}
