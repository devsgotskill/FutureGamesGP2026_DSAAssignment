using Environment.Tasks;
using UnityEngine;
using System.Collections.Generic;

namespace Environment
{
    public class Computer : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private Task[] tasks;
        public Stackimp<Task> taskStack = new Stackimp<Task>();
        
        public void Start()
        {
            foreach(Task task in tasks)
            {
                taskStack.Push(task);
            }
        }
        public void OnInteract()
        {
            if(!taskStack.IsEmpty())
            {
                Task task = taskStack.Pop();
                task.Execute();
            }
        }
    }
}
