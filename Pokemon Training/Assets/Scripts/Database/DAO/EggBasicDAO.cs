using SQLite4Unity3d;
using System.Collections.Generic;

public class EggBasicDAO{

	private SQLiteConnection _connection;

	public EggBasicDAO(SQLiteConnection _connection){
		this._connection = _connection;
	}

	public IEnumerable<EggBasic> GetEggBasicList(){
        return _connection.Table<EggBasic>();
	}

	public void CreateEggBasic(EggBasic newEggBasic){
        _connection.Insert(newEggBasic);
	}

}