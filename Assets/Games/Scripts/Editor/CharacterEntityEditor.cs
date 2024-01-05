using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterEntity))]
public class CharacterEntityEditor :Editor
{
    CharacterEntity characterEntity;

    private void OnEnable()
    {
        characterEntity = target as CharacterEntity;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (characterEntity.ImageSprite == null)
            return;

        GUILayout.Label("Preview");
        Texture2D texture = AssetPreview.GetAssetPreview(characterEntity.ImageSprite);
        GUILayout.Label("", GUILayout.Height(100), GUILayout.Width(100));
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    }
}
