using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SanicballCore;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Sanicball.Data
{
    public class ActiveData : MonoBehaviour, ISerializationCallbackReceiver {
        #region Fields

        public List<RaceRecord> raceRecords = new List<RaceRecord>();

        //Pseudo-singleton pattern - this field accesses the current instance.
        private static ActiveData instance;

        //This data is saved to a json file
        private GameSettings gameSettings = new GameSettings();

        private KeybindCollection keybinds = new KeybindCollection();
        private MatchSettings matchSettings = MatchSettings.CreateDefault();

        //This data is set from the editor and remains constant
        // NOT ANYMORE YAHOO

        [SerializeField]
        private List<StageData> stages = new();

        [SerializeField]
        private List<CharacterData> characters = new();

        [Header("Static data")]
        [SerializeField]
        private GameJoltInfo gameJoltInfo;

        public List<DynamicData> dynamicDatas = new List<DynamicData>();

        [SerializeField]
        private GameObject christmasHat;
		[SerializeField]
        private GameObject halloweenHat;
		[SerializeField]
        private GameObject waluigiHat;
        [SerializeField]
        private Material eSportsTrail;
        [SerializeField]
        private GameObject eSportsHat;
        [SerializeField]
        private AudioClip eSportsMusic;
        [SerializeField]
        private ESportMode eSportsPrefab;

        
        #endregion Fields

        public static CharacterData[] characterDataInEditor;

        #region Properties

        public static GameSettings GameSettings { get { return instance.gameSettings; } }
        public static KeybindCollection Keybinds { get { return instance.keybinds; } }
        public static MatchSettings MatchSettings { get { return instance.matchSettings; } set { instance.matchSettings = value; } }
        public static List<RaceRecord> RaceRecords { get { return instance.raceRecords; } }

        public static StageData[] Stages { get { return instance.stages.ToArray(); } }
        public static CharacterData[] Characters { get { return instance.characters.ToArray(); } }
        public static GameJoltInfo GameJoltInfo { get { return instance.gameJoltInfo; } }
        public static GameObject ChristmasHat { get { return instance.christmasHat; } }
        public static GameObject HalloweenHat { get { return instance.halloweenHat; } }
        public static GameObject WaluigiHat { get { return instance.waluigiHat; } }
        public static Material ESportsTrail {get{return instance.eSportsTrail;}}
        public static GameObject ESportsHat {get{return instance.eSportsHat;}}
        public static AudioClip ESportsMusic {get{return instance.eSportsMusic;}}
        public static ESportMode ESportsPrefab {get{return instance.eSportsPrefab;}}
        //public static Song[] UgandaMusic {get{return instance.ugandaMusic;}}
        //public static Song[] ShrekMusic {get{return instance.shrekMusic;}}
        //public static Song[] KirbyMusic {get{return instance.kirbyMusic;} }
        //public static Song[] WahndewsMusic { get { return instance.windowsMusic; } }
        //public static Song[] KhumKhumMusic { get { return instance.khumkhumMusic; } },
        //public static Song[] MattMusic { get { return instance.mattMusic; } }

        public static List<AudioClip> Playlist { get; internal set; } = new List<AudioClip>();
        public static ActiveData singleton;

        public static bool ESportsFullyReady {
            get {
                bool possible = false;
                if (GameSettings.eSportsReady)
                {
                    Sanicball.Logic.MatchManager m = Logic.MatchManager.Instance;
                    if (m)
                    {
                        var players = m.Players;
                        foreach (var p in players) {
                            if (p.CtrlType != SanicballCore.ControlType.None) {
                                if (p.CharacterId == 13) 
                                {
                                    possible = true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                return possible;
            }
        }

        #endregion Properties

        #region Unity functions

        private void Awake()
        {
            if(instance)
            {
                Destroy(gameObject);
                return; // dont initialize anything
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAssets();

            SceneManager.sceneLoaded += (Scene scene, LoadSceneMode mode) => {
                if (scene.buildIndex == 1) { // Menu scene
                    if (DateTime.Now.Month is 6 or 7) {
                        SceneManager.LoadScene("Menu_Sonic1");
                    }
                }
            };
        }

        private async void LoadAssets() {
            stages.Clear();
            characters.Clear();
            Playlist.Clear();
            await Addressables.LoadAssetsAsync<AudioClip>("default", null).Task;
            await Addressables.LoadAssetsAsync<Texture2D>("default", null).Task;
            await Addressables.LoadAssetsAsync<Mesh>("default", null).Task;
            await Addressables.LoadAssetsAsync<GameObject>("default", null).Task;
            await Addressables.LoadAssetsAsync<Shader>("default", null).Task;
            await Addressables.LoadAssetsAsync<DynamicData>("default", OnLoadDynamicData).Task;
        }

        private void OnLoadDynamicData(DynamicData data) {
            dynamicDatas.Add(data);
            stages.AddRange(data.stages);
            characters.AddRange(data.characters);
            Playlist.AddRange(data.songs);    
        }
       

        private void OnEnable()
        {
            LoadAll();
            gameJoltInfo.Init();
        }

        private void OnApplicationQuit()
        {
            SaveAll();
        }

        #endregion Unity functions

        #region Saving and loading

        public void LoadAll()
        {
            Load("GameSettings.json", ref gameSettings);
            Load("GameKeybinds.json", ref keybinds);
            Load("MatchSettings.json", ref matchSettings);
            Load("Records.json", ref raceRecords);
        }

        public void SaveAll()
        {
            Save("GameSettings.json", gameSettings);
            Save("GameKeybinds.json", keybinds);
            Save("MatchSettings.json", matchSettings);
            Save("Records.json", raceRecords);
        }

        private void Load<T>(string filename, ref T output)
        {
            string fullPath = Path.Combine(Application.persistentDataPath, filename);
            if (File.Exists(fullPath))
            {
                //Load file contents
                string dataString;
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    dataString = sr.ReadToEnd();
                }
                //Deserialize from JSON into a data object
                try
                {
                    var dataObj = JsonConvert.DeserializeObject<T>(dataString);
                    //Make sure an object was created, this would't end well with a null value
                    if (dataObj != null)
                    {
                        output = dataObj;
                        Debug.Log(filename + " loaded successfully.");
                    }
                    else
                    {
                        Debug.LogError("Failed to load " + filename + ": file is empty.");
                    }
                }
                catch (JsonException ex)
                {
                    Debug.LogError("Failed to parse " + filename + "! JSON converter info: " + ex.Message);
                }
            }
            else
            {
                Debug.Log(filename + " has not been loaded - file not found.");
            }
        }

        private void Save(string filename, object objToSave)
        {
            var data = JsonConvert.SerializeObject(objToSave);
            using (StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + filename))
            {
                sw.Write(data);
            }
            Debug.Log(filename + " saved successfully.");
        }

        #endregion Saving and loading

        public void OnBeforeSerialize() {
            OnAfterDeserialize();
        }
        public void OnAfterDeserialize() {
            characterDataInEditor = characters.ToArray();
        }
    }
}
