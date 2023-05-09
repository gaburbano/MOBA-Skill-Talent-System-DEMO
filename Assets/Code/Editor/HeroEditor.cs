using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Hero))]
public class HeroEditor : Editor
{
    private static bool showInstructions = true;

    public override void OnInspectorGUI()
	{
        if(Application.isPlaying) {
            return;
        }

        Hero hero = (Hero)target;

        EditorGUILayout.Separator();

        EditorGUILayout.BeginHorizontal();
        GUI.backgroundColor = Colors.cyanColor;
        EditorGUILayout.Separator();
        if(PrefabUtility.GetPrefabParent(hero.gameObject) != null)
        if(GUILayout.Button("Apply", GUILayout.Width(70), GUILayout.Height(30), GUILayout.ExpandWidth(false)))
        {
            PrefabUtility.ApplyPrefabInstance(hero.gameObject, InteractionMode.AutomatedAction);
        }
        EditorGUILayout.Separator();

        GUI.backgroundColor = Colors.whiteColor;
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.Separator();

        EditorGUILayout.HelpBox("Follow the instructions below on how to add a new skill for this hero", MessageType.Info);
        EditorGUILayout.Separator();

        showInstructions = EditorGUILayout.Foldout(showInstructions, "Instructions");
        EditorGUILayout.Separator();

        if (showInstructions)
        {
            EditorGUILayout.HelpBox("- Click on 'Add New Skills' button to add new Skill", MessageType.None);
            EditorGUILayout.HelpBox("- Click on 'Remove Selected Skill' button to remove the selected skill in the list", MessageType.None);
            EditorGUILayout.HelpBox("- Click on 'Remove All' button to remove all skills for this hero ", MessageType.None);
        }


        EditorGUILayout.Separator ();

        hero.name = EditorGUILayout.TextField("Hero Name: ", hero.name);

        EditorGUILayout.LabelField("Hero Description:");
        hero.description = EditorGUILayout.TextArea(hero.description, GUILayout.Height(50));

        hero.moveSpeed = EditorGUILayout.Slider("Move Speed", hero.moveSpeed, 0, 10);

        hero.stopDistance = EditorGUILayout.Slider("Stop Distance", hero.stopDistance, 0, 1);

        hero.attackRange = EditorGUILayout.Slider("Attack Range", hero.attackRange, 0, 10);

        hero.attackCooldown = EditorGUILayout.Slider("Attack Cooldown", hero.attackCooldown, 0, 10);

        EditorGUILayout.Separator();

        GUILayout.BeginHorizontal ();
        GUI.backgroundColor = Colors.greenColor;         

        if(GUILayout.Button ("Add New Skills", GUILayout.Width (120), GUILayout.Height (20))) {
            hero.skills.Add(null);
        }

        GUI.backgroundColor = Colors.redColor;

        if(hero.skills.Count != 0)
        if(GUILayout.Button("Remove All", GUILayout.Width(120), GUILayout.Height(20)))
        {
            bool isOk = EditorUtility.DisplayDialog("Confirm Message", "Remove All Skills?", "YES", "NO");

            if(isOk)
            {
                hero.skills.Clear();
            }
        }
        GUILayout.EndHorizontal();

        EditorGUILayout.Separator();

        for(int x = 0; x < hero.skills.Count; x++) {
            EditorGUILayout.Foldout(true, "Skills[" + x + "]");

            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(10);
            EditorGUILayout.BeginVertical();

            EditorGUILayout.Separator();

            EditorGUILayout.BeginHorizontal();

            GUI.backgroundColor = Colors.redColor;
            if(GUILayout.Button("Remove", GUILayout.Width(70), GUILayout.Height(20)))
            {
                bool isOk = EditorUtility.DisplayDialog("Confirm Message", "Remove Selected Skill?", "YES", "NO");

                if(isOk)
                {
                    hero.skills.RemoveAt(x);
                    break;
                }
            }

            GUI.backgroundColor = Colors.whiteColor;
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.LabelField(hero.skills[x].name);

            EditorGUILayout.Separator();

            EditorGUILayout.LabelField("Skill Name: " + hero.skillSO.name);

            EditorGUILayout.LabelField("Skill Description: " + hero.skillSO.description);
            
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginDisabledGroup(x == hero.skills.Count - 1);
            if(GUILayout.Button("▼", GUILayout.Width(22), GUILayout.Height(22)))
            {
                MoveDown(x, hero);
            }
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(x - 1 < 0);
            if(GUILayout.Button("▲", GUILayout.Width(22), GUILayout.Height(22)))
            {
                MoveUp(x, hero);
            }
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Separator();
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(2));

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
        }

        if (GUI.changed)
        {
            DirtyUtil.MarkSceneDirty();
        }
    }

    private void MoveUp(int index, Hero hero)
    {
        var skill = hero.skills[index];
        hero.skills.RemoveAt(index);
        hero.skills.Insert(index - 1, skill);
    }

    private void MoveDown(int index, Hero hero)
    {
        var skill = hero.skills[index];
        hero.skills.RemoveAt(index);
        hero.skills.Insert(index + 1, skill);
    }
}