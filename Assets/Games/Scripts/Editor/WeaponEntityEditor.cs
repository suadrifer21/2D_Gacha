using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WeaponEntity))]
public class WeaponEntityEditor : Editor
{ 
    WeaponEntity weaponEntity;

    private void OnEnable()
    {
        weaponEntity = target as WeaponEntity;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (weaponEntity.ImageSprite == null)
            return;

        GUILayout.Label("Preview");
        Texture2D texture = AssetPreview.GetAssetPreview(weaponEntity.ImageSprite);
        GUILayout.Label("", GUILayout.Height(100), GUILayout.Width(100));
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    }
}
