public class Pool {
	private int count;

	public Pool() {
		count = 0;
	}
	public Pool( int startingQuantity ) {
		count = startingQuantity < 0 ? 0 : startingQuantity;
	}


	public void addToPool( int quantity ) {
		count += quantity;
	}
	public int getFromPool( int quantity ) {
		if (quantity > count) {
			quantity = count;
			count = 0;
		} else {
			count -= quantity;
		}
		return quantity;
	}
	public int getSize() {
		return count;
	}
	public bool isEmpty() {
		return count == 0;
	}
}
