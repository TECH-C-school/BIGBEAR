using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace Assets.Scripts.Bar01
{
    public class ManualCreateStage : MonoBehaviour
    {
        private const int DeckArrayMax = 24;
        private const int StageArray1Max = 1;
        private const int StageArray2Max = 2;
        private const int StageArray3Max = 3;
        private const int StageArray4Max = 4;
        private const int StageArray5Max = 5;
        private const int StageArray6Max = 6;
        private const int StageArray7Max = 7;

        //デッキのカードタイプ
        [SerializeField]
        private Card.CardTypes[] deckCardType = new Card.CardTypes[DeckArrayMax];
        
        //デッキのカードナンバー
        [SerializeField]
        private int[] decaCardNumber = new int[DeckArrayMax];

        //ステージのカードタイプ
        public Card.CardTypes[] stage1CardTypes = new Card.CardTypes[StageArray1Max];
        public Card.CardTypes[] stage2CardTypes = new Card.CardTypes[StageArray2Max];
        public Card.CardTypes[] stage3CardTypes = new Card.CardTypes[StageArray3Max];
        public Card.CardTypes[] stage4CardTypes = new Card.CardTypes[StageArray4Max];
        public Card.CardTypes[] stage5CardTypes = new Card.CardTypes[StageArray5Max];
        public Card.CardTypes[] stage6CardTypes = new Card.CardTypes[StageArray6Max];
        public Card.CardTypes[] stage7CardTypes = new Card.CardTypes[StageArray7Max];

        //ステージのカードナンバー
        public int[] stage1CardNumber = new int[StageArray1Max];
        public int[] stage2CardNumber = new int[StageArray2Max];
        public int[] stage3CardNumber = new int[StageArray3Max];
        public int[] stage4CardNumber = new int[StageArray4Max];
        public int[] stage5CardNumber = new int[StageArray5Max];
        public int[] stage6CardNumber = new int[StageArray6Max];
        public int[] stage7CardNumber = new int[StageArray7Max];

        private Card.CardTypes[][] stageCardTypes =
        {
            new Card.CardTypes[1],
            new Card.CardTypes[2],
            new Card.CardTypes[3],
            new Card.CardTypes[4],
            new Card.CardTypes[5],
            new Card.CardTypes[6],
            new Card.CardTypes[7],
        };
        //ステージのカードナンバー
        private int[][] stageCardNumbers =
        {
            new int[1],
            new int[2],
            new int[3],
            new int[4],
            new int[5],
            new int[6],
            new int[7]
        };


        public int DeckMax { get { return DeckArrayMax; } }
        public int Stage1Max { get { return StageArray1Max; } }
        public int Stage2Max { get { return StageArray2Max; } }
        public int Stage3Max { get { return StageArray3Max; } }
        public int Stage4Max { get { return StageArray4Max; } }
        public int Stage5Max { get { return StageArray5Max; } }
        public int Stage6Max { get { return StageArray6Max; } }
        public int Stage7Max { get { return StageArray7Max; } }

        public Card.CardTypes[] DeckCardTypes
        {
            get { return deckCardType; }
            set { deckCardType = value; }
        }

        public Card.CardTypes[][] GetStagesCard
        {
            get { return stageCardTypes; }
        }

        public int[] DeckCardNumber
        {
            get
            {
                return decaCardNumber;
            }

            set
            {
                decaCardNumber = value;
            }
        }

        public int[][] StageCardNumbers
        {
            get
            {
                return stageCardNumbers;
            }

            set
            {
                stageCardNumbers = value;
            }
        }

        public Card.CardTypes[][] StageCardTypes
        {
            get
            {
                return stageCardTypes;
            }

            set
            {
                stageCardTypes = value;
            }
        }
    }

    /* Inspector拡張コード */
#if UNITY_EDITOR
    [CustomEditor(typeof(ManualCreateStage))]
    public class StageEditor : Editor
    {
        private bool deckfolding = false;
        private bool stage1folding = false;
        private bool stage2folding = false;
        private bool stage3folding = false;
        private bool stage4folding = false;
        private bool stage5folding = false;
        private bool stage6folding = false;
        private bool stage7folding = false;
        ManualCreateStage manualStage;

        public void Awake()
        {
            manualStage = target as ManualCreateStage;
        }

        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            /* カスタム表示 */
            if (deckfolding = EditorGUILayout.Foldout(deckfolding, "デッキ内容"))
            {
                for(int i= 0; i < manualStage.DeckMax; ++i)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("カード" + i.ToString());
                    manualStage.DeckCardTypes[i] = (Card.CardTypes)EditorGUILayout.EnumPopup(manualStage.DeckCardTypes[i]);
                    manualStage.DeckCardNumber[i] = EditorGUILayout.IntField(manualStage.DeckCardNumber[i]);
                    EditorGUILayout.EndHorizontal();
                }
            }

            if(stage1folding = EditorGUILayout.Foldout(stage1folding, "ステージ列１"))
            {
                for (int i = 0; i < 1; ++i)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("カード" + i.ToString());
                    manualStage.stage1CardTypes[i] = (Card.CardTypes)EditorGUILayout.EnumPopup(manualStage.stage1CardTypes[i]);
                    manualStage.stage1CardNumber[i] = EditorGUILayout.IntField(manualStage.stage1CardNumber[i]);
                    EditorGUILayout.EndHorizontal();
                }
            }

            if(stage2folding = EditorGUILayout.Foldout(stage2folding, "ステージ列2"))
            {
                for (int i = 0; i < 2; ++i)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("カード" + i.ToString());
                    manualStage.stage2CardTypes[i] = (Card.CardTypes)EditorGUILayout.EnumPopup(manualStage.stage2CardTypes[i]);
                    manualStage.stage2CardNumber[i] = EditorGUILayout.IntField(manualStage.stage2CardNumber[i]);
                    EditorGUILayout.EndHorizontal();
                }
            }

            if (stage3folding = EditorGUILayout.Foldout(stage3folding, "ステージ列3"))
            {
                for (int i = 0; i < 3; ++i)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("カード" + i.ToString());
                    manualStage.stage3CardTypes[i] = (Card.CardTypes)EditorGUILayout.EnumPopup(manualStage.stage3CardTypes[i]);
                    manualStage.stage3CardNumber[i] = EditorGUILayout.IntField(manualStage.stage3CardNumber[i]);
                    EditorGUILayout.EndHorizontal();
                }
            }

            if (stage4folding = EditorGUILayout.Foldout(stage4folding, "ステージ列4"))
            {
                for (int i = 0; i < 4; ++i)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("カード" + i.ToString());
                    manualStage.stage4CardTypes[i] = (Card.CardTypes)EditorGUILayout.EnumPopup(manualStage.stage4CardTypes[i]);
                    manualStage.stage4CardNumber[i] = EditorGUILayout.IntField(manualStage.stage4CardNumber[i]);
                    EditorGUILayout.EndHorizontal();
                }
            }

            if (stage5folding = EditorGUILayout.Foldout(stage5folding, "ステージ列5"))
            {
                for (int i = 0; i < 5; ++i)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("カード" + i.ToString());
                    manualStage.stage5CardTypes[i] = (Card.CardTypes)EditorGUILayout.EnumPopup(manualStage.stage5CardTypes[i]);
                    manualStage.stage5CardNumber[i] = EditorGUILayout.IntField(manualStage.stage5CardNumber[i]);
                    EditorGUILayout.EndHorizontal();
                }
            }

            if (stage6folding = EditorGUILayout.Foldout(stage6folding, "ステージ列6"))
            {
                for (int i = 0; i < 6; ++i)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("カード" + i.ToString());
                    manualStage.stage6CardTypes[i] = (Card.CardTypes)EditorGUILayout.EnumPopup(manualStage.stage6CardTypes[i]);
                    manualStage.stage6CardNumber[i] = EditorGUILayout.IntField(manualStage.stage6CardNumber[i]);
                    EditorGUILayout.EndHorizontal();
                }
            }

            if (stage7folding = EditorGUILayout.Foldout(stage7folding, "ステージ列7"))
            {
                for (int i = 0; i < 7; ++i)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("カード" + i.ToString());
                    manualStage.stage7CardTypes[i] = (Card.CardTypes)EditorGUILayout.EnumPopup(manualStage.stage7CardTypes[i]);
                    manualStage.stage7CardNumber[i] = EditorGUILayout.IntField(manualStage.stage7CardNumber[i]);
                    EditorGUILayout.EndHorizontal();
                }
            }

            if(GUILayout.Button("New Card"))
            {
                manualStage.stage1CardTypes = new Card.CardTypes[manualStage.Stage1Max];
                manualStage.stage2CardTypes = new Card.CardTypes[manualStage.Stage2Max];
                manualStage.stage3CardTypes = new Card.CardTypes[manualStage.Stage3Max];
                manualStage.stage4CardTypes = new Card.CardTypes[manualStage.Stage4Max];
                manualStage.stage5CardTypes = new Card.CardTypes[manualStage.Stage5Max];
                manualStage.stage6CardTypes = new Card.CardTypes[manualStage.Stage6Max];
                manualStage.stage7CardTypes = new Card.CardTypes[manualStage.Stage7Max];
                manualStage.stage1CardNumber = new int[manualStage.Stage1Max];
                manualStage.stage2CardNumber = new int[manualStage.Stage2Max];
                manualStage.stage3CardNumber = new int[manualStage.Stage3Max];
                manualStage.stage4CardNumber = new int[manualStage.Stage4Max];
                manualStage.stage5CardNumber = new int[manualStage.Stage5Max];
                manualStage.stage6CardNumber = new int[manualStage.Stage6Max];
                manualStage.stage7CardNumber = new int[manualStage.Stage7Max];
            }

            if(GUILayout.Button("Save Star Cards"))
            {
                StartCardSetSaveData startCardSetSaveData = StartCardSetSaveData.Instance;
                startCardSetSaveData.deckCardsType = manualStage.DeckCardTypes;
                startCardSetSaveData.deckCardsNumber = manualStage.DeckCardNumber;
                startCardSetSaveData.stage1CaadsType = manualStage.stage1CardTypes[0];
                startCardSetSaveData.stage1CardNumber = manualStage.stage1CardNumber[0];
                startCardSetSaveData.stage2CardsTyoe = manualStage.stage2CardTypes;
                startCardSetSaveData.stage2CardsNumber = manualStage.stage2CardNumber;
                startCardSetSaveData.stage3CardsType = manualStage.stage3CardTypes;
                startCardSetSaveData.stage3CardsNumber = manualStage.stage3CardNumber;
                startCardSetSaveData.stage4CardType = manualStage.stage4CardTypes;
                startCardSetSaveData.stage4CardNumber = manualStage.stage4CardNumber;
                startCardSetSaveData.stage5CardType = manualStage.stage5CardTypes;
                startCardSetSaveData.stage5CardNumber = manualStage.stage5CardNumber;
            }
        }
    }
#endif


}

