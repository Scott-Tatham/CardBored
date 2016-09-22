using UnityEngine;
using System.Collections;

public class BoxUVs : MonoBehaviour
{
    public enum Side
    {
        EMPTY,
        TAPE,
        STATIC,
        LETTUCEL,
        LETTUCER,
        ROTCLOCKL,
        ROTCLOCKR,
        ROTCLOCKU,
        ROTCLOCKD,
        ROTANTCLOCKL,
        ROTANTCLOCKR,
        ROTANTCLOCKU,
        ROTANTCLOCKD,
        SLIDER,
        SLIDEU,
        SLIDEL,
        SLIDED,
        SIGNAL,
        TURD,
        TURL,
        TURR,
        TURU
    }
    
    Mesh m;
    Vector2[] UVs;
    Vector2[] tPoints;
    Side[] sides = new Side[6];

    void Awake()
    {
        m = GetComponent<MeshFilter>().mesh;
        UVs = new Vector2[m.vertices.Length];

        for (int i = 0; i < sides.Length; i++)
        {
            sides[i] = Side.EMPTY;
        }

        tPoints = new Vector2[88]
        {
            // Empty
            new Vector2(0.0f, 0.0f),        // v0
            new Vector2(0.125f, 0.0f),      // v1
            new Vector2(0.0f, 0.125f),      // v2
            new Vector2(0.125f, 0.125f),    // v3

            // Tape
            new Vector2(0.125f, 0.875f),    // v4
            new Vector2(0.25f, 0.875f),     // v5
            new Vector2(0.125f, 1.0f),      // v6
            new Vector2(0.25f, 1.0f),       // v7

            // Static
            new Vector2(0.25f, 0.75f),      // v8
            new Vector2(0.375f, 0.75f),     // v9
            new Vector2(0.25f, 0.875f),     // v10
            new Vector2(0.375f, 0.875f),    // v11

            // The Lettuce Left
            new Vector2(0.0f, 0.875f),      // v12
            new Vector2(0.125f, 0.875f),    // v13
            new Vector2(0.0f, 1.0f),        // v14
            new Vector2(0.125f, 1.0f),      // v15
            
            // The Lettuce Right
            new Vector2(0.25f, 0.875f),     // v16
            new Vector2(0.375f, 0.875f),    // v17
            new Vector2(0.25f, 1.0f),       // v18
            new Vector2(0.375f, 1.0f),      // v19

            // Rotate Clockwise Left
            new Vector2(0.5f, 0.875f),      // v20
            new Vector2(0.625f, 0.875f),    // v21
            new Vector2(0.5f, 1.0f),        // v22
            new Vector2(0.625f, 1.0f),      // v23
            
            // Rotate Clockwise Right
            new Vector2(0.625f, 0.875f),    // v24
            new Vector2(0.75f, 0.875f),     // v25
            new Vector2(0.625f, 1.0f),      // v26
            new Vector2(0.75f, 1.0f),       // v27
            
            // Rotate Clockwise Up
            new Vector2(0.75f, 0.875f),     // v28
            new Vector2(0.875f, 0.875f),    // v29
            new Vector2(0.75f, 1.0f),       // v30
            new Vector2(0.875f, 1.0f),      // v31
            
            // Rotate Clockwise Down
            new Vector2(0.875f, 0.875f),    // v32
            new Vector2(1.0f, 0.875f),      // v33
            new Vector2(0.875f, 1.0f),      // v34
            new Vector2(1.0f, 1.0f),        // v35
            
            // Rotate AntiClockwise Left
            new Vector2(0.5f, 0.75f),       // v36
            new Vector2(0.625f, 0.75f),     // v37
            new Vector2(0.5f, 0.875f),      // v38
            new Vector2(0.625f, 0.875f),    // v39
            
            // Rotate AntiClockwise Right
            new Vector2(0.625f, 0.75f),     // v40
            new Vector2(0.75f, 0.75f),      // v41
            new Vector2(0.625f, 0.875f),    // v42
            new Vector2(0.75f, 0.875f),     // v43
            
            // Rotate AntiClockwise Up
            new Vector2(0.75f, 0.75f),      // v44
            new Vector2(0.875f, 0.75f),     // v45
            new Vector2(0.75f, 0.875f),     // v46
            new Vector2(0.875f, 0.875f),    // v47
            
            // Rotate AntiClockwise Down
            new Vector2(0.875f, 0.75f),     // v48
            new Vector2(1.0f, 0.75f),       // v49
            new Vector2(0.875f, 0.875f),    // v50
            new Vector2(1.0f, 0.875f),      // v51
            
            // Slide Right
            new Vector2(0.5f, 0.625f),      // v52
            new Vector2(0.625f, 0.625f),    // v53
            new Vector2(0.5f, 0.75f),       // v54
            new Vector2(0.625f, 0.75f),     // v55
            
            // Slide Up
            new Vector2(0.625f, 0.625f),    // v56
            new Vector2(0.75f, 0.625f),     // v57
            new Vector2(0.625f, 0.75f),     // v58
            new Vector2(0.75f, 0.75f),      // v59
            
            // Slide Left
            new Vector2(0.75f, 0.625f),     // v60
            new Vector2(0.875f, 0.625f),    // v61
            new Vector2(0.75f, 0.75f),      // v62
            new Vector2(0.875f, 0.75f),     // v63
            
            // Slide Down
            new Vector2(0.875f, 0.625f),    // v64
            new Vector2(1.0f, 0.625f),      // v65
            new Vector2(0.875f, 0.75f),     // v66
            new Vector2(1.0f, 0.75f),       // v67

            // Signal
            new Vector2(0.0f, 0.75f),       // v68
            new Vector2(0.125f, 0.75f),     // v69
            new Vector2(0.0f, 0.875f),      // v70
            new Vector2(0.125f, 0.875f),    // v71

            // Turret Down
            new Vector2(0.5f, 0.5f),        // v72
            new Vector2(0.625f, 0.5f),      // v73
            new Vector2(0.5f, 0.625f),      // v74
            new Vector2(0.625f, 0.625f),    // v75

            // Turret Left
            new Vector2(0.625f, 0.5f),      // v76
            new Vector2(0.75f, 0.5f),       // v77
            new Vector2(0.625f, 0.625f),    // v78
            new Vector2(0.75f, 0.625f),     // v79

            // Turret Right
            new Vector2(0.75f, 0.5f),       // v80
            new Vector2(0.875f, 0.5f),      // v81
            new Vector2(0.75f, 0.625f),     // v82
            new Vector2(0.875f, 0.625f),    // v83

            // Turret Up
            new Vector2(0.875f, 0.5f),      // v84
            new Vector2(1.0f, 0.5f),        // v85
            new Vector2(0.875f, 0.625f),    // v86
            new Vector2(1.0f, 0.625f)       // v87
        };

        SetUVs();
    }

