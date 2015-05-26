using SQLite4Unity3d;

public class PlayerDAO{

	SQLiteConnection _connection;

	public PlayerDAO(SQLiteConnection _connection){
		this._connection = _connection;
	}

	public int ReadGold(){
		Player player = _connection.Table<Player>().First();
		return player.Gold;
	}

	public void UpdateGold(int newGold){
		_connection.Execute("Update Player set Gold = ?", newGold);

	}

	public Player ReadPlayer(){
		return _connection.Table<Player>().First();
	}

	public void DeletePlayer(){
		_connection.Execute("Delete * from Player");
	}
}
