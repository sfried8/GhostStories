using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class GameBoardModelManager : MonoBehaviour
{
    public GameObject RedTaoist;
    public GameObject GreenTaoist;
    public GameObject YellowTaoist;
    public GameObject BlueTaoist;



    private Dictionary<GridSpace.GridSpaceRow, float> rowFloats = new Dictionary<GridSpace.GridSpaceRow, float>();
    private Dictionary<GridSpace.GridSpaceCol, float> colFloats = new Dictionary<GridSpace.GridSpaceCol, float>();

    public GameBoardModelManager()
    {
        rowFloats.Add(GridSpace.GridSpaceRow.Bottom, 0f);
        rowFloats.Add(GridSpace.GridSpaceRow.Center, 4f);
        rowFloats.Add(GridSpace.GridSpaceRow.Top, 8f);

        colFloats.Add(GridSpace.GridSpaceCol.Left, 0f);
        colFloats.Add(GridSpace.GridSpaceCol.Center, 4f);
        colFloats.Add(GridSpace.GridSpaceCol.Right, 8f);
    }
    private Vector3 getVectorFromPosition( GridSpace.GridSpacePosition_struct position, float y )
    {
        float x = 0f;
        float z = 0f;
        rowFloats.TryGetValue(position.row, out z);
        colFloats.TryGetValue(position.col, out x);
        return new Vector3(x, y, z);

    }

    public IEnumerator movePlayer(Player player, GridSpace target)
    {

        GameObject taoistToMove = null;
        switch (player.color)
        {
            case GS.Color.RED:
                taoistToMove = RedTaoist;
                break;
            case GS.Color.YELLOW:
                taoistToMove = YellowTaoist;
                break;
            case GS.Color.GREEN:
                taoistToMove = GreenTaoist;
                break;
            case GS.Color.BLUE:
                taoistToMove = BlueTaoist;
                break;
        }

        if (taoistToMove != null)
        {

            yield return StartCoroutine(taoistMoveAnimation(taoistToMove, getVectorFromPosition(target.GridSpacePosition,0f)));

        }
        yield return null;
    }

    IEnumerator taoistMoveAnimation(GameObject taoist, Vector3 target)
    {
        while (Vector3.Distance(taoist.transform.position, target) > 0.1)
        {
            taoist.transform.position = Vector3.Lerp(taoist.transform.position, target, 3 * Time.deltaTime);
            yield return null;
        }
        yield return null;
    }
    public void initializeBoardWithPlayersAtCenter(List<GridSpace> gridSpaces)
    {
        foreach ( GridSpace gridSpace in gridSpaces )
        {
            gridSpace.gameObject.transform.position = getVectorFromPosition(gridSpace.GridSpacePosition, 0f);
        }
        GridSpace.GridSpacePosition_struct centerPosition = new GridSpace.GridSpacePosition_struct(GridSpace.GridSpaceRow.Center, GridSpace.GridSpaceCol.Center);
        RedTaoist.transform.position = getVectorFromPosition(centerPosition, 0f);
        YellowTaoist.transform.position = getVectorFromPosition(centerPosition, 0f);
        GreenTaoist.transform.position = getVectorFromPosition(centerPosition, 0f);
        BlueTaoist.transform.position = getVectorFromPosition(centerPosition, 0f);
    }


}
