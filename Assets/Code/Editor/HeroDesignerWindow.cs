using UnityEngine;
using UnityEditor;

public class HeroDesignerWindow : EditorWindow
{
    Texture2D headerSectionTexture;
    Texture2D assassinSectionTexture;
    Texture2D fighterSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D marksmanSectionTexture;
    Texture2D supportSectionTexture;
    Texture2D tankSectionTexture;

    Rect headerSection;
    Rect assassinSection;
    Rect fighterSection;
    Rect mageSection;
    Rect marksmanSection;
    Rect supportSection;
    Rect tankSection;

    GUISkin skin;

    static AssassinData assassinData;
    static FighterData fighterData;
    static MageData mageData;
    static MarksmanData marksmanData;
    static SupportData supportData;
    static TankData tankData;

    public static AssassinData AssassinInfo { get { return assassinData; } }
    public static FighterData FighterInfo { get { return fighterData; } }
    public static MageData MageInfo { get { return mageData; } }
    public static MarksmanData MarksmanInfo { get { return marksmanData; } }
    public static SupportData SupportInfo { get { return supportData; } }
    public static TankData TankInfo { get { return tankData; } }
    
    [MenuItem("Window/HeroDesigner")]
    static void OpenWindow() {
        HeroDesignerWindow heroDesignerWindow = (HeroDesignerWindow)GetWindow(typeof(HeroDesignerWindow));
        heroDesignerWindow.minSize = new Vector2(500,150);
        heroDesignerWindow.Show();
    }

    void OnEnable() {
        InitTextures();
        InitData();
        skin = Resources.Load<GUISkin>("HeroBuilder");
    }

    public static void InitData() {
        assassinData = (AssassinData)ScriptableObject.CreateInstance(typeof(AssassinData));
        fighterData = (FighterData)ScriptableObject.CreateInstance(typeof(FighterData));
        mageData = (MageData)ScriptableObject.CreateInstance(typeof(MageData));
        marksmanData = (MarksmanData)ScriptableObject.CreateInstance(typeof(MarksmanData));
        supportData = (SupportData)ScriptableObject.CreateInstance(typeof(SupportData));
        tankData = (TankData)ScriptableObject.CreateInstance(typeof(TankData));
    }

    void InitTextures() {
        headerSectionTexture = Resources.Load<Texture2D>("Background/Header");
        assassinSectionTexture = Resources.Load<Texture2D>("Background/Assassin");
        fighterSectionTexture = Resources.Load<Texture2D>("Background/Fighter");
        mageSectionTexture = Resources.Load<Texture2D>("Background/Mage");
        marksmanSectionTexture = Resources.Load<Texture2D>("Background/Marksman");
        supportSectionTexture = Resources.Load<Texture2D>("Background/Support");
        tankSectionTexture = Resources.Load<Texture2D>("Background/Tank");
    }

    void OnGUI() {
        DrawLayouts();
        DrawHeader();
        DrawAssassinSettings();
        DrawFighterSettings();
        DrawMageSettings();
        DrawMarksmanSettings();
        DrawSupportSettings();
        DrawTankSettings();
    }

