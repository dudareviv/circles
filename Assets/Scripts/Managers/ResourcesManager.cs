using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesManager : Singleton<ResourcesManager>
{
    public List<Sprite> Bodies = new List<Sprite>();
    public List<Sprite> Eyes = new List<Sprite>();
    public List<Sprite> Mouths = new List<Sprite>();

    public Sprite GetRandom(List<Sprite> sprites)
    {
        return sprites[Random.Range(0, sprites.Count - 1)];
    }
    
    private void Awake()
    {
        InitResources();
    }

    private void InitResources()
    {
        LoadResources(Bodies, "Monsters/Bodies");
        LoadResources(Eyes, "Monsters/Eyes");
        LoadResources(Mouths, "Monsters/Mouths");
    }

    private static void LoadResources(List<Sprite> list, string path)
    {
        var resources = Resources.LoadAll<Sprite>(path);
        
        foreach (var resource in resources)
        {
            list.Add(resource);
        }
    }
}