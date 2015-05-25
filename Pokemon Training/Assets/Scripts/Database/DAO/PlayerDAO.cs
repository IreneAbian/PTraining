using SQLite4Unity3d;

public class PlayerDAO{

	SQLiteConnection _connection;

	public PlayerDAO(SQLiteConnection _connection){
		this._connection = _connection;
	}

	public int ReadGold(){
		Player player = _connection.Execute("Select * from Player");
		return player.Gold;
	}

	public void UpdateGold(int newGold){
		_connection.Execute("Update Player set Gold = ?", newGold);

	}

	public Player ReadPlayer(){
		Player player = _connection.Execute("Select * from Player");
	}

	public void DeletePlayer(){
		Player player = _connection.Execute("Delete * from Player");
	}
}
