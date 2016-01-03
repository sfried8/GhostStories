using UnityEngine;

public abstract class VillageTile : MonoBehaviour{
	protected bool isHaunted;
	protected Pool buddhaPool;
    public GameObject tile_obj;
    public string tilename;
	public abstract bool canPerformAction(Player player);
	public abstract void performAction(Player player);

    public void addBuddhas( int quantity ) {
		buddhaPool.addToPool (quantity);
	}
	public int getBuddhas( int quantity ) {
		return buddhaPool.getFromPool (quantity);
	}
    public void highlight()
    {
        tile_obj.GetComponent<Renderer>().material.color = Color.green;
    }
    public void unhighlight()
    {
        tile_obj.GetComponent<Renderer>().material.color = Color.gray;
    }
}
