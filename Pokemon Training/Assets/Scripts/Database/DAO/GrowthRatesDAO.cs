using SQLite4Unity3d;
using System.Collections.Generic;

public class GrowthRatesDAO{

	public IEnumerable<GrowthRates> getGrowthRates(){
		return DataService.instance._connection.Table<GrowthRates> ();
	}
}
