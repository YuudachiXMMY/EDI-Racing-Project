using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[CustomEditor(typeof(EasySelector_Retro3D_v2))]
public class EasySelector_Retro3Dv2_Editor : Editor {


//////////////////////////
//
//      EDITOR DISPLAY
//
//////////////////////////
    
    
    EasySelector_Retro3D_v2 easySel_Retr3Dv2;
    GUISkin oldSkin;
    
    private void OnEnable() {
        
        easySel_Retr3Dv2 = (EasySelector_Retro3D_v2)target;
        
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
        
        GUILayout.BeginHorizontal("Retro 3D v2", "headerText");
        
        GUILayout.Label(t, "headerIcon");
        
        EditorGUILayout.EndHorizontal();
        
        GUILayout.Space(5);
        
        GUI.skin = oldSkin;
        
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        
        EditorGUILayout.Space();
        
        EditorGUILayout.BeginVertical();
        
        easySel_Retr3Dv2.tabs = GUILayout.SelectionGrid(easySel_Retr3Dv2.tabs, new string[] { "User Options", "Debug/Gizmos"}, 2);
        
        EditorGUI.BeginChangeCheck();
        
        SerializedProperty character = serializedObject.FindProperty("character");
        SerializedProperty spawnTrans = serializedObject.FindProperty("spawnTrans");
        SerializedProperty firstSelButton = serializedObject.FindProperty("firstSelButton");
        
        SerializedProperty audSource = serializedObject.FindProperty("audSource");
        
        SerializedProperty moveAudClip = serializedObject.FindProperty("moveAudClip");
        SerializedProperty randMoveClips = serializedObject.FindProperty("randMoveClips");
        
        SerializedProperty selectClip = serializedObject.FindProperty("selectClip");
        SerializedProperty lateSelectClip = serializedObject.FindProperty("lateSelectClip");
        
        SerializedProperty playFlash = serializedObject.FindProperty("playFlash");
        
        SerializedProperty charInsts_P1 = serializedObject.FindProperty("charInsts_P1");
        SerializedProperty charAnims_P1 = serializedObject.FindProperty("charAnims_P1");
        
        SerializedProperty charInsts_P2 = serializedObject.FindProperty("charInsts_P2");
        SerializedProperty charAnims_P2 = serializedObject.FindProperty("charAnims_P2");
        
        EditorGUILayout.Space();
        
        if(easySel_Retr3Dv2.tabs == 0){
        
            easySel_Retr3Dv2.startTab = GUILayout.Toggle(easySel_Retr3Dv2.startTab, "Start Options", GUI.skin.button);
            
            if(easySel_Retr3Dv2.startTab){

                EditorGUILayout.Space();
                
                easySel_Retr3Dv2.createInstance = EditorGUILayout.Toggle("Create Instance?", easySel_Retr3Dv2.createInstance);
                
            }//startTab

            EditorGUILayout.Space();
            
            easySel_Retr3Dv2.charTab = GUILayout.Toggle(easySel_Retr3Dv2.charTab, "Characters Options", GUI.skin.button);
            
            if(easySel_Retr3Dv2.charTab){
                
                EditorGUILayout.Space();
                
                EditorGUILayout.PropertyField(character, true);
                EditorGUILayout.PropertyField(spawnTrans, true);
                
                EditorGUILayout.Space();
                
                easySel_Retr3Dv2.useNames = EditorGUILayout.Toggle("Use Names?", easySel_Retr3Dv2.useNames);
                
                EditorGUILayout.Space();
                
                easySel_Retr3Dv2.useAutoSelect = EditorGUILayout.Toggle("Use Auto Select?", easySel_Retr3Dv2.useAutoSelect);
                easySel_Retr3Dv2.autoSelWait = EditorGUILayout.FloatField("Auto  SelWait", easySel_Retr3Dv2.autoSelWait);
                EditorGUILayout.PropertyField(firstSelButton, true);
                
            }//charTab
            
            EditorGUILayout.Space();
            
            easySel_Retr3Dv2.audioTab = GUILayout.Toggle(easySel_Retr3Dv2.audioTab, "Audio Options", GUI.skin.button);
            
            if(easySel_Retr3Dv2.audioTab){

                EditorGUILayout.Space();
                
                easySel_Retr3Dv2.useSounds = EditorGUILayout.Toggle("Use Sounds?", easySel_Retr3Dv2.useSounds);
                EditorGUILayout.PropertyField(audSource, true);
                
                EditorGUILayout.Space();
                
                easySel_Retr3Dv2.useMoveClip = EditorGUILayout.Toggle("Use Move Clip?", easySel_Retr3Dv2.useMoveClip);
                
                if(easySel_Retr3Dv2.useMoveClip){
                
                    easySel_Retr3Dv2.randomMoveClip = EditorGUILayout.Toggle("Random Move Clip?", easySel_Retr3Dv2.randomMoveClip);
                    EditorGUILayout.PropertyField(moveAudClip, true);
                    
                    if(easySel_Retr3Dv2.randomMoveClip){
                    
                        EditorGUILayout.PropertyField(randMoveClips, true);
                
                    }//randomMoveClip
                    
                }//useMoveClip

                EditorGUILayout.Space();
                
                easySel_Retr3Dv2.useSelectClip = EditorGUILayout.Toggle("Use Select Clip?", easySel_Retr3Dv2.useSelectClip);
                
                if(easySel_Retr3Dv2.useSelectClip){
                
                    EditorGUILayout.PropertyField(selectClip, true);
                
                }//useSelectClip
                
                EditorGUILayout.Space();
                
                easySel_Retr3Dv2.useLateSelect = EditorGUILayout.Toggle("Use Late Select?", easySel_Retr3Dv2.useLateSelect);
                
                if(easySel_Retr3Dv2.useLateSelect){
                
                    EditorGUILayout.PropertyField(lateSelectClip, true);
                    easySel_Retr3Dv2.lateSelectWait = EditorGUILayout.FloatField("Late Select Wait", easySel_Retr3Dv2.lateSelectWait);
                
                }//useLateSelect
                
            }//audioTab
            
            EditorGUILayout.Space();
            
            easySel_Retr3Dv2.flashTab = GUILayout.Toggle(easySel_Retr3Dv2.flashTab, "Flash Options", GUI.skin.button);
            
            if(easySel_Retr3Dv2.flashTab){

                EditorGUILayout.Space();
                
                easySel_Retr3Dv2.useFlash = EditorGUILayout.Toggle("Use Screen Flash?", easySel_Retr3Dv2.useFlash);
                EditorGUILayout.PropertyField(playFlash, true);
                
            }//flashTab
        
        }//tabs = user options
        
        if(easySel_Retr3Dv2.tabs == 1){
        
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Automatic Values", EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.Space();
            
            easySel_Retr3Dv2.playerCount = EditorGUILayout.IntField("Player Count", easySel_Retr3Dv2.playerCount);
            easySel_Retr3Dv2.tempPlayer = EditorGUILayout.IntField("Temp Player", easySel_Retr3Dv2.tempPlayer);
            
            EditorGUILayout.Space();
            
            EditorGUILayout.PropertyField(charInsts_P1, true);
            EditorGUILayout.PropertyField(charAnims_P1, true);
            
            EditorGUILayout.Space();
            
            EditorGUILayout.PropertyField(charInsts_P2, true);
            EditorGUILayout.PropertyField(charAnims_P2, true);
            
            EditorGUILayout.Space();
            
            easySel_Retr3Dv2.play1CurSel = EditorGUILayout.IntField("Play 1 Cur Sel", easySel_Retr3Dv2.play1CurSel);
            easySel_Retr3Dv2.play2CurSel = EditorGUILayout.IntField("Play 2 Cur Sel", easySel_Retr3Dv2.play2CurSel);
            
            easySel_Retr3Dv2.play1Sel = EditorGUILayout.Toggle("Play 1 Sel", easySel_Retr3Dv2.play1Sel);
            easySel_Retr3Dv2.play2Sel = EditorGUILayout.Toggle("Play 2 Sel", easySel_Retr3Dv2.play2Sel);
            
            EditorGUILayout.Space();
            
            easySel_Retr3Dv2.flash = EditorGUILayout.Toggle("Flash", easySel_Retr3Dv2.flash);
            easySel_Retr3Dv2.flashColorUpdate = EditorGUILayout.Toggle("Flash Color Update", easySel_Retr3Dv2.flashColorUpdate);
            easySel_Retr3Dv2.flashLock = EditorGUILayout.Toggle("Flash Lock", easySel_Retr3Dv2.flashLock);
        
        }//tabs = auto
        
        EditorGUILayout.Space();
        
        if(EditorGUI.EndChangeCheck()){

            serializedObject.ApplyModifiedProperties();

        }//EndChangeCheck
  
        if(GUI.changed){
            
            EditorUtility.SetDirty(easySel_Retr3Dv2);
            
            if(!EditorApplication.isPlaying){
            
                EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            
            }//!isPlaying
        
        }//changed
        
        EditorGUILayout.EndVertical();
        
        EditorGUILayout.EndVertical();
        
    }//OnInspectorGUI

}
