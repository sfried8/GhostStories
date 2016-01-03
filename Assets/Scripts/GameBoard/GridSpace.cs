using UnityEngine;
using System.Collections;

public class GridSpace : MonoBehaviour{
    public enum GridSpaceRow
    {
        Bottom,
        Center,
        Top
    }
    public enum GridSpaceCol
    {
        Left,
        Center,
        Right
    }
	public struct GridSpacePosition_struct
    {
        public GridSpaceRow row;
        public GridSpaceCol col;
        public GridSpacePosition_struct( GridSpaceRow r, GridSpaceCol c)
        {
            row = r;
            col = c;
        }
    }



    private GridSpacePosition_struct gridSpacePosition;
    public VillageTile villageTile;


    public VillageTile VillageTile
    {
        get
        {
            return villageTile;
        }

        set
        {
            villageTile = value;
        }
    }

    public GridSpacePosition_struct GridSpacePosition
    {
        get
        {
            return gridSpacePosition;
        }

        set
        {
            gridSpacePosition = value;
        }
    }
    public override string ToString()
    {
        return VillageTile.tilename + ": " + GridSpacePosition.row + ", " + GridSpacePosition.col;
    }
    public void highlight()
    {
        VillageTile.highlight();
    }
    public void unhighlight()
    {
        VillageTile.unhighlight();
    }
}
