using UnityEngine;

namespace Command.E1.Scripts
{
    public class Command : ICommand
    {
        public GameObject GameObject;
        private readonly string _name;
        public Command(GameObject gameObject, string name)
        {
            GameObject = gameObject;
            _name = name;
        }
        public void Execute()
        {
            var vector3 = GameObject.transform.position;
            vector3.x += 0.1f;
            
            GameObject.transform.position = vector3;
            
            Debug.Log("Execute "  + _name );
        }
    
        public void ExecuteUndo()
        {
            var vector3 = GameObject.transform.position;
            vector3.x -= 0.1f;
            
            GameObject.transform.position = vector3;

            Debug.Log("Undo "  + _name);
        }
    }
    
}