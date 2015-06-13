using SQLite4Unity3d;
using System.Collections.Generic;

public class EggBasicDAO{
	
	public IEnumerable<EggBasic> GetEggBasicList(){
        return DataService.instance._connection.Table<EggBasic>();
	}

	public EggBasic GetEggBasic(string category){
		return DataService.instance._connection.Table<EggBasic> ().Where (x => x.Category == category).FirstOrDefault();

	}


}