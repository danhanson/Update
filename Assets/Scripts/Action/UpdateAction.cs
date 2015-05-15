
using UnityEngine;
using UnityEngine.Events;


namespace Update.Action {

	public interface IAction {
		void Apply();
	}


	[System.Serializable]
	public class ActionFunctor : IAction {

		protected virtual UnityAction Action {
			get;
			set;
		}

		// used by subclasses that override Action property
		protected ActionFunctor(){

		}

		public ActionFunctor(UnityAction action){
			this.Action = action;
		}

		public virtual void Apply(){
			Action.Invoke();
		}

		public static implicit operator UnityAction (ActionFunctor a){
			return a.Action;
		}
	}

	// generic action that can be triggerred by dialogue
	public abstract class UpdateAction : MonoBehaviour, IAction {
		public string actionName;
		public abstract void Apply();
	}

	// generic Action that is intended to changes the map
	public abstract class RecordedAction : UpdateAction {

		protected RecordedAction(UnityAction act){
			Functor = new ActionFunctor(act);
		}

		protected RecordedAction(ActionFunctor act){
			Functor = act;
		}

		protected RecordedAction(){}

		[SerializeField]
		public virtual ActionFunctor Functor {
			get;
			internal set;
		}

		public sealed override void Apply(){
			int level = Application.loadedLevel;
			LevelManager.RecordAction(level,this);
			Functor.Apply();
		}
	}
}