    void DrawLayouts() {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 50;

        assassinSection.x = 0;
        assassinSection.y = 50;
        assassinSection.width = Screen.width / 6f;
        assassinSection.height = Screen.width - 50;

        fighterSection.x = Screen.width / 6f;
        fighterSection.y = 50;
        fighterSection.width = Screen.width / 6f;
        fighterSection.height = Screen.width - 50;

        mageSection.x = (Screen.width / 6f) * 2;
        mageSection.y = 50;
        mageSection.width = Screen.width / 6f;
        mageSection.height = Screen.width - 50;

        marksmanSection.x = (Screen.width / 6f) * 3;
        marksmanSection.y = 50;
        marksmanSection.width = Screen.width / 6f;
        marksmanSection.height = Screen.width - 50;

        supportSection.x = (Screen.width / 6f) * 4;
        supportSection.y = 50;
        supportSection.width = Screen.width / 6f;
        supportSection.height = Screen.width - 50;

        tankSection.x = (Screen.width / 6f) * 5;
        tankSection.y = 50;
        tankSection.width = Screen.width / 6f;
        tankSection.height = Screen.width - 50;

        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(assassinSection, assassinSectionTexture);
        GUI.DrawTexture(fighterSection, fighterSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(marksmanSection, marksmanSectionTexture);
        GUI.DrawTexture(supportSection, supportSectionTexture);
        GUI.DrawTexture(tankSection, tankSectionTexture);
    }

    void DrawHeader() {
        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Hero Designer", skin.GetStyle("Header1"));

        GUILayout.EndArea();
    }

    void DrawAssassinSettings() {
        GUILayout.BeginArea(assassinSection);

        GUILayout.Label("Assassin", skin.GetStyle("Text1"));

        if(GUILayout.Button("CREATE", GUILayout.Height(40))) {
            HeroSettings.OpenWindow(HeroSettings.HeroType.ASSASSIN);
        }

        GUILayout.EndArea();
    }

    void DrawFighterSettings() {
        GUILayout.BeginArea(fighterSection);

        GUILayout.Label("Fighter", skin.GetStyle("Text1"));

        if(GUILayout.Button("CREATE", GUILayout.Height(40))) {
            HeroSettings.OpenWindow(HeroSettings.HeroType.FIGHTER);
        }

        GUILayout.EndArea();
    }

    void DrawMageSettings() {
        GUILayout.BeginArea(mageSection);

        GUILayout.Label("Mage", skin.GetStyle("Text1"));

        if(GUILayout.Button("CREATE", GUILayout.Height(40))) {
            HeroSettings.OpenWindow(HeroSettings.HeroType.MAGE);
        }

        GUILayout.EndArea();
    }

    void DrawMarksmanSettings() {
        GUILayout.BeginArea(marksmanSection);

        GUILayout.Label("Marksman", skin.GetStyle("Text1"));

        if(GUILayout.Button("CREATE", GUILayout.Height(40))) {
            HeroSettings.OpenWindow(HeroSettings.HeroType.MARKSMAN);
        }

        GUILayout.EndArea();
    }

    void DrawSupportSettings() {
        GUILayout.BeginArea(supportSection);

        GUILayout.Label("Support", skin.GetStyle("Text1"));

        if(GUILayout.Button("CREATE", GUILayout.Height(40))) {
            HeroSettings.OpenWindow(HeroSettings.HeroType.SUPPORT);
        }

        GUILayout.EndArea();
    }

    void DrawTankSettings() {
        GUILayout.BeginArea(tankSection);

        GUILayout.Label("Tank", skin.GetStyle("Text1"));

        if(GUILayout.Button("CREATE", GUILayout.Height(40))) {
            HeroSettings.OpenWindow(HeroSettings.HeroType.TANK);
        }

        GUILayout.EndArea();
    }
}

public class HeroSettings : EditorWindow
{
    public enum HeroType {
        ASSASSIN,
        FIGHTER,
        MAGE,
        MARKSMAN,
        SUPPORT,
        TANK
    }
    static HeroType heroType;
    static HeroSettings window;

    public static void OpenWindow(HeroType heroSettings) {
        heroType = heroSettings;
        window = (HeroSettings)GetWindow(typeof(HeroSettings));
        window.minSize = new Vector2(250,200);
        window.Show();
    }

    void OnGUI() {
        switch(heroType) {
            case HeroType.ASSASSIN:
                DrawSettings((HeroData)HeroDesignerWindow.AssassinInfo);
                break;
            case HeroType.FIGHTER:
                DrawSettings((HeroData)HeroDesignerWindow.FighterInfo);
                break;
            case HeroType.MAGE:
                DrawSettings((HeroData)HeroDesignerWindow.MageInfo);
                break;
            case HeroType.MARKSMAN:
                DrawSettings((HeroData)HeroDesignerWindow.MarksmanInfo);
                break;
            case HeroType.SUPPORT:
                DrawSettings((HeroData)HeroDesignerWindow.SupportInfo);
                break;
            case HeroType.TANK:
                DrawSettings((HeroData)HeroDesignerWindow.TankInfo);
                break;
        }
    }

    void DrawSettings(HeroData heroData) {
        heroData.prefab = Resources.Load<GameObject>("HeroBase");
        heroData.prefab = (GameObject)EditorGUILayout.ObjectField(heroData.prefab, typeof(GameObject), false);

        heroData.name = EditorGUILayout.TextField("Hero Name: ", heroData.name);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Hero Description: ");
        heroData.description = EditorGUILayout.TextArea(heroData.description, GUILayout.Height(50));
        EditorGUILayout.EndHorizontal();

        heroData.maxHealth = EditorGUILayout.FloatField("Max Health: ", heroData.maxHealth);

        heroData.maxMana = EditorGUILayout.FloatField("Max Mana: ", heroData.maxMana);

        heroData.moveSpeed = EditorGUILayout.Slider("Move Speed", heroData.moveSpeed, 0, 10);

        heroData.stopDistance = EditorGUILayout.Slider("Stop Distance", heroData.stopDistance, 0, 1);

        heroData.attackRange = EditorGUILayout.Slider("Attack Range", heroData.attackRange, 0, 10);

        heroData.attackCooldown = EditorGUILayout.Slider("Attack Cooldown", heroData.attackCooldown, 0, 10);
    
        heroData.skills = EditorGUILayout.ObjectField("Attack Cooldown", heroData.skills);
    

        if(heroData.prefab == null) {
            EditorGUILayout.HelpBox("Hero needs a [Prefab] before it can be created", MessageType.Warning);
        }
        else if(GUILayout.Button("Save",  GUILayout.Height(30))) {
            SaveHeroData();
            window.Close();
        }
    }

