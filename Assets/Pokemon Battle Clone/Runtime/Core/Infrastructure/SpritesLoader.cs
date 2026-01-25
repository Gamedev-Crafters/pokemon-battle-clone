using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public enum SpriteType
    {
        Back, Front, Icon
    }
    
    public class SpritesLoader
    {
        private readonly string _basePath;
        private const string BackFolder = "Back";
        private const string FrontFolder = "Front";
        private const string IconFolder = "Icon";
        
        public SpritesLoader(string basePath)
        {
            _basePath = basePath;
        }

        public Dictionary<uint, Sprite> LoadAllFront(IList<uint> ids) => LoadAllOfType(ids, SpriteType.Front);
        public Dictionary<uint, Sprite> LoadAllBack(IList<uint> ids) => LoadAllOfType(ids, SpriteType.Back);
        public Dictionary<uint, Sprite> LoadAllIcon(IList<uint> ids) => LoadAllOfType(ids, SpriteType.Icon);
        
        private Dictionary<uint, Sprite> LoadAllOfType(IList<uint> ids, SpriteType type)
        {
            var sprites = new Dictionary<uint, Sprite>();
            foreach (var id in ids)
                sprites.Add(id, Load(id, type));
            return sprites;
        }
        
        private Sprite Load(uint id, SpriteType type)
        {
            string subFolder = type switch
            {
                SpriteType.Back => BackFolder,
                SpriteType.Front => FrontFolder,
                SpriteType.Icon => IconFolder,
                _ => ""
            };
            var path = $"{_basePath}/{subFolder}/{id}.png";

            var sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
            
            if (sprite == null)
                Debug.Log($"Sprite with id:{id} was not found, at route:{path}");
            
            return sprite;
        }
    }
}