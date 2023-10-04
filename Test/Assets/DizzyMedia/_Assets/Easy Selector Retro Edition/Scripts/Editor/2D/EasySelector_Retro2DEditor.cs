using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[CustomEditor(typeof(EasySelector_Retro2D))]
public class EasySelector_Retro2DEditor : Editor {


//////////////////////////
//
//      EDITOR DISPLAY
//
//////////////////////////
    
    
    EasySelector_Retro2D easySel_Retro2D;
    GUISkin oldSkin;
    
    private void OnEnable() {
        
        easySel_Retro2D = (EasySelector_Retro2D)target;
        
    }//OnEnable
    
    public override void OnInspectorGUI() { 
    
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
    
        GUILayout.Space(15);
        
        var style = new GUIStyle(EditorStyles.largeLabel) {alignment = TextAnchor.MiddleCenter};
        
        if(oldSkin == null){
        
            if(oldSkin != Resources.Load("EditorContent/EasySelector Skin") as GUISkin){

                oldSkin = GUI.skin;

                //Debug.Log("Old Skin Name " + GUI.skin.name);

            }//oldSkin != IWC Skin
            
        }//oldSkin == null
        
        GUI.skin = Resources.Load("EditorContent/EasySelector Skin") as GUISkin;
        
        Texture2D t = (Texture2D)Resources.Load("EditorContent/Editor-Icon");
        
        GUILayout.BeginHorizontal("Retro 2D", "headerText");
        
        GUILayout.Label(t, "headerIcon");
        
        EditorGUILayout.EndHorizontal();
        
        GUILayout.Space(5);
        
        GUI.skin = oldSkin;
        
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        
        EditorGUILayout.Space();
        
        EditorGUILayout.BeginVertical();
        
        easySel_Retro2D.tabs = GUILayout.SelectionGrid(easySel_Retro2D.tabs, new string[] { "User Options", "References"}, 2);
        
        EditorGUI.BeginChangeCheck();
        
        SerializedProperty arrowTrans = serializedObject.FindProperty("arrowTrans");
        SerializedProperty arrowPositions = serializedObject.FindProperty("arrowPositions");
        SerializedProperty charTrans = serializedObject.FindProperty("charTrans");
        
        SerializedProperty charImages = serializedObject.FindProperty("charImages");
        SerializedProperty charSprites = serializedObject.FindProperty("charSprites");
        
        SerializedProperty charButtons = serializedObject.FindProperty("charButtons");
        SerializedProperty charBacks = serializedObject.FindProperty("charBacks");
        SerializedProperty charNames = serializedObject.FindProperty("charNames");
        
        SerializedProperty audSource = serializedObject.FindProperty("audSource");
        
        EditorGUILayout.Space();
        
        if(easySel_Retro2D.tabs == 0){
        
            easySel_Retro2D.startTab = GUILayout.Toggle(easySel_Retro2D.startTab, "Start", GUI.skin.button);

            EditorGUILayout.Space();
            
            if(easySel_Retro2D.startTab){
            
                easySel_Retro2D.autoStart = EditorGUILayout.Toggle("Auto Start?", easySel_Retro2D.autoStart);
            
                EditorGUILayout.Space();
            
            }//easySel_Retro2D.startTab
        
            easySel_Retro2D.arrowTab = GUILayout.Toggle(easySel_Retro2D.arrowTab, "Arrow", GUI.skin.button);

            EditorGUILayout.Space();
        
            if(easySel_Retro2D.arrowTab){

                EditorGUILayout.Space();

                easySel_Retro2D.useArrow = EditorGUILayout.Toggle("Use Arrow?", easySel_Retro2D.useArrow);

                if(easySel_Retro2D.useArrow){
                
                    EditorGUILayout.Space();

                    EditorGUILayout.PropertyField(arrowTrans, true);
                    EditorGUILayout.PropertyField(arrowPositions, true);

                }//useArrow

                EditorGUILayout.Space();

            }//arrowTab

            easySel_Retro2D.spritesTab = GUILayout.Toggle(easySel_Retro2D.spritesTab, "Sprites", GUI.skin.button);

            EditorGUILayout.Space();

            if(easySel_Retro2D.spritesTab){

                EditorGUILayout.Space();

                easySel_Retro2D.useCharBack = EditorGUILayout.Toggle("Use Character Back?", easySel_Retro2D.useCharBack);

                if(easySel_Retro2D.useCharBack){
                
                    EditorGUILayout.Space();

                    EditorGUILayout.PropertyField(charBacks, true);

                }//useCharBack

                EditorGUILayout.Space();

                easySel_Retro2D.useSpriteSwap = EditorGUILayout.Toggle("Use Sprite Swap?", easySel_Retro2D.useSpriteSwap);

                if(easySel_Retro2D.useSpriteSwap){
                
                    EditorGUILayout.Space();

                    EditorGUILayout.PropertyField(charImages, true);
                    EditorGUILayout.PropertyField(charSprites, true);

                }//useSpriteSwap

                EditorGUILayout.Space();

            }//spritesTab

            easySel_Retro2D.charTab = GUILayout.Toggle(easySel_Retro2D.charTab, "Character", GUI.skin.button);

            EditorGUILayout.Space();

            if(easySel_Retro2D.charTab){

                EditorGUILayout.Space();

                easySel_Retro2D.useCharPop = EditorGUILayout.Toggle("Use Char Pop?", easySel_Retro2D.useCharPop);

                if(easySel_Retro2D.useCharPop){
                
                    EditorGUILayout.Space();

                    easySel_Retro2D.charPop = EditorGUILayout.FloatField("Char Pop", easySel_Retro2D.charPop);
                    easySel_Retro2D.charPopReset = EditorGUILayout.FloatField("Char Pop Reset", easySel_Retro2D.charPopReset);
                    EditorGUILayout.PropertyField(charTrans, true);

                }//useCharPop

                EditorGUILayout.Space();

                easySel_Retro2D.showNames = EditorGUILayout.Toggle("Show Names?", easySel_Retro2D.showNames);
                
                EditorGUILayout.Space();

                EditorGUILayout.PropertyField(charNames, true);

                EditorGUILayout.Space();

            }//charTab

            easySel_Retro2D.autoSelTab = GUILayout.Toggle(easySel_Retro2D.autoSelTab, "Auto Select", GUI.skin.button);

            EditorGUILayout.Space();

            if(easySel_Retro2D.autoSelTab){

                EditorGUILayout.Space();

                easySel_Retro2D.useAutoSelect = EditorGUILayout.Toggle("Use Auto Select?", easySel_Retro2D.useAutoSelect);
                
                EditorGUILayout.Space();
                
                easySel_Retro2D.autoSelWait = EditorGUILayout.FloatField("Auto Select Wait", easySel_Retro2D.autoSelWait);
                EditorGUILayout.PropertyField(charButtons, true);

                EditorGUILayout.Space();

            }//autoSelTab
        
        }//tabs = user options
        
        if(easySel_Retro2D.tabs == 1){
        
            EditorGUILayout.Space();
        
            EditorGUILayout.PropertyField(audSource, true);
        
        }//tabs = references
        
        EditorGUILayout.Space();
        
        if(EditorGUI.EndChangeCheck()){

            serializedObject.ApplyModifiedProperties();

        }//EndChangeCheck
  
        if(GUI.changed){
            
            EditorUtility.SetDirty(easySel_Retro2D);
            
            if(!EditorApplication.isPlaying){
            
                EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            
            }//!isPlaying
        
        }//changed
        
        EditorGUILayout.EndVertical();
        
        EditorGUILayout.EndVertical();
        
    }//OnInspectorGUI

}
