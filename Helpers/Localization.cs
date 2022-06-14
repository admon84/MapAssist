using MapAssist.Types;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MapAssist.Helpers
{
    public static class Localization
    {
        public static List<LocalizedObj> _itemNames;
        public static List<LocalizedObj> _itemRunes;
        public static List<LocalizedObj> _levels;
        public static List<LocalizedObj> _monsters;
        public static List<LocalizedObj> _npcs;
        public static List<LocalizedObj> _objects;
        public static List<LocalizedObj> _shrines;

        public static void LoadLocalizationData()
        {
            LoadItemNames();
            LoadItemRunes();
            LoadLevels();
            LoadMonsters();
            LoadNpcs();
            LoadShrines();
            LoadObjects();
        }

        private static void LoadItemNames()
        {
            LoadObjectsFromResource(Properties.Resources.ItemNames, ref _itemNames);

            foreach (var item in _itemNames)
            {
                Items.LocalizedItems.Add(item.Key, item);
            }
        }

        private static void LoadItemRunes()
        {
            LoadObjectsFromResource(Properties.Resources.ItemRunes, ref _itemRunes);

            foreach (var item in _itemRunes)
            {
                if (item.Key.StartsWith("Runeword"))
                {
                    Items.LocalizedRunewords.Add((ushort)item.ID, item);
                }
                else
                {
                    Items.LocalizedRunes.Add(item.Key, item);
                }
            }
        }

        private static void LoadLevels()
        {
            LoadObjectsFromResource(Properties.Resources.Levels, ref _levels);

            foreach (var item in _levels)
            {
                AreaExtensions.LocalizedAreas.Add(item.Key, item);
            }
        }

        private static void LoadMonsters()
        {
            LoadObjectsFromResource(Properties.Resources.Monsters, ref _monsters);

            foreach (var item in _monsters)
            {
                NpcExtensions.LocalizedNpcs.Add(item.Key, item);
            }
        }

        private static void LoadNpcs()
        {
            LoadObjectsFromResource(Properties.Resources.Npcs, ref _npcs);

            foreach (var item in _npcs)
            {
                NpcExtensions.LocalizedNpcs.Add(item.Key, item);
            }
        }

        private static void LoadShrines()
        {
            LoadObjectsFromResource(Properties.Resources.Shrines, ref _shrines);

            foreach (var item in _shrines)
            {
                Shrine.LocalizedShrines.Add(item.Key, item);
            }
        }

        private static void LoadObjects()
        {
            LoadObjectsFromResource(Properties.Resources.Objects, ref _objects);

            foreach (var item in _objects)
            {
                GameObjects.LocalizedObjects.Add(item.Key, item);
            }
        }

        private static void LoadObjectsFromResource(byte[] resource, ref List<LocalizedObj> data)
        {
            using (var Stream = new MemoryStream(resource))
            {
                using (var streamReader = new StreamReader(Stream))
                {
                    var jsonString = streamReader.ReadToEnd();
                    data = JsonConvert.DeserializeObject<List<LocalizedObj>>(jsonString);
                }
            }
        }
    }

    public class LocalizedObj
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public string enUS { get; set; }
        public string zhTW { get; set; }
        public string deDE { get; set; }
        public string esES { get; set; }
        public string frFR { get; set; }
        public string itIT { get; set; }
        public string koKR { get; set; }
        public string plPL { get; set; }
        public string esMX { get; set; }
        public string jaJP { get; set; }
        public string ptBR { get; set; }
        public string ruRU { get; set; }
        public string zhCN { get; set; }
    }
}
