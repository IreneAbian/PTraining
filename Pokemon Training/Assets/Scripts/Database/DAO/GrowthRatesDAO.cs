using SQLite4Unity3d;
using System.Collections.Generic;

public class GrowthRatesDAO{
	private SQLiteConnection _connection;
	
	public GrowthRatesDAO(SQLiteConnection _connection){
		this._connection = _connection;
	}

	public IEnumerable<GrowthRates> getGrowthRates(){
		return _connection.Table<GrowthRates> ();
	}
}
