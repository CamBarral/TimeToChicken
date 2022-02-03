using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootUI : MonoBehaviour
{
    public int _lootCount;
    public GameObject gameOverpanel;

    [SerializeField] private Text _loot_txt;
    [SerializeField] private Text _score_txt;

    void Start()
    {
        _lootCount = 0;
        _loot_txt.text = _lootCount.ToString();

        _score_txt.text = _lootCount.ToString();

        gameOverpanel.SetActive(false);
    }
    void Update()
    {

    }
    public void UpdateLoot(int loot)
    {
        _lootCount += loot;
        _loot_txt.text = _lootCount.ToString();
    }

    public void GameOver()
    {
        gameOverpanel.SetActive(true);
        _score_txt.text = _lootCount.ToString();
    }
}