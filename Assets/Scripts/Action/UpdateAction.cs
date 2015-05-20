
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

	// generic Action that is intended to change a level or character
	public abstract class LevelAction : UpdateAction {

		protected LevelAction(UnityAction act){
			Functor = new ActionFunctor(act);
		}

		protected LevelAction(ActionFunctor act){
			Functor = act;
		}

		protected LevelAction(){}

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
/*

    public delegate CharacterDelegate<T>(T character);

    public class CharacterFunctor<T> : IAction where T : Character {
        protected virtual CharacterDelegate<T> Action {
            get;
            set;
        }

        protected CharacterFunctor(){}

        protected CharacterFunctor(CharacterDelegate<T> action){
            this.Action = action;
        }

        public virtual void Apply(T character){
            this.Action(character);
        }

        public static implicit operator CharacterDelegate<T> (CharacterFunctor<T> a){
            return a.Action;
        }
    }

    public abstract class CharacterAction<T> : UpdateAction where T : Character {
        protected string character;

        protected CharacterAction(string character, UnityAction act) : base(act) {
            this.character = character;
        }

        protected CharacterAction(string character, ActionFunctor act) : base(act) {
            this.character = character;
        }

        public sealed void Apply(){
            CharacterManager.RecordAction(character,this);
            GameObject character = GameObject.Find(character);
            if(character == null)
                return;
            Action(character.GetComponent<T>());
        }

        [SerializeField]
        public CharacterFunctor<T> Functor {
            get;
            internal set;
        }
    }
    */
}

