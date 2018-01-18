using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Scripts.Bar01
{
    public class StartCardSetSaveData : ISerializationCallbackReceiver
    {
        public static StartCardSetSaveData instance = null;
        public static StartCardSetSaveData Instance
        {
            get
            {
                if(instance == null)
                {
                    Load();
                }
                return instance;
            }
        }

        [SerializeField]
        private static string jsonText = "";

        //----------------------------------------------
        //保存されるデータ
        //----------------------------------------------

        public Card.CardTypes[] deckCardsType = new Card.CardTypes[24];
        public int[] deckCardsNumber = new int[24];

        public Card.CardTypes stage1CaadsType;
        public int stage1CardNumber;

        public Card.CardTypes[] stage2CardsTyoe = new Card.CardTypes[2];
        public int[] stage2CardsNumber = new int[2];

        public Card.CardTypes[] stage3CardsType = new Card.CardTypes[3];
        public int[] stage3CardsNumber = new int[3];

        public Card.CardTypes[] stage4CardType = new Card.CardTypes[4];
        public int[] stage4CardNumber = new int[4];

        public Card.CardTypes[] stage5CardType = new Card.CardTypes[5];
        public int[] stage5CardNumber = new int[5];

        public Card.CardTypes[] stage6CardType = new Card.CardTypes[6];
        public int[] stage6CardNumber = new int[6];

        public Card.CardTypes[] stage7CardType = new Card.CardTypes[7];
        public int[] stgae7CardNumber = new int[7];

        //-----------------------------------------------
        //シリアライズ、デシリアライズ時のコールバック
        //-----------------------------------------------

        public void OnAfterDeserialize()
        {
            
        }

        public void OnBeforeSerialize()
        {
            
        }

        //引数のオブジェクトをシリアライズして返す
        private static string Serialize<T> (T obj)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, obj);
            return Convert.ToBase64String(memoryStream.GetBuffer());
        }

        //引数のテキストを指定されたクラスにデシリアライズして返す
        private static T Deserialize<T> (string str)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(str));
            return (T)binaryFormatter.Deserialize(memoryStream);
        }

        //-----------------------------------------------------------------------
        //取得
        //-----------------------------------------------------------------------

        //データの再読み込み
        public void Reload()
        {
            JsonUtility.FromJsonOverwrite(GetJson(),this);
        }

        //データを読み込む
        private static void Load()
        {
            instance = JsonUtility.FromJson<StartCardSetSaveData>(GetJson());
        }

        //保存しているJsonを取得する
        private static string GetJson()
        {
            if (!string.IsNullOrEmpty(jsonText))
            {
                return jsonText;
            }

            //Jsonを保存している場所のパスを取得
            string filePath = GetSaveFilePath();
            //Jsonが存在するか調べてなければ新たなクラスを作成し、それをJsonに変換する。
            if (File.Exists(filePath))
            {
                jsonText = File.ReadAllText(filePath);
            }
            else
            {
                jsonText = JsonUtility.ToJson(new StartCardSetSaveData());
            }
            return jsonText;
        }

        //---------------------------------------------------
        //保存
        //---------------------------------------------------
        public void Save()
        {
            jsonText = JsonUtility.ToJson(this);
            File.WriteAllText(GetSaveFilePath(), jsonText);
        }

        //---------------------------------------------------
        //削除
        //---------------------------------------------------
        public void Delete()
        {
            jsonText = JsonUtility.ToJson(new StartCardSetSaveData());
            Reload();
        }

        //---------------------------------------------------
        //保存先のパス
        //---------------------------------------------------

        //保存先のパスを取得
        private static string GetSaveFilePath()
        {
            string filePath = "";

            filePath = "Resources/Prefabs/Bar01/StartCardData.json";
            return filePath;
        }
    }
}