    void SetUVs()
    {
        Vector2[] front = SetTexture(0);

        // Front
        UVs[0] = new Vector2(front[0].x, front[0].y);
        UVs[1] = new Vector2(front[1].x, front[1].y);
        UVs[2] = new Vector2(front[2].x, front[2].y);
        UVs[3] = new Vector2(front[3].x, front[3].y);

        Vector2[] top = SetTexture(1);

        // Top
        UVs[4] = new Vector2(top[2].x, top[2].y);
        UVs[5] = new Vector2(top[3].x, top[3].y);
        UVs[8] = new Vector2(top[0].x, top[0].y);
        UVs[9] = new Vector2(top[1].x, top[1].y);

        Vector2[] back = SetTexture(2);

        // Back
        UVs[6] = new Vector2(back[1].x, back[1].y);
        UVs[7] = new Vector2(back[0].x, back[0].y);
        UVs[10] = new Vector2(back[3].x, back[3].y);
        UVs[11] = new Vector2(back[2].x, back[2].y);

        Vector2[] bottom = SetTexture(3);

        // Bottom
        UVs[12] = new Vector2(bottom[0].x, bottom[0].y);
        UVs[13] = new Vector2(bottom[2].x, bottom[2].y);
        UVs[14] = new Vector2(bottom[3].x, bottom[3].y);
        UVs[15] = new Vector2(bottom[1].x, bottom[1].y);

        Vector2[] left = SetTexture(4);

        // Left
        UVs[16] = new Vector2(left[0].x, left[0].y);
        UVs[17] = new Vector2(left[2].x, left[2].y);
        UVs[18] = new Vector2(left[3].x, left[3].y);
        UVs[19] = new Vector2(left[1].x, left[1].y);

        Vector2[] right = SetTexture(5);

        // Right
        UVs[20] = new Vector2(right[0].x, right[0].y);
        UVs[21] = new Vector2(right[2].x, right[2].y);
        UVs[22] = new Vector2(right[3].x, right[3].y);
        UVs[23] = new Vector2(right[1].x, right[1].y);

        m.uv = UVs;
    }

