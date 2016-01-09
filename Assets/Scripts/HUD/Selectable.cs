using UnityEngine;
using System.Collections;

public interface Selectable {
    Selectable getUpperNeighbor();
    Selectable getLowerNeighbor();
    Selectable getLeftNeighbor();
    Selectable getRightNeighbor();
    GameObject getGameObject();
}
