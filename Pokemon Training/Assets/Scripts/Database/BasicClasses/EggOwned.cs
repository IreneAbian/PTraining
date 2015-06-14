using SQLite4Unity3d;
using System.Collections;

public class EggOwned {

	[PrimaryKey, AutoIncrement]
	public int Id{ get; set; }
	public string Category{ get; set; }
	public int CurrentCycles{ get; set; }
	public int TotalCycles{ get; set; }
	public bool Equipped{ get; set; }
	public int Option1 { get; set; }
	public int Option2 { get; set; }
	public int Option3 { get; set; }
	public int Option4 { get; set; }
	public int Option5 { get; set; }
	public int Option6 { get; set; }
	public int Option7 { get; set; }
	public int Option8 { get; set; }
	public int Option9 { get; set; }
	public int Option10 { get; set; }



	public override string ToString (){
	
		return string.Format ("[EggOwned: Id={0}, Category={1}, CurrentCycles={2}, TotalCyles={3}, Equipped={4}]", Id, Category, CurrentCycles, TotalCycles, Equipped);
	}

}