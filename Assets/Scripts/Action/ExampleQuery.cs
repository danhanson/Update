
using Update.Action;
using Update.Characters;

public class ExampleQuery : UpdateQuery {

	public override string Apply(){
		NPC npc = GetComponent<NPC>();
		if(npc.isHappy)
			return "happy";
		else
			return "sad";
	}

}
