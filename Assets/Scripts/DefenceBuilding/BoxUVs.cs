using UnityEngine;
using System.Collections;

public class BoxUVs : MonoBehaviour
{
    public enum Side
    {
        EMPTY,
        STATIC,
    }
    
    Mesh m;
    Vector2[] UVs;
    Vector2[] tPoints;
    Side[] sides = new Side[6];

    void Start()
    {
        m = GetComponent<MeshFilter>().mesh;
        UVs = new Vector2[m.vertices.Length];

        tPoints = new Vector2[10]
        {
            new Vector2(1, 1),
            new Vector2(1, 1),
            new Vector2(1, 1),
            new Vector2(1, 1),
            new Vector2(1, 1),
            new Vector2(1, 1),
            new Vector2(1, 1),
            new Vector2(1, 1),
            new Vector2(1, 1),
            new Vector2(1, 1),
        };

        SetUVs();
    }

    void SetUVs()
    {
        Vector2[] front = SetTexture(0);

        UVs[0] = new Vector2(front[0].x, front[0].y);
        UVs[1] = new Vector2(front[1].x, front[1].y);
        UVs[2] = new Vector2(front[2].x, front[2].y);
        UVs[3] = new Vector2(front[3].x, front[3].y);

        UVs[4] = new Vector2();
        UVs[5] = new Vector2();
        UVs[6] = new Vector2();
        UVs[7] = new Vector2();

        UVs[8] = new Vector2();
        UVs[9] = new Vector2();
        UVs[10] = new Vector2();
        UVs[11] = new Vector2();

        UVs[12] = new Vector2();
        UVs[13] = new Vector2();
        UVs[14] = new Vector2();
        UVs[15] = new Vector2();

        UVs[16] = new Vector2();
        UVs[17] = new Vector2();
        UVs[18] = new Vector2();
        UVs[19] = new Vector2();

        UVs[20] = new Vector2();
        UVs[21] = new Vector2();
        UVs[22] = new Vector2();
        UVs[23] = new Vector2();

        m.uv = UVs;
    }

    Vector2[] SetTexture(int _index)
    {
        Vector2[] textureRef = new Vector2[4];
        switch (sides[_index])
        {
            case Side.STATIC:
                textureRef[0] = tPoints[0];
                textureRef[1] = tPoints[1];
                textureRef[2] = tPoints[2];
                textureRef[3] = tPoints[3];

                return textureRef;
        }

        return null;
    }

    void SetSide(int _index, Side _side)
    {
        sides[_index] = _side;

        SetUVs();
    }
}