using SQLite4Unity3d;
using System.Collections;

public class EggOwned {

	[PrimaryKey, AutoIncrement]
	public int Id{ get; set; }
	public string Category{ get; set; }
	public int[] Options{ get; set; }
	public int CurrentCycles{ get; set; }
	public int TotalCycles{ get; set; }
	public bool Equipped{ get; set; }

	public override string ToString ()
	{
		return string.Format ("[EggOwned: Id={0}, Category={1},  Options={2}, CurrentCycles={3}, TotalCyles={4}, Equipped={5}]", Id, Category, Options, CurrentCycles, TotalCycles, Equipped);
	}

}