#nullable enable
using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;

public class UnityServicesManager: MonoBehaviour
{
    private static Dictionary<string, string> userData = new Dictionary<string, string>();

    public static async void Init()
    {
        userData = await CloudSaveService.Instance.Data.LoadAllAsync();
    }

    public static async void LoadData()
    {
        userData = await CloudSaveService.Instance.Data.LoadAllAsync();
    }

    public static async void Save(string key, object value)
    {
        var data = new Dictionary<string, object>{ { key, value } };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
        var newData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> {key});
        userData[key] = newData[key];
    }

    public static async void Delete(string key)
    {
        await CloudSaveService.Instance.Data.ForceDeleteAsync(key);
        userData.Remove(key);
    }
    
    public static string? Get(string key)
    {
        return userData.ContainsKey(key) ? userData[key] : null;
    }
}