    void SaveHeroData() {
        string prefabPath;
        string newPrefabPath = "Assets/Level/Prefab/Hero/";
        string dataPath = "Assets/Level/Resources/HeroData/Data/";

        switch(heroType) {
            case HeroType.ASSASSIN:
                dataPath += "Assassin/" + HeroDesignerWindow.AssassinInfo.name + ".asset";
                AssetDatabase.CreateAsset(HeroDesignerWindow.AssassinInfo, dataPath);

                newPrefabPath += "Assassin/" + HeroDesignerWindow.AssassinInfo.name + ".prefab";

                prefabPath = AssetDatabase.GetAssetPath(HeroDesignerWindow.AssassinInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject assassinPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if(!assassinPrefab.GetComponent<Assassin>())
                    assassinPrefab.AddComponent(typeof(Assassin));
                assassinPrefab.GetComponent<Assassin>().assassinData = HeroDesignerWindow.AssassinInfo;

                break;
            case HeroType.FIGHTER:
                dataPath += "Fighter/" + HeroDesignerWindow.FighterInfo.name + ".asset";
                AssetDatabase.CreateAsset(HeroDesignerWindow.FighterInfo, dataPath);

                newPrefabPath += "Fighter/" + HeroDesignerWindow.FighterInfo.name + ".prefab";

                prefabPath = AssetDatabase.GetAssetPath(HeroDesignerWindow.FighterInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject fighterPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if(!fighterPrefab.GetComponent<Fighter>())
                    fighterPrefab.AddComponent(typeof(Fighter));
                fighterPrefab.GetComponent<Fighter>().fighterData = HeroDesignerWindow.FighterInfo;

                break;
            case HeroType.MAGE:
                dataPath += "Mage/" + HeroDesignerWindow.MageInfo.name + ".asset";
                AssetDatabase.CreateAsset(HeroDesignerWindow.MageInfo, dataPath);

                newPrefabPath += "Mage/" + HeroDesignerWindow.MageInfo.name + ".prefab";

                prefabPath = AssetDatabase.GetAssetPath(HeroDesignerWindow.MageInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject magePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if(!magePrefab.GetComponent<Mage>())
                    magePrefab.AddComponent(typeof(Mage));
                magePrefab.GetComponent<Mage>().mageData = HeroDesignerWindow.MageInfo;

                break;
            case HeroType.MARKSMAN:
                dataPath += "Marksman/" + HeroDesignerWindow.MarksmanInfo.name + ".asset";
                AssetDatabase.CreateAsset(HeroDesignerWindow.MarksmanInfo, dataPath);

                newPrefabPath += "Marksman/" + HeroDesignerWindow.MarksmanInfo.name + ".prefab";

                prefabPath = AssetDatabase.GetAssetPath(HeroDesignerWindow.MarksmanInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject marksmanPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if(!marksmanPrefab.GetComponent<Marksman>())
                    marksmanPrefab.AddComponent(typeof(Marksman));
                marksmanPrefab.GetComponent<Marksman>().marksmanData = HeroDesignerWindow.MarksmanInfo;

                break;
            case HeroType.SUPPORT:
                dataPath += "Support/" + HeroDesignerWindow.SupportInfo.name + ".asset";
                AssetDatabase.CreateAsset(HeroDesignerWindow.SupportInfo, dataPath);

                newPrefabPath += "Support/" + HeroDesignerWindow.SupportInfo.name + ".prefab";

                prefabPath = AssetDatabase.GetAssetPath(HeroDesignerWindow.SupportInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject supportPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if(!supportPrefab.GetComponent<Support>())
                    supportPrefab.AddComponent(typeof(Support));
                supportPrefab.GetComponent<Support>().supportData = HeroDesignerWindow.SupportInfo;

                break;
            case HeroType.TANK:
                dataPath += "Tank/" + HeroDesignerWindow.TankInfo.name + ".asset";
                AssetDatabase.CreateAsset(HeroDesignerWindow.TankInfo, dataPath);

                newPrefabPath += "Tank/" + HeroDesignerWindow.TankInfo.name + ".prefab";

                prefabPath = AssetDatabase.GetAssetPath(HeroDesignerWindow.TankInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject tankPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if(!tankPrefab.GetComponent<Tank>())
                    tankPrefab.AddComponent(typeof(Tank));
                tankPrefab.GetComponent<Tank>().tankData = HeroDesignerWindow.TankInfo;

                break;
        }
    }
}