using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Localization.Settings;

using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;

namespace TavernsRenamed
{
    internal class TavernsRenamedLoader : MonoBehaviour
    {
        private static Mod mod;
        static Dictionary<string, string> textDataBase = null;

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;

            var go = new GameObject(mod.Title);
            go.AddComponent<TavernsRenamedLoader>();
        }

        void Awake()
        {
            LoadTextData();

            mod.IsReady = true;
        }

        static void LoadTextData()
        {
            var locationsStrings = LocalizationSettings.StringDatabase.GetTable(TextManager.Instance.runtimeLocationsStrings);

            if (locationsStrings == null)
            {
                return;
            }

            const string csvFilename = "TavernsRenamedData.csv";

            if (textDataBase == null)
            {
                textDataBase = StringTableCSVParser.LoadDictionary(csvFilename);
            }

            foreach (var item in textDataBase)
            {
                locationsStrings.AddEntry(item.Key, item.Value);
            }

            return;
        }
    }
}
