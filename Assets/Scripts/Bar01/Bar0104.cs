using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar0104: MonoBehaviour
{
    public string MakeRandomNunbers { get; private set; }
    private const string KeyFasetestPlayTime = "FastestPlayTime";
    private enum GameState
    {
        Prepare = 1,
        Start,
        finish
    }

    private int _nextCardNumber = 1;
    private float _playTime = 0;
    private float _fastestPlayTime = 0;
    private GameState _gameState = GameState.Prepare;

    // Use this for initialization
    public GameObject Cards;
    private object _fastestplayTime;

    public string KeyFastestPlayTime { get; private set; }

    void Start()
    {
        _fastestPlayTime = PlayerPrefs.GetFloat(KeyFasetestPlayTime, 5999.999f);
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameState == GameState.Start)
        {
            _playTime += Time.deltaTime;
            ClickCard();
            UpdatePlayTime();
        }
    }

    /// <summary>
    /// カードの生成
    /// </summary>
    private void MakeCards()
    {

        int count = 0;
        int[] randomNumbers = RandomNunbers();

        var cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
        var cardsObject = GameObject.Find("Cards");

        for (var i = 0; i < 6; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                for (var a = 0; a < 4; a++)
                {
                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector4(
                        i * 1.8f - 5.3f,
                        j * 1.8f - 3.5f,
                        a * 1.8f - 3.5f,
                        0);
                    cardObject.transform.parent = Cards.transform;

                    var card = cardObject.GetComponent<Card>();
                    card.Number = randomNumbers[count];
                    card.TurnCardFaceDown();
                    count++;

                }
            }
        }
        for (var b = 0; b < 3; b++)
        {
            for (var c = 0; c < 2; c++)
            {
                for (var d = 0; d < 2; d++)
                {
                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector4(
                        b * 1.8f - 5.3f,
                        c * 1.8f - 3.5f,
                        d * 1.8f - 3.5f,
                        0);
                    cardObject.transform.parent = Cards.transform;

                    var card = cardObject.GetComponent<Card>();
                    card.Number = randomNumbers[count];
                    card.TurnCardFaceDown();
                    count++;
                }
            }
        }
    }

    private int[] RandomNunbers()
    {
        int[] values = new int[52];
        for (int z = 0; z < 52; z++)
        {
            values[z] = z + 1;
        }

        var counter = 0;
        while (counter < 52)
        {
            var index = Random.Range(counter, values.Length);
            var tmp = values[counter];
            values[counter] = values[index];
            values[index] = tmp;

            counter++;
        }
        return values;
    }


    public void ClickStartButton()
    {
        var cardsobject = GameObject.Find("Cards").transform;
        foreach (Transform cardobject in cardsobject.transform)
        {
            var card = cardobject.GetComponent<Card>();
            card.TurnCardFaceUp();
        }
        _gameState = GameState.Start;
    }

    public void ClickResetButton()
    {
        InitGame();
    }

    private void ClickCard()
    {
        //マウスクリックの判定
        if (!Input.GetMouseButtonDown(0)) return;

        //クリックされた位置を取得
        var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Collider2D上のクリックの判定
        if (!Physics2D.OverlapPoint(tapPoint)) return;

        //クリックした位置のオブジェクトを取得
        var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
        if (!hitObject) return;

        //クリックされたカードスクリプトを取得
        var card = hitObject.collider.gameObject.GetComponent<Card>();
        Debug.Log("hit object is " + card.Number);

        //次にクリックされるべきカードが判定
        if (_nextCardNumber != card.Number) return;

        //カードが反転する
        card.TurnCardFaceDown();
        _nextCardNumber++;

        if (_nextCardNumber <= 52) return;

        _gameState = GameState.finish;

        if (_fastestPlayTime <= _playTime) return;

        _fastestPlayTime = _playTime;
        UpdateFastestPlayTime();

        PlayerPrefs.SetFloat(KeyFastestPlayTime, _fastestPlayTime);
    }
    private void UpdatePlayTime()
    {
        var timelabel = GameObject.Find("Canvas/Panel/PlayTimeLabel").transform;
        timelabel.GetComponent<Text>().text = _playTime.ToString();
    }

    private void UpdateFastestPlayTime()
    {
        var timelabel = GameObject.Find("Canvas/Panel/FastestPlayTimeLabel").transform;
        timelabel.GetComponent<Text>().text = _fastestPlayTime.ToString();
    }
    private void InitGame()
    {
        _nextCardNumber = 1;
        _playTime = 0;
        _gameState = GameState.Prepare;

        RemoveCards();
        MakeCards();
        UpdatePlayTime();
    }

    private void RemoveCards()
    {
        var cardsobject = GameObject.Find("back").transform;
        foreach (Transform cardobject in cardsobject.transform)
        {
            Destroy(cardobject.gameObject);
        }
    }
}
