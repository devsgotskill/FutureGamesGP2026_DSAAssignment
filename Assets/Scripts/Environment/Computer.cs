using Environment.Tasks;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if(taskStack.IsEmpty())
            {
                throw new Exception("No more tasks to execute.");
            }
            if(!taskStack.IsEmpty())
            {
                Task task = taskStack.Pop();
                task.Execute();
            } 
        }

    }
}
