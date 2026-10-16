using Environment.Tasks;
using UnityEngine;
using System.Collections.Generic;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private Task[] tasks;
        private Stack<Task> taskStack = new Stack<Task>();
        public void Start() {
            foreach(Task task in tasks) {
                taskStack.Push(task);
            }
        }
        public void OnInteract() {
            if(taskStack.Count > 0) {
                Task task = taskStack.Pop();
                task.Execute();
            }
        }
    }
}
