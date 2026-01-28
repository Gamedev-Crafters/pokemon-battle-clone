using UnityEditor;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.CustomAssetsImporter.Editor
{
    public class SpriteImportPostprocessor : AssetPostprocessor
    {
        private const string BasePath = "Assets/Pokemon Battle Clone/Sprites/Pokemons/";

        private void OnPreprocessTexture()
        {
            var importer = assetImporter as TextureImporter;

            if (!ShouldApplySettings()) return;

            ApplySpriteSettings(importer);
        }

        private bool ShouldApplySettings()
        {
            return assetPath.StartsWith(BasePath);
        }

        private void ApplySpriteSettings(TextureImporter importer)
        {
            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Single;
            importer.spritePixelsPerUnit = 100;
            importer.wrapMode = TextureWrapMode.Clamp;
            importer.filterMode = FilterMode.Point;
            importer.mipmapEnabled = false;
            importer.alphaIsTransparency = true;
            importer.textureCompression = TextureImporterCompression.Uncompressed;
        }
    }
}