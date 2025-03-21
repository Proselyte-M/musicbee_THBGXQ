using System.Collections.Generic;
using MusicBeePlugin;

public class Settings
{
    private readonly MusicBeeApiInterface _mbApi;
    private const string Prefix = "AlbumPanel_";

    public int ColumnWidth1 { get; set; } = 200;
    public int ColumnWidth2 { get; set; } = 150;
    public int ColumnWidth3 { get; set; } = 80;
    public string SortField { get; set; } = "Album";
    public bool DescendingSort { get; set; }

    public Settings(MusicBeeApiInterface mbApi)
    {
        _mbApi = mbApi;
        Load();
    }

    public void Load()
    {
        ColumnWidth1 = GetInt(nameof(ColumnWidth1), 200);
        ColumnWidth2 = GetInt(nameof(ColumnWidth2), 150);
        ColumnWidth3 = GetInt(nameof(ColumnWidth3), 80);
        SortField = GetString(nameof(SortField), "Album");
        DescendingSort = GetBool(nameof(DescendingSort));
    }

    public void Save()
    {
        SetInt(nameof(ColumnWidth1), ColumnWidth1);
        SetInt(nameof(ColumnWidth2), ColumnWidth2);
        SetInt(nameof(ColumnWidth3), ColumnWidth3);
        SetString(nameof(SortField), SortField);
        SetBool(nameof(DescendingSort), DescendingSort);
        _mbApi.Setting_PersistStorage();
    }

    private int GetInt(string key, int defaultValue) => int.TryParse(_mbApi.Setting_GetPersistentStorageValue(Prefix + key), out var result) ? result : defaultValue;
    private void SetInt(string key, int value) => _mbApi.Setting_SetPersistentStorageValue(Prefix + key, value.ToString());

    private string GetString(string key, string defaultValue) => _mbApi.Setting_GetPersistentStorageValue(Prefix + key) ?? defaultValue;
    private void SetString(string key, string value) => _mbApi.Setting_SetPersistentStorageValue(Prefix + key, value);

    private bool GetBool(string key) => _mbApi.Setting_GetPersistentStorageValue(Prefix + key) == "true";
    private void SetBool(string key, bool value) => _mbApi.Setting_SetPersistentStorageValue(Prefix + key, value ? "true" : "false");
}