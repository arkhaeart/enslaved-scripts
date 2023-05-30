using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;
using Zenject;

public class UIFoldersManager : MonoBehaviour
{
    public RectTransform inventory, interaction, social, attributes, character;
    Dictionary<int, RectTransform> folders;
    [Inject]
    public void Initialize(InputManager inputManager)
    {
        folders = new Dictionary<int, RectTransform>
        {
            [0] = character,
            [1] = attributes,
            [2] = social,
            [3] = interaction,
            [4] = inventory
        };
        foreach(var rect in folders.Values)
        {
            ToggleFolder(rect);
        }
        inputManager.HotKeyFoldersResponse += FolderResponse;
    }
    public void FolderResponse(int ID)
    {
        ToggleFolder(folders[ID]);
    }
    void ToggleFolder(RectTransform folder)
    {
        folder.gameObject.SetActive(!folder.gameObject.activeSelf);
    }
}
