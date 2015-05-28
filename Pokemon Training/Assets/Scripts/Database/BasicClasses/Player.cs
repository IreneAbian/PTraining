using SQLite4Unity3d;

public class Player {

	[PrimaryKey]
	public string Name{ get; set; }
	public int Gold{ get; set; }

	public override string ToString ()
	{
		return string.Format ("[Player: Name={0}, Gold={1}]", Name, Gold);
	}
	
}
