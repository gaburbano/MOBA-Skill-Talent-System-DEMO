using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Hero))]
public class HeroEditor : Editor
{
    public override void OnInspectorGUI ()
	{
        if (Application.isPlaying) {
            return;
        }

        Hero hero = (Hero)target;

        EditorGUILayout.Separator();

        EditorGUILayout.BeginHorizontal();
        GUI.backgroundColor = Colors.cyanColor;
        EditorGUILayout.Separator();
        if(PrefabUtility.GetPrefabParent(hero.gameObject)!=null)
        if (GUILayout.Button("Apply", GUILayout.Width(70), GUILayout.Height(30), GUILayout.ExpandWidth(false)))
        {
            PrefabUtility.ApplyPrefabInstance(hero.gameObject, InteractionMode.AutomatedAction);
        }
        GUI.backgroundColor = Colors.whiteColor;
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Separator ();

        hero.name = EditorGUILayout.TextField("Hero Name: ", hero.name);

        EditorGUILayout.LabelField("Hero Description:");
        hero.description = EditorGUILayout.TextArea(hero.description, GUILayout.Height(50));

        hero.moveSpeed = EditorGUILayout.Slider("Move Speed", hero.moveSpeed, 0, 10);

        hero.stopDistance = EditorGUILayout.Slider("Stop Distance", hero.stopDistance, 0, 1);

        hero.attackRange = EditorGUILayout.Slider("Attack Range", hero.attackRange, 0, 10);

        hero.attackCooldown = EditorGUILayout.Slider("Attack Cooldown", hero.attackCooldown, 0, 10);
    }
}