    Vector2[] SetTexture(int _index)
    {
        Vector2[] textureRef = new Vector2[4];

        switch (sides[_index])
        {
            case Side.EMPTY:
                textureRef[0] = tPoints[0];
                textureRef[1] = tPoints[1];
                textureRef[2] = tPoints[2];
                textureRef[3] = tPoints[3];

                return textureRef;

            case Side.TAPE:
                textureRef[0] = tPoints[4];
                textureRef[1] = tPoints[5];
                textureRef[2] = tPoints[6];
                textureRef[3] = tPoints[7];

                return textureRef;

            case Side.STATIC:
                textureRef[0] = tPoints[8];
                textureRef[1] = tPoints[9];
                textureRef[2] = tPoints[10];
                textureRef[3] = tPoints[11];

                return textureRef;

            case Side.LETTUCEL:
                textureRef[0] = tPoints[12];
                textureRef[1] = tPoints[13];
                textureRef[2] = tPoints[14];
                textureRef[3] = tPoints[15];

                return textureRef;

            case Side.LETTUCER:
                textureRef[0] = tPoints[16];
                textureRef[1] = tPoints[17];
                textureRef[2] = tPoints[18];
                textureRef[3] = tPoints[19];

                return textureRef;

            case Side.ROTCLOCKL:
                textureRef[0] = tPoints[20];
                textureRef[1] = tPoints[21];
                textureRef[2] = tPoints[22];
                textureRef[3] = tPoints[23];

                return textureRef;

            case Side.ROTCLOCKR:
                textureRef[0] = tPoints[24];
                textureRef[1] = tPoints[25];
                textureRef[2] = tPoints[26];
                textureRef[3] = tPoints[27];

                return textureRef;

            case Side.ROTCLOCKU:
                textureRef[0] = tPoints[28];
                textureRef[1] = tPoints[29];
                textureRef[2] = tPoints[30];
                textureRef[3] = tPoints[31];

                return textureRef;

            case Side.ROTCLOCKD:
                textureRef[0] = tPoints[32];
                textureRef[1] = tPoints[33];
                textureRef[2] = tPoints[34];
                textureRef[3] = tPoints[35];

                return textureRef;

            case Side.ROTANTCLOCKL:
                textureRef[0] = tPoints[36];
                textureRef[1] = tPoints[37];
                textureRef[2] = tPoints[38];
                textureRef[3] = tPoints[39];

                return textureRef;

            case Side.ROTANTCLOCKR:
                textureRef[0] = tPoints[40];
                textureRef[1] = tPoints[41];
                textureRef[2] = tPoints[42];
                textureRef[3] = tPoints[43];

                return textureRef;

            case Side.ROTANTCLOCKU:
                textureRef[0] = tPoints[44];
                textureRef[1] = tPoints[45];
                textureRef[2] = tPoints[46];
                textureRef[3] = tPoints[47];

                return textureRef;

            case Side.ROTANTCLOCKD:
                textureRef[0] = tPoints[48];
                textureRef[1] = tPoints[49];
                textureRef[2] = tPoints[50];
                textureRef[3] = tPoints[51];

                return textureRef;

            case Side.SLIDER:
                textureRef[0] = tPoints[52];
                textureRef[1] = tPoints[53];
                textureRef[2] = tPoints[54];
                textureRef[3] = tPoints[55];

                return textureRef;

            case Side.SLIDEU:
                textureRef[0] = tPoints[56];
                textureRef[1] = tPoints[57];
                textureRef[2] = tPoints[58];
                textureRef[3] = tPoints[59];

                return textureRef;

            case Side.SLIDEL:
                textureRef[0] = tPoints[60];
                textureRef[1] = tPoints[61];
                textureRef[2] = tPoints[62];
                textureRef[3] = tPoints[63];

                return textureRef;

            case Side.SLIDED:
                textureRef[0] = tPoints[64];
                textureRef[1] = tPoints[65];
                textureRef[2] = tPoints[66];
                textureRef[3] = tPoints[67];

                return textureRef;

            case Side.SIGNAL:
                textureRef[0] = tPoints[68];
                textureRef[1] = tPoints[69];
                textureRef[2] = tPoints[70];
                textureRef[3] = tPoints[71];

                return textureRef;

            case Side.TURD:
                textureRef[0] = tPoints[72];
                textureRef[1] = tPoints[73];
                textureRef[2] = tPoints[74];
                textureRef[3] = tPoints[75];

                return textureRef;

            case Side.TURL:
                textureRef[0] = tPoints[76];
                textureRef[1] = tPoints[77];
                textureRef[2] = tPoints[78];
                textureRef[3] = tPoints[79];

                return textureRef;

            case Side.TURR:
                textureRef[0] = tPoints[80];
                textureRef[1] = tPoints[81];
                textureRef[2] = tPoints[82];
                textureRef[3] = tPoints[83];

                return textureRef;

            case Side.TURU:
                textureRef[0] = tPoints[84];
                textureRef[1] = tPoints[85];
                textureRef[2] = tPoints[86];
                textureRef[3] = tPoints[87];

                return textureRef;
        }

        return null;
    }

    public void SetSide(int _index, Side _side)
    {
        sides[_index] = _side;

        SetUVs();
    }
}