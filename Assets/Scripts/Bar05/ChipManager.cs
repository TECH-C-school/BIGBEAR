using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipManager : MonoBehaviour {

    private int Chip;
    private string StrChip;
    SpriteRenderer MainSpriteRenderer;
    public Sprite _0;
    public Sprite _1;
    public Sprite _2;
    public Sprite _3;
    public Sprite _4;
    public Sprite _5;
    public Sprite _6;
    public Sprite _7;
    public Sprite _8;
    public Sprite _9;

    public void SetChip(int Chip, int tgt)
    {
        //tgtについて
        //0は所持1は掛け2は相手掛け
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Vector3 pos = transform.position;
        int Kurai1 = Chip % 10;
        int Kurai2 = (Chip % 100 - Kurai1) / 10;
        int Kurai3 = (Chip % 1000 - (Kurai1 + Kurai2)) / 100;
        string ThisName = this.gameObject.name;
        if (tgt == 0)
        {
            if(ThisName == "Num1_Kurai1")
            {
                switch(Kurai1)
                {
                    case 0:
                        MainSpriteRenderer.sprite = _0;
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = _1;
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = _2;
                        break;
                    case 3:
                        MainSpriteRenderer.sprite = _3;
                        break;
                    case 4:
                        MainSpriteRenderer.sprite = _4;
                        break;
                    case 5:
                        MainSpriteRenderer.sprite = _5;
                        break;
                    case 6:
                        MainSpriteRenderer.sprite = _6;
                        break;
                    case 7:
                        MainSpriteRenderer.sprite = _7;
                        break;
                    case 8:
                        MainSpriteRenderer.sprite = _8;
                        break;
                    case 9:
                        MainSpriteRenderer.sprite = _9;
                        break;
                }
            }
            else if(ThisName == "Num1_Kurai2")
            {
                switch (Kurai2)
                {
                    case 0:
                        MainSpriteRenderer.sprite = _0;
                        if(Kurai3 == 0)
                        {
                            pos.z = 0;
                            transform.position = pos;
                        }
                        else
                        {
                            pos.z = -1;
                            transform.position = pos;
                        }
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = _1;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = _2;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 3:
                        MainSpriteRenderer.sprite = _3;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 4:
                        MainSpriteRenderer.sprite = _4;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 5:
                        MainSpriteRenderer.sprite = _5;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 6:
                        MainSpriteRenderer.sprite = _6;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 7:
                        MainSpriteRenderer.sprite = _7;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 8:
                        MainSpriteRenderer.sprite = _8;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 9:
                        MainSpriteRenderer.sprite = _9;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                }
            }
            else if(ThisName == "Num1_Kurai3")
            {
                switch (Kurai3)
                {
                    case 0:
                        MainSpriteRenderer.sprite = _0;
                        pos.z = 0;
                        transform.position = pos;
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = _1;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = _2;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 3:
                        MainSpriteRenderer.sprite = _3;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 4:
                        MainSpriteRenderer.sprite = _4;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 5:
                        MainSpriteRenderer.sprite = _5;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 6:
                        MainSpriteRenderer.sprite = _6;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 7:
                        MainSpriteRenderer.sprite = _7;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 8:
                        MainSpriteRenderer.sprite = _8;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 9:
                        MainSpriteRenderer.sprite = _9;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                }
            }
        }
        else if(tgt == 1)
        {
            if (ThisName == "Num2_Kurai1")
            {
                switch (Kurai1)
                {
                    case 0:
                        MainSpriteRenderer.sprite = _0;
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = _1;
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = _2;
                        break;
                    case 3:
                        MainSpriteRenderer.sprite = _3;
                        break;
                    case 4:
                        MainSpriteRenderer.sprite = _4;
                        break;
                    case 5:
                        MainSpriteRenderer.sprite = _5;
                        break;
                    case 6:
                        MainSpriteRenderer.sprite = _6;
                        break;
                    case 7:
                        MainSpriteRenderer.sprite = _7;
                        break;
                    case 8:
                        MainSpriteRenderer.sprite = _8;
                        break;
                    case 9:
                        MainSpriteRenderer.sprite = _9;
                        break;
                }
            }
            else if (ThisName == "Num2_Kurai2")
            {
                switch (Kurai2)
                {
                    case 0:
                        MainSpriteRenderer.sprite = _0;
                        if (Kurai3 == 0)
                        {
                            pos.z = 0;
                            transform.position = pos;
                        }
                        else
                        {
                            pos.z = -1;
                            transform.position = pos;
                        }
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = _1;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = _2;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 3:
                        MainSpriteRenderer.sprite = _3;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 4:
                        MainSpriteRenderer.sprite = _4;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 5:
                        MainSpriteRenderer.sprite = _5;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 6:
                        MainSpriteRenderer.sprite = _6;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 7:
                        MainSpriteRenderer.sprite = _7;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 8:
                        MainSpriteRenderer.sprite = _8;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 9:
                        MainSpriteRenderer.sprite = _9;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                }
            }
            else if (ThisName == "Num2_Kurai3")
            {
                switch (Kurai3)
                {
                    case 0:
                        MainSpriteRenderer.sprite = _0;
                        pos.z = 0;
                        transform.position = pos;
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = _1;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = _2;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 3:
                        MainSpriteRenderer.sprite = _3;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 4:
                        MainSpriteRenderer.sprite = _4;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 5:
                        MainSpriteRenderer.sprite = _5;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 6:
                        MainSpriteRenderer.sprite = _6;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 7:
                        MainSpriteRenderer.sprite = _7;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 8:
                        MainSpriteRenderer.sprite = _8;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 9:
                        MainSpriteRenderer.sprite = _9;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                }
            }
        }
        else if(tgt == 2)
        {
            if (ThisName == "Num3_Kurai1")
            {
                switch (Kurai1)
                {
                    case 0:
                        MainSpriteRenderer.sprite = _0;
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = _1;
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = _2;
                        break;
                    case 3:
                        MainSpriteRenderer.sprite = _3;
                        break;
                    case 4:
                        MainSpriteRenderer.sprite = _4;
                        break;
                    case 5:
                        MainSpriteRenderer.sprite = _5;
                        break;
                    case 6:
                        MainSpriteRenderer.sprite = _6;
                        break;
                    case 7:
                        MainSpriteRenderer.sprite = _7;
                        break;
                    case 8:
                        MainSpriteRenderer.sprite = _8;
                        break;
                    case 9:
                        MainSpriteRenderer.sprite = _9;
                        break;
                }
            }
            else if (ThisName == "Num3_Kurai2")
            {
                switch (Kurai2)
                {
                    case 0:
                        MainSpriteRenderer.sprite = _0;
                        if (Kurai3 == 0)
                        {
                            pos.z = 0;
                            transform.position = pos;
                        }
                        else
                        {
                            pos.z = -1;
                            transform.position = pos;
                        }
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = _1;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = _2;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 3:
                        MainSpriteRenderer.sprite = _3;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 4:
                        MainSpriteRenderer.sprite = _4;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 5:
                        MainSpriteRenderer.sprite = _5;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 6:
                        MainSpriteRenderer.sprite = _6;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 7:
                        MainSpriteRenderer.sprite = _7;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 8:
                        MainSpriteRenderer.sprite = _8;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 9:
                        MainSpriteRenderer.sprite = _9;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                }
            }
            else if (ThisName == "Num3_Kurai3")
            {
                switch (Kurai3)
                {
                    case 0:
                        MainSpriteRenderer.sprite = _0;
                        pos.z = 0;
                        transform.position = pos;
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = _1;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = _2;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 3:
                        MainSpriteRenderer.sprite = _3;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 4:
                        MainSpriteRenderer.sprite = _4;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 5:
                        MainSpriteRenderer.sprite = _5;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 6:
                        MainSpriteRenderer.sprite = _6;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 7:
                        MainSpriteRenderer.sprite = _7;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 8:
                        MainSpriteRenderer.sprite = _8;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                    case 9:
                        MainSpriteRenderer.sprite = _9;
                        pos.z = -1;
                        transform.position = pos;
                        break;
                }
            }
        }
    }
}
