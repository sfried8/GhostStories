public class TaoManager {
	private Pool reds;
	private Pool greens;
	private Pool yellows;
	private Pool blues;
	private Pool blacks;


    public TaoManager()
    {
        reds = new Pool();
        greens = new Pool();
        yellows = new Pool();
        blues = new Pool();
        blacks = new Pool();
    }
	public void addTao( GS.Color color, int quantity ) {
		switch (color) {
		case GS.Color.RED:
			reds.addToPool (quantity);
			break;
		case GS.Color.GREEN:
			greens.addToPool (quantity);
			break;
		case GS.Color.YELLOW:
			yellows.addToPool (quantity);
			break;
		case GS.Color.BLUE:
			blues.addToPool (quantity);
			break;
		case GS.Color.BLACK:
			blacks.addToPool (quantity);
			break;
		default:
			break;

		}
	}
	public int removeTao( GS.Color color, int quantity ){
		switch (color) {
		case GS.Color.RED:
			return reds.getFromPool (quantity);
		case GS.Color.GREEN:
			return greens.getFromPool (quantity);
		case GS.Color.YELLOW:
			return yellows.getFromPool (quantity);
		case GS.Color.BLUE:
			return blues.getFromPool (quantity);
		case GS.Color.BLACK:
			return blacks.getFromPool (quantity);
		default:
			return 0;

		}
	}
	public int getTaoQuantity( GS.Color color ){
		switch (color) {
		case GS.Color.RED:
			return reds.getSize ();
		case GS.Color.GREEN:
			return greens.getSize ();
		case GS.Color.YELLOW:
			return yellows.getSize ();
		case GS.Color.BLUE:
			return blues.getSize ();
		case GS.Color.BLACK:
			return blacks.getSize ();
		default:
			return 0;

		}
	}
}
