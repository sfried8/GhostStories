public abstract class VillageTile {
	protected bool isHaunted;
	protected Pool buddhaPool;
    public string tilename;
	public abstract bool canPerformAction(Player player);
	public abstract void performAction(Player player);
    public VillageTile(string tname)
    {
        tilename = tname;
    }
    public void addBuddhas( int quantity ) {
		buddhaPool.addToPool (quantity);
	}
	public int getBuddhas( int quantity ) {
		return buddhaPool.getFromPool (quantity);
	}
}
