using Update.Action;
using Update.Characters;

public class checkIsBusy : UpdateQuery {
	
	public override string Apply(){
		FatherOwens npc = GetComponent<FatherOwens>();
		if(npc.getBusy())
			return "true";
		else
			return "false";
	}
	
}
