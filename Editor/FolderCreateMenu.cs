using System.IO;
using UnityEditor;
using UnityEngine;

namespace SunStudio
{
    public static class FolderCreateMenu
    {
        private const string TexturesFolder = "Textures";
        private const string MaterialsFolder = "Materials";
        private const string ModelsFolder = "Models";
        private const string PrefabsFolder = "Prefabs";
        private const string AtlasFolder = "Atlas";
        private const string SpritesFolder = "Sprites";
        private const string AnimationsFolder = "Animations";
        private const string FX = "FX";
        private const string SoundsFolder = "Sounds";
        private const string CubemapsFolder = "Cubemaps";
        private const string ScenesFolder = "Scenes";
        private const string MeshesFolder = "Meshes";

        private static string GetSelectedFolderPath()
        {
            
            Object selectedObject = Selection.activeObject;

            if (selectedObject != null)
            {
                string path = AssetDatabase.GetAssetPath(selectedObject);

                // 检查选中的对象是否是一个文件夹
                if (AssetDatabase.IsValidFolder(path))
                {
                    return path;
                }
                Debug.Log("Selected object is not a folder: " + path);
            }
            else
            {
                Debug.Log("No object selected.");
            }
            return string.Empty;
        }
        
        private static string CreateFolder(string folderRoot, string folderName)
        {
            var newFolder = $"{folderRoot}/{folderName}";
            if (!Directory.Exists(newFolder))
            {
                Directory.CreateDirectory(newFolder);
                AssetDatabase.Refresh();

                return newFolder;
            }
            Debug.LogError($"{newFolder} is exists!");
            return string.Empty;
        }

        private static string CreateFolder(string folderName)
        {
            return CreateFolder(GetSelectedFolderPath(), folderName);
        }

        [MenuItem("Assets/创建文件夹/图片", false, 500)]
        private static void CreateTexturesFolder()
        {
            CreateFolder(TexturesFolder);
        }
        
        [MenuItem("Assets/创建文件夹/材质", false, 500)]
        private static void CreateMaterialsFolder()
        {
            CreateFolder(MaterialsFolder);
        }

        [MenuItem("Assets/创建文件夹/预制体", false, 500)]
        private static void CreatePrefabsFolder()
        {
            CreateFolder(PrefabsFolder);
        }
        
        [MenuItem("Assets/创建文件夹/场景", false, 500)]
        private static void CreateScenesFolder()
        {
            CreateFolder(ScenesFolder);
        }

        [MenuItem("Assets/创建文件夹/图集", false, 500)]
        private static void CreateAtlasFolder()
        {
            CreateFolder(AtlasFolder);
        }

        [MenuItem("Assets/创建文件夹/模型", false, 500)]
        private static void CreateModelFolder()
        {
            var folderPath = CreateFolder(ModelsFolder);
            if(string.IsNullOrEmpty(folderPath))return;
            CreateFolder(folderPath, AnimationsFolder);
            CreateFolder(folderPath, MaterialsFolder);
            CreateFolder(folderPath, TexturesFolder);
        }

        [MenuItem("Assets/创建文件夹/特效", false, 500)]
        private static void CreateFXFolder()
        {
            CreateFolder(FX);
        }

        [MenuItem("Assets/创建文件夹/精灵", false, 500)]
        private static void CreateSpritesFolder()
        {
            CreateFolder(SpritesFolder);
        }

        [MenuItem("Assets/创建文件夹/动画", false, 500)]
        private static void CreateAnimationsFolder()
        {
            CreateFolder(AnimationsFolder);
        }
        
        [MenuItem("Assets/创建文件夹/声音", false, 500)]
        private static void CreateSoundsFolder()
        {
            var folderPath = CreateFolder(SoundsFolder);
            if (string.IsNullOrEmpty(folderPath)) return;
            CreateFolder(folderPath, "Bgm");
            CreateFolder(folderPath, "Sfx");
        }

        [MenuItem("Assets/创建文件夹/Cubemap", false, 500)]
        private static void CreateCubemapsFolder()
        {
            CreateFolder(CubemapsFolder);
        }
        
        [MenuItem("Assets/创建文件夹/网格", false, 500)]
        private static void CreateMeshesFolder()
        {
            CreateFolder(MeshesFolder);
        }

        
        

    }
}