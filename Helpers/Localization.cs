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
            using (var Stream = new MemoryStream(Properties.Resources.ItemNames))
            {
                using (var streamReader = new StreamReader(Stream))
                {
                    var jsonString = streamReader.ReadToEnd();
                    _itemNames = JsonConvert.DeserializeObject<List<LocalizedObj>>(jsonString);
                }
            }

            foreach (var item in _itemNames)
            {
                Items.LocalizedItems.Add(item.Key, item);
            }
        }

        private static void LoadItemRunes()
        {
            using (var Stream = new MemoryStream(Properties.Resources.ItemRunes))
            {
                using (var streamReader = new StreamReader(Stream))
                {
                    var jsonString = streamReader.ReadToEnd();
                    _itemRunes = JsonConvert.DeserializeObject<List<LocalizedObj>>(jsonString);
                }
            }

            foreach (var item in _itemRunes)
            {
                Items.LocalizedRunes.Add(item.Key, item);
                Items.LocalizedRunewords.Add((ushort)item.ID, item);
            }
        }

        private static void LoadLevels()
        {
            using (var Stream = new MemoryStream(Properties.Resources.Levels))
            {
                using (var streamReader = new StreamReader(Stream))
                {
                    var jsonString = streamReader.ReadToEnd();
                    _levels = JsonConvert.DeserializeObject<List<LocalizedObj>>(jsonString);
                }
            }

            foreach (var item in _levels)
            {
                AreaExtensions.LocalizedAreas.Add(item.Key, item);
            }
        }

        private static void LoadMonsters()
        {
            using (var Stream = new MemoryStream(Properties.Resources.Monsters))
            {
                using (var streamReader = new StreamReader(Stream))
                {
                    var jsonString = streamReader.ReadToEnd();
                    _monsters = JsonConvert.DeserializeObject<List<LocalizedObj>>(jsonString);
                }
            }

            foreach (var item in _monsters)
            {
                NpcExtensions.LocalizedNpcs.Add(item.Key, item);
            }
        }

        private static void LoadNpcs()
        {
            using (var Stream = new MemoryStream(Properties.Resources.Npcs))
            {
                using (var streamReader = new StreamReader(Stream))
                {
                    var jsonString = streamReader.ReadToEnd();
                    _npcs = JsonConvert.DeserializeObject<List<LocalizedObj>>(jsonString);
                }
            }

            foreach (var item in _npcs)
            {
                NpcExtensions.LocalizedNpcs.Add(item.Key, item);
            }
        }

        private static void LoadShrines()
        {
            using (var Stream = new MemoryStream(Properties.Resources.Shrines))
            {
                using (var streamReader = new StreamReader(Stream))
                {
                    var jsonString = streamReader.ReadToEnd();
                    _shrines = JsonConvert.DeserializeObject<List<LocalizedObj>>(jsonString);
                }
            }

            foreach (var item in _shrines)
            {
                Shrine.LocalizedShrines.Add(item.Key, item);
            }
        }

        private static void LoadObjects()
        {
            using (var Stream = new MemoryStream(Properties.Resources.Objects))
            {
                using (var streamReader = new StreamReader(Stream))
                {
                    var jsonString = streamReader.ReadToEnd();
                    _objects = JsonConvert.DeserializeObject<List<LocalizedObj>>(jsonString);
                }
            }

            foreach (var item in _objects)
            {
                GameObjects.LocalizedObjects.Add(item.Key, item);
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
