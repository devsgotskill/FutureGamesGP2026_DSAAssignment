using System.IO;
using UnityEngine;
using Environment.Tasks;
[CreateAssetMenu(fileName = "ReadEmployeesTask", menuName = "Tasks/Read Employees")]
public class ReadEmployeesTask : Task
{
    [SerializeField] public InsertEmployeesTask insertTask;
    public override void Execute()
    {
        string fileName = "testEmployees.json";
        string filePath = Path.Combine(Application.dataPath, "JSONFILES", fileName);
        string json = File.ReadAllText(filePath);
        EmployeeData data = JsonUtility.FromJson<EmployeeData>(json);
        if(!File.Exists(filePath))
        {
            Debug.LogError("File not found: " + filePath);
            return;
        }
        if(data == null || data.employees == null)
        {
            Debug.LogError("Failed to read employee data!");
            return;
        }
        if(insertTask == null)
        {
            Debug.LogError("No Insert Employees Task");
            return;
        }
        insertTask.employees = data.employees;
        Debug.Log("Loaded " + data.employees.Length + " employees.");
    }
}